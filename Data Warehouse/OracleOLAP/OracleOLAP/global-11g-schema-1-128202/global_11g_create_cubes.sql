set serverout on
set verify off
set feedback off
spool global_cubes.log

whenever sqlerror exit sql.sqlcode 

-- Introduction
  prompt
  prompt This procedure creates the cubes for the sample GLOBAL schema.  
  prompt You should be logged on as a DBA to execute this procedure.
  prompt

-- Create Oracle directory pointing to source templates and programs
  prompt Specify file system directory containing this installation program.
  prompt
  prompt   Example: 
  prompt   c:\download\Global_Schema_11g or /home/oracle/Global_Schema_11g
  prompt
  accept v_directory prompt 'Directory: '  

  create or replace directory global_install as '&v_directory/Templates';
  grant all on directory global_install to global;

  prompt Specify a password for the GLOBAL user. 
  connect global
  prompt

  prompt Begin installation

-- Delete GLOBAL AW if it exists
  prompt ... deleting GLOBAL AW (if it exists)
  declare
    xmlCLOB   clob;
    v_i       number;
    type t_dims is table of all_cube_dimensions%rowtype;
    type t_cubes is table of all_cubes%rowtype;
    v_dims    t_dims;
    v_cubes   t_cubes;
    v_cmd     varchar2(400);    
    
  begin
    -- Check if the AW exists
    dbms_output.put_line('... checking for GLOBAL AW in GLOBAL schema');
    SELECT COUNT(*)  
    INTO v_i
    FROM all_aws
    WHERE owner = 'GLOBAL'
     AND aw_name = 'GLOBAL';

    -- Delete the AW if it exists
    if v_i > 0 then
      dbms_output.put_line('... deleting GLOBAL AW in GLOBAL schema');
      dbms_lob.createtemporary(xmlCLOB,TRUE);
      dbms_lob.open(xmlCLOB, DBMS_LOB.LOB_READWRITE);
      dbms_lob.writeappend(xmlCLOB, 9, '<Metadata');
      dbms_lob.writeappend(xmlCLOB, 16, '  Version="1.1">');
      dbms_lob.writeappend(xmlCLOB, 5, '  <AW');
      dbms_lob.writeappend(xmlCLOB, 19, '    Action="REMOVE"');
      dbms_lob.writeappend(xmlCLOB, 18, '    Owner="GLOBAL"');
      dbms_lob.writeappend(xmlCLOB, 19, '    Name="GLOBAL"/>');
      
      -- Loop over each of the Dimensions in the AW and delete them
      select *
      bulk collect
      into v_dims
      from all_cube_dimensions
      where owner = 'GLOBAL'
        and aw_name = 'GLOBAL';
            
      for i in 1 .. v_dims.count loop
        v_cmd := '<' || initcap(v_dims(i).dimension_type) || 'Dimension';
        dbms_lob.writeappend(xmlCLOB, length(v_cmd), v_cmd);
        dbms_lob.writeappend(xmlCLOB, 19, '    Action="REMOVE"');
        dbms_lob.writeappend(xmlCLOB, 18, '    Owner="GLOBAL"');
        
        v_cmd := '    Name="' || v_dims(i).dimension_name || '"/>';
        dbms_lob.writeappend(xmlCLOB, length(v_cmd), v_cmd);        
      end loop;

      -- Loop over each of the cubes and delete them
      select *
      bulk collect
      into v_cubes
      from all_cubes
      where owner = 'GLOBAL'
        and aw_name = 'GLOBAL';
            
      for i in 1 .. v_cubes.count loop
        dbms_lob.writeappend(xmlCLOB, 7, '  <Cube');
        dbms_lob.writeappend(xmlCLOB, 19, '    Action="REMOVE"');
        dbms_lob.writeappend(xmlCLOB, 18, '    Owner="GLOBAL"');
        v_cmd := '    Name="' || v_cubes(i).cube_name || '"/>';              
        dbms_lob.writeappend(xmlCLOB, length(v_cmd), v_cmd);
      end loop;      
      
      -- Finish off the removal tags
      dbms_lob.writeappend(xmlCLOB, 11, '</Metadata>');      
      dbms_lob.close(xmlCLOB);      
      dbms_cube.import_xml(xmlCLOB);      
      commit;
    else
      dbms_output.put_line('... GLOBAL AW in GLOBAL schema not found');
    end if;
    
    exception
      when others then
        dbms_output.put_line(' ');
        dbms_output.put_line('# ERROR:  Installation failed.');
        dbms_output.put_line('# Please ensure that the analytic workspace GLOBAL is not currently open.');
        raise_application_error(-20000, 'Can not delete analytic workspace that is currently in use.');
        
end;
/

-- Create the GLOBAL AW
  prompt ... creating GLOBAL AW

  begin    
    dbms_cube.import_xml('GLOBAL_INSTALL', 'GLOBAL_MV.XML'); 
    commit;
  end;
/
  
-- Build the Cube 

  prompt ... building the UNITS_CUBE and PRICE_CUBE  
  BEGIN
    DBMS_CUBE.BUILD(
      'GLOBAL.CHANNEL, GLOBAL.CUSTOMER, GLOBAL.PRODUCT, GLOBAL."TIME", GLOBAL.PRICE_CUBE, GLOBAL.UNITS_CUBE',
      'CCCCC?', -- refresh method
  false, -- refresh after errors
      1, -- parallelism
  false, -- atomic refresh 
  true, -- automatic order
  false); -- add dimensions
  END;
/

prompt Installation complete.
spool off