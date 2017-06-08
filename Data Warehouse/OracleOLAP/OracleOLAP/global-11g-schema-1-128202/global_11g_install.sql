-- GLOBAL SAMPLE SCHEMA CREATION

-- This script prompts for a password, creates the GLOBAL user, and
-- grants the privileges required to install the GLOBAL schema and
-- to create an analytic workspace.
-- It then imports tables into the schema.

SET ECHO OFF
SET VERIFY OFF

-- Run this script as the SYSTEM user.

-- Prompt for a password.

ACCEPT password CHAR PROMPT 'Enter the password for the user GLOBAL: ' HIDE
ACCEPT spassword CHAR PROMPT 'Enter the password for the user SYSTEM: ' HIDE

CONNECT system/&spassword

-- Create the GLOBAL user.
CREATE USER global
    IDENTIFIED BY &password;

-- Specify roles and privileges.
GRANT create session, create dimension, create materialized view, advisor, olap_user, olap_xs_admin, unlimited tablespace to global;

-- Connect as the GLOBAL user.
CONNECT global/&password

-- Import the data.
ho imp userid=system/&spassword fromuser=global touser=global file='global_11g_source.dmp' buffer=65000

