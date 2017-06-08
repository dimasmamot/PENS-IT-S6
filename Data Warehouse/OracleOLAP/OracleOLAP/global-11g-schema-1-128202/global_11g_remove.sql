-- 10/9/07  awaite  Remove the GLOBAL schema and user.

-- Run this script as the SYSTEM user.

-- GLOBAL SAMPLE SCHEMA REMOVAL

-- This script removes the GLOBAL schema (includes source tables and 
-- analytic workspace) and the GLOBAL user.

set verify off
set serveroutput on

drop user global cascade;



