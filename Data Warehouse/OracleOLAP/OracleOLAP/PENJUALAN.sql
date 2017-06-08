--------------------------------------------------------
--  File created - Thursday-June-01-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table PENJUALAN
--------------------------------------------------------

  CREATE TABLE "GLOBAL"."PENJUALAN" 
   (	"NO_PRODUK" NUMBER, 
	"NO_PELANGGAN" NUMBER, 
	"JUMLAH" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "GLO" ;
REM INSERTING into GLOBAL.PENJUALAN
SET DEFINE OFF;
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (101,6000,5);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (102,3000,2);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (105,8000,12);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (105,3000,7);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (107,7000,6);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (104,7000,6);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (101,4000,9);
Insert into GLOBAL.PENJUALAN (NO_PRODUK,NO_PELANGGAN,JUMLAH) values (105,4000,13);
--------------------------------------------------------
--  Ref Constraints for Table PENJUALAN
--------------------------------------------------------

  ALTER TABLE "GLOBAL"."PENJUALAN" ADD CONSTRAINT "PENJUALAN_FK1" FOREIGN KEY ("NO_PRODUK")
	  REFERENCES "GLOBAL"."PRODUK" ("NO_PRODUK") ENABLE;
 
  ALTER TABLE "GLOBAL"."PENJUALAN" ADD CONSTRAINT "PENJUALAN_FK2" FOREIGN KEY ("NO_PELANGGAN")
	  REFERENCES "GLOBAL"."PELANGGAN" ("NO_PELANGGAN") ENABLE;
