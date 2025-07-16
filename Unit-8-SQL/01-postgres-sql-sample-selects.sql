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
--                 if the sequence of teh rows in teh result matter - code an ORDER BY
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