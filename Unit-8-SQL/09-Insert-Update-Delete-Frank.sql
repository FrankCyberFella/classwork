---------------------------------------------------------------------------------------------------------------------------------------
-- Referential Integrity (RI) - Enforcement of the Parent-Dependent relatiohnship
--                          ie. Ensure that every foreign key value has a matching primary key
--
-- A Primary Key specified for a table makes it a potential parent table in an RI relationship
--               it's not a parent until a foreign key matches to it (it has a dependent)
--
-- A Foreign Key specified for a table makes it a dependent in an RI relationship
--
--          the city table is a dependent of the country table
--          countrycode column in city is a Foreign Key to the Primary Key of the code column in country
--          the database manager will ensure every value in the countrycode column of city 
--                               has matching value in code column of country 
--
-- Referential Intergrity limits what INSERT, UPDATE and DELETE can do
--
-- INSERT - parent table - always allowed
--          dependent table - allowed only if the foreign already has a matching primary key in the parent
--
--          we can always INSERT a row to the country table
--          we can only INSERT a row into the city table if it's countrycode matches a code in country
--
-- UPDATE - parent - a Primary Key cannot be updated if it has existing dependents (at least one Foreign Key matches it)
--                   UNLESS the update CASCADE option is specified for the parent table
--                          which means the Primary Key value can change and all matching Foreign Key values will also change
--
--          dependent - a Foreign Key may only be changed to an existing Primary Key value
--
-- DELETE - parent - a parent row cannot be deleted if it's Primary Key has matching Foreign Keys
--                   UNLESS the DELETE SET NULL option is specified for the parent table
--                          which means all Foreign Keys matching the Primary will be set to NULL
--                          the null value in the Foreign Key must be changed to match an existing Primary Key
--                                         before you can do anything with the dependent table 
--                          for DELETE SET NULL to be valid, the Foreign Key cannot be defined a UNIQUE or NOT NULL
--                                              it also cannot be part of the Primary Key of the dependent table
--                   OR the DELETE CASCADE option is specified for the parent table
--                          which means a delete of a parent rows also deletes all dependent rows (DANGEROUS!)
--
--  TLDR: If tables have Primary Keys and Foreign Keys you may not be able to do certain INSERT, UPDATE, DELETE operations
--
--  UNIQUE   - Column value must be unique with the table 
--
--  PRIMARY KEY - Column is part of the unique identifier for a row in the table
--                UNIQUE and NOT NULL are implied
--
--  FOREIGN KEY - Column is part of a foreign key for the table.  
--                Value must have a matching value in the primary key of the parent table
--                Establishes the parent-dependent relationship
--
--  CHECK  -  Specifies acceptable values for a column - any simple WHERE predicate is allowed
--
--  DEFAULT - Specify a default value for column if no value is supplied on INSERT
---------------------------------------------------------------------------------------------------------------------------------------
-- Unit Of Work (UOW) - A recoverable sequence of operations within an application process
-- 
-- BEGIN TRANSACTION - Mark the start of a unit of work
-- 
-- COMMIT - End a unit of work and save changes - automatically done if no errors
-- 
-- ROLLBACK - End a unit of work and undo changes - automatically done if errors
--
-- Without defining a UNIT OF WORK in the SQL File
-- The entire file is considered one unit of work
-- Any error in the SQL file will cause all INSERT, UPDATE, DELETE processing 
--     before the error to be undone
---------------------------------------------------------------------------------------------------------------------------------------
--  INSERT - add a row to a table
--
--  Format 1: INSERT INTO table-name 
--            (column-list)           -- must contain all non-null columns
--            VALUES(value-list)      -- order of values must match order of columns specified
--
--
--  Format 2: INSERT INTO table-name 
--            VALUES(value-list)      -- order of values must match order of columns as defined in the table
--
--
--  Format 3: INSERT INTO table-name 
--            (SELECT statement)      -- order of columns in the SELECT must match the order of columns as defined in the table
--                                    -- () are optional
--
--    You MUST provide values for all non null columns or columns that the data base doesn't generate                                     
---------------------------------------------------------------------------------------------------------------------------------------
--  UPDATE - change data in a table
--
--  UPDATE table-name
--  SET column = new-value
--  WHERE condition            -- scope of update - if omitted, all rows are updated                                         
---------------------------------------------------------------------------------------------------------------------------------------
--  DELETE - Remove rows from a table
--
--  DELETE FROM table-name
--  WHERE condition            -- scope of delete - if omitted, all rows are deleted                                        
---------------------------------------------------------------------------------------------------------------------------------------
-- INSERT
--

