--
-- This SQL will refresh the Pet Application tables 
--      in the data base in which it is run
--
drop table if exists pet_types CASCADE; -- drop even if it has dependents
drop table if exists owner     cascade; -- drop even if it has dependents
drop table if exists pet       cascade; -- drop even if it has dependents

-- 
-- Create the Pet_Types table
-- (Parent Table to pet - Parents must be created before dependents)
--
CREATE TABLE pet_types 
(
--  column-name     data-type   nullness,
	pet_type_id     serial      not null, -- serial tells postgres to automatically generate a unique integer value
	name            char(15)    not null, -- char is fixed size - specify the fixed, actual size
	species         varchar(50) not null,  -- varchar is variable size - you specifu the max size
	CONSTRAINT pk_pet_type_id PRIMARY KEY (pet_type_id)
)
;

-- 
-- Create the owner table
-- (Parent Table to pet - parents must be created before dependents)
--
Create table owner
(
    owner_id       serial         not null,
	last_name      varchar(50)    not null,
	first_name     varchar(50)    not null,
	address        varchar(100),  -- optional value
	city           varchar(20), 
	state          char(2),
	CONSTRAINT pk_owner_id PRIMARY KEY (owner_id)
)
;
-- 
-- Create the pet table
-- (Dependent Table to pet and owner - Dependents must be created after parents)
--
Create table pet
(
pet_id       serial        not null,
name         varchar(250)  not null,
pet_type_id  integer       not null, -- match to an existing in parent (foreign key)
                                     -- serial will create new value
owner_id     integer       not null, 
CONSTRAINT pk_id PRIMARY KEY (pet_id),
CONSTRAINT fk_pet_type_id FOREIGN KEY(pet_type_id) 
           REFERENCES pet_types(pet_type_id),
CONSTRAINT fk_ownerid FOREIGN KEY(owner_id) 
           REFERENCES owner(owner_id) 	  
)
;
--
-- Add data to pet_types table (a parent table)
--
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

--
-- Add data to owner table (a parent table)
--

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

--
-- Now that the parent tables have data
--     we can add data to any dependent tables
--
-- Add data to pet table (a dependent table)
--
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
