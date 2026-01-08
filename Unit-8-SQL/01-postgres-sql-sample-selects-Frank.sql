--------------------------------------------------------------------------------------------------------
-- Basic SELECT Lecture Code
--------------------------------------------------------------------------------------------------------
-- -- indicates a comment - anything following on the line is ignored
--
-- SQL SELECT statement - retrieve values from the database (Read)
--
-- A SELECT statement is often referred to as a query
--
-- Basic syntax: (the order in which these is important/required)
--
--      SELECT   - columns to include in the result (seperate multiple column requests with commas)
--      FROM     - table containing rows used in the query 
--      WHERE    - rows to include in the result - WHERE predicates are similar to C#/Java predicate (a predicate is conditions)
--      ORDER BY - sequence of rows in the result
--                 without an ORDER BY the sequence of the rows in the result is not predictable
--                 if the sequence of the rows in the result matter - code an ORDER BY
--                 default sequence is ascending
--                 you may specify the sequence use ASC or DESC
--
--
-- WHERE predicates:
--
--        =  <>  !=  >  >=  <  <= -- not equal can be specified two ways:  <>   !=
--        IN(list-of-values)      -- alterative to a series of = OR
--        NOT IN(list-of-values)  -- alterative to a series of != AND
--        BETWEEN value AND value
--        IS NULL          -- special predicate for checking to see if column is null 
--        IS NOT NULL      -- special predicate for checking to see if column is not null 
--        LIKE    (use wildcards: % means 0 to any number of any characters
--                                _ means exactly any one character
--                'word%'  - starts with word
--                '%word'  - ends with word
--                '%word%' - contains word
--
--        ILIKE   (case insensitive LIKE - Postgres extension)
--
-- predicates may be combined using AND and OR
--
-- use parentheses to make your multi-predicate condition clear

-- The DISTINCT clause on a SELECT removes duplicate values from the result
-- based on the all columns that follow
--
-- The DISTINCT ON(columns/expression) clause on a SELECT removes duplicate values from the result
-- based on the all columns/expression inside the parentheses that follow (Postgres extension)
------------------------------------------------------------------------------------------------------
Select *          -- * means all columns in the order defined in the table
  from Gambler;   -- the table with the rows you want to see
--
-- You specify the columns and order of the columsn you want to see in teh result on the select
-- Note: you must code the entire column_name you want to see
--
--in pgAdmin if you have multiple select (or any type of SQL statements) in the query
--           you only see the result of the last one
--
-- if you want run a particular query, highlight it and then click the run buttone
--
select gambler_name, monthly_salary -- only show the name and salary of the gambler
  from gambler;
--
-- Show the birth_date, address and name of every gambler
select birth_date, address, gambler_name
  from gambler;  -- ; are optional in pgAdmin, but NOT everywhere you can use SQL, so code a ; to be safe
--
-- Show all the data for the gambler named S.Q. Elle
select *                            -- Show all columns in order defined
  from gambler                      -- from this table
 where gambler_name = 'S.Q. Elle';  -- but only these rows
                                    -- Strings and single chars are enclosed in single quotes
                                    -- String values must exactly match - upper/lower case, spacing, punctuation
--
-- Show all the data for the gambler not named S.Q. Elle
select *                            -- Show all columns in order defined
  from gambler                      -- from this table
 where gambler_name != 'S.Q. Elle'; -- but only these rows
                                    -- Strings and single chars are enclosed in single quotes
                                    -- String values must exactly match - upper/lower case, spacing, punctuation
									--
-- Show all the data for the gambler named S.Q. Elle or Dana Imori
sELEct *                            -- Show all columns in order defined
  FROM gambler                      -- from this table
 where gaMblEr_naMe = 'S.Q. Elle'   -- but only these rows
    or gambler_Name = 'Dana Imori'; -- Case doesn't matter in SQL keywords or column names, just in strings                                

-- Show all the data for the gambler named S.Q. Elle or Dana Imori or Phil Donahuge
select *                            -- Show all columns in order defined
  from gambler                      -- from this table
 where gambler_name = 'S.Q. Elle'   -- but only these rows
    or gambler_name = 'Dana Imori'  -- Case doesn't matter in SQL keywords or column names, just in strings   
    or gambler_name = 'Phil Donahuge'; -- Case doesn't matter in SQL keywords or column names, just in strings  

-- Show all the data for the gambler named S.Q. Elle or Dana Imori or Phil Donahuge
-- IN clause is short cut for a series of = OR predicates for the same column
-- IN(list-of-values-separated-by-commas)
select *                            -- Show all columns in order defined
  from gambler                      -- from this table
 where gambler_name In('S.Q. Elle', 'Dana Imori', 'Phil Donahuge');   -- but only these rows
--
-- Show me people whose names starts with 'D'
select * 
  from gambler
 where gambler_name LIKE 'S%';  -- search for names starting with 'D' 
--
-- Show me people whose names contain 'D'
select * 
  from gambler
 where gambler_name LIKE '%D%';  -- search for names starting with 'D' 
--
-- Show me people whose names ends in 'e'
select * 
  from gambler
 where gambler_name LIKE '%e %';  -- search for names ending with 'e' followed by one or more spaces
                                  -- spaces after the e mean it doesn't end in e
--
-- Show me people who make more that 10000 a month
select gambler_name, monthly_salary
  from gambler
 where monthly_salary > 10000; 
 --
-- Show me people who make between 2000 and 10000 a month
select gambler_name, monthly_salary
  from gambler
 where monthly_salary between 2000 and 10000; 

--
-- Show the gambler names in alphabetical order
--
select gambler_name   -- columns to include in result 
  from gambler        -- table with the data
order by gambler_name;-- sequence of rows in the result - default order is ascending

--
-- Show the gambler names in reverse alphabetical order
select gambler_name			  -- columns to include in result		
  from gambler				  -- table with the data
order by gambler_name DESC;  -- sequence of rows in the result - DESC indicates descending order
--
-- Show everyone's annual salary (monthly_salary * 12)
--  We can do arithmetic on a select to create a new column (derived column)
--  Derived columns do not have names
--
-- the AS phrase will add a column name to a derived column or rename an exisiting column in result
-- AS will convert the new name to all lowercase
-- AS does not allow spaces between the new name
-- Use _ to separate the parts of a name
--    or enclose the name in double quotes to have spaces or respect the case of the name
--
-- The AS name may be used in an ORDER BY
-- The AS phase MAY NOT used in a WHERE
select gambler_name
     , monthly_salary * 12  -- calculate annual salary 
  from gambler
;
-- Show everyone's annual salary (monthly_salary * 12) with the title Annual_Salary
--  We can do arithmetic on a select to create a new column (derived column)
--
select gambler_name as Name
     , monthly_salary * 12 as "Annual Salary" -- calculate annual salary with the name Annual_Salary 
  from gambler
;
-- Show everyone's annual salary (monthly_salary * 12) with the title Annual_Salary
-- We can do arithmetic on a select to create a new column (derived column)
-- Show the highest salaries first
--
select gambler_name as Name
     , monthly_salary * 12 as Annual_Salary -- calculate annual salary with the name Annual_Salary 
  from gambler
order by Annual_Salary desc 
--order by monthly_salary * 12 desc -- you may also repeat the derivation of the value on the order by
;

-- Show everyone's annual salary (monthly_salary * 12) with the title Annual_Salary
-- We can do arithmetic on a select to create a new column (derived column)
-- Show the highest salaries first
-- Only show those with annual salary greater than 500000
-- Since AS named columns cannot be used in a WHERE clause
--      we must repeat the derivation of the value in the where clause
--
select gambler_name as Name
     , (monthly_salary * 12) as Annual_Salary -- calculate annual salary with the name Annual_Salary 
  from gambler
 where (monthly_salary * 12) > 500000  -- only include those with Annual Salary > 500000
order by Annual_Salary desc 
;