-- Insert rows into the pet_types table
--
-- pet_types is a parent of pet so we must load it before pet

-- Species    Name
--  Dog       German Shepard
--  Dog       Great Dane
--  Dog       Xolo
--  Dog       Dalmation
--  Cat       Burmese
--  Cat       Sphinx
--  Cat       Siamese

--
-- If you reloading or refreshing data in table
--
-- Consider delete all existing rows before you run the INSERTs to refresh
-- to avoid duplicate data
--
delete from pet_types;  -- Delete all existing rows from the table
                        -- ONLY DO THIS IF YOU WANT TO EMPTY THE TABLE!

INSERT into pet_types 
       (name , species) -- columns names specified
values('Xolo', 'Dog'); -- pet_type-id not specified as it is auto generated
;

INSERT into pet_types 
       (name , species) -- columns names specified
values('Tea Cup', 'Dog'); -- pet_type-id not specified as it is auto generated
;

INSERT into pet_types 
       (name , species) 
values('German Shepard', 'Dog'); -- pet_type-id not specified as it is auto generated
;

INSERT into pet_types 
       (name , species) 
values('Great Dane', 'Dog'); -- pet_type-id not specified as it is auto generated
;
INSERT into pet_types 
       (name , species) 
values('Dalmation', 'Dog'); -- pet_type-id not specified as it is auto generated
;

-- if you omit column names all non-null column values must be specified
-- If table has auto-generated you must provide a value for auto-generated columns
-- (which you don'e want to do since you want the DBMS to generate the value)
--insert into pet_types - can't omit column names unless we want to procivide pet_type_id
--                        (you should never provide a value for autogenerated field
--                         because up dpno't know if its unique or what is alread in database)
--  Values('Burmese' , 'Cat') -- not pet_id_type - autogenerated
;
INSERT into pet_types 
       (species, name) -- column names can be listed in any order; values must match the order
values('Cat', 'Burmese'); -- pet_type-id not specified as it is auto generated
;

INSERT into pet_types 
       (species, name) 
values('Cat', 'Sphinx'); -- pet_type-id not specified as it is auto generated
;
INSERT into pet_types 
       (species, name) 
values('Cat', 'Siamese'); -- pet_type-id not specified as it is auto generated
;

select * from pet_types;

--
-- Insert some rows into owner 
-- Owner is parent table to pet
-- so it must loaded with data before pet
--
-- last_name    first_name  address    city      state
-- Fella        Frank                  Phoenix   AZ
-- Corelone     Vito                             NY
-- Gibbs II     Kevin                  Detroit   MI


-- Empty the table so we only have the data once
delete from owner;  -- Be careful with format of delete because rows will deleted

-- Multiple rows may be added withone INSERT statement by repeating the VALUES clause
-- (Don't forget the , after each VALUES clause except the last)
Insert into owner
(first_name   , last_name , address,  city    , state)
Values('Frank', 'Fella'   , null    , 'Phoenix'  , 'AZ'),
      ('Vito' , 'Corelone', null    ,  null      , 'NY'),
	  ('Jay'  , 'Durocher', null    ,  null      , 'MI'),
--	  ('Jay'  , 'North'   , 'Dennis','The Menace', 'MI'),
	  ('Cam'  , 'Johnson' , null    ,  null      , 'NY'),
	  ('Kathy', 'Fella'   , null    , 'Phoenix'  , 'AZ'),
      ('Kevin', 'Gibbs II', null    ,  null      , 'MI')
;
select * from owner;

--
-- Now that the parent tables have data
--     we can add data to any dependent tables
--
-- Be sure any foreign key values have matchng data 
--    in the Primary Key of the parent
--
-- name     pet_type            owner
-- Jenna    German Shepard Dog  Frank
-- Princess Tea Cup Dog         Jay
-- Chole    Siamese Cat         Cameron 

-- pet_type_id was automatically generated by DBMS
-- We don't really know what it is
-- BUT... The data base manager knows
--       We can ask the data base manager for a value using a select
--
-- Use a sub-query/sub-select to have the data base manager find the value
-- (a sub-query is just a select inside another SELECT, INSERT, UPDATE, DELETE)
--
-- Use a sub query to get the primary key value to set the foreign
--
-- A subquery must return exactly one value from one row or you'll get the error message:
--
--     ERROR:  more than one row returned by a subquery used as an expression 
--
--     SQL state: 21000
--
-- The error happens when a sub-query used in a INSERT, UPDATE or DELETE returns
--     0 or more 1 row
--
-- Ask the database manager to get the primary key value for the data we are inserting
--
-- To get the pet_type_id for a German Shepard Dog the select would be:
-- 
--  select pet_type_id from pet_types where name = 'German Shepard' and species = 'Dog';
--
-- To get the owner_id for Frank the select would be:
-- 
--  select owner_id from owner where first_name = 'Frank' and last_name = 'Fella';

insert into pet
      (name   , pet_type_id, owner_id)
Values('Jenna'
     ,(select pet_type_id from pet_types where name = 'German Shepard' and species = 'Dog')
	 ,(select owner_id    from owner where first_name = 'Frank' and last_name = 'Fella')
	 ) -- end the INSERT statement
;
insert into pet
      (name   , pet_type_id, owner_id)
Values('Princess'
     ,(select pet_type_id from pet_types where name = 'Tea Cup' and species = 'Dog')
	 ,(select owner_id    from owner where first_name = 'Jay') -- error if multiple first_name Jay in the table 
	 ) -- end the INSERT statement
;
insert into pet
      (name   , pet_type_id, owner_id)
Values('Chole'
     ,(select pet_type_id from pet_types where name = 'Siamese' and species = 'Cat')
	 ,(select owner_id    from owner where first_name = 'Cam' and last_name = 'Johnson')
	 ) -- end the INSERT statement
;

-- UPDATE - change existing data in a table
--
-- Syntax: Update table
--         set column - new-value
--         where where-condition
--
-- The WHERE clause controls how many rows are update
-- 
-- If there is no WHERE clause all rows in the table are update
--
-- ALWAYS CODE A WHERE CLAUSE TO TELL IT WHAT ROWS YOU WANT UPDATED
-- (unless your goal is update all thw rows in the table)
--
-- Always verify the update only changed the data you intended to update
-- (code a select after the update and run the update and select together
--   or have the data base tool (pgAdmin) display teh tables after update)
--
-- If your update was in correct 
-- In class, just refresh the tables (run the inserts again)
--
-- Change Princess' owner to Kevin
-- 
--     We need to change Princess' owner id to Kevin's owner id
--
select * from pet where name = 'Princess'; -- See the data before the update

-- Use a sub query to get the primary key value to set the foreign
update pet
      set owner_id = (select owner_id from owner where first_name = 'Kevin' and last_name = 'Gibbs II')
where name = 'Princess'
;

-- Change city and state that Frank lives in to New York, NY in owner table
select * from owner;

update owner
   set city  = 'New York', -- multiple values in a row may be changed with one update statement
       state = 'NY'        -- code a . after the first new valye and column ad value the next one
where first_name = 'Frank' -- this will cause all people named 'Frank' to change
  and last_name  = 'Fella' --      now only people with the name 'Frank' 'Fella' be changed;
;  
select * from owner;

-- DELETE - remove rows from a table
--
-- Syntax:  delete from table
--          where where-condition
--
-- If there is no WHERE clause ALL rows in the table are deleted
--
-- ALWAYS CODE A WHERE CLAUSE TO TELL IT WHAT ROWS YOU WANT DELETE
-- (unless your goal is delete all thw rows in the table)
--
-- Always verify the delete only changed the data you intended to update
-- (code a select after the delete and run the delete and select together
--   or have the data base tool (pgAdmin) display the tables after delete)
--
-- Delete Kathy Fella from the owner table
--
delete from owner
where first_name = 'Kathy' -- this will cause all people named 'Frank' to be deleted
  and last_name  = 'Fella' --      now only people with the name 'Frank' 'Fella' be deleted;
;  
select * from owner;

-- REFERENTIAL INTEGRITY

