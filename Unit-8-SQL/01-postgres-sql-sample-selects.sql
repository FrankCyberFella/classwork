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
--      SELECT   - columns to include in the result (seperate multiple column reqeusts with commas)
--      FROM     - table containing rows used in the query 
--      WHERE    - rows to include in the result - WHERE predicates are similar to Java predicate (a predicate is conditions)
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
--                'word%'  - starts with test
--                '%word'  - ends with test
--                '%word%' - contains test
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
select * from gambler;   -- get all the columns from the gambler table

select birth_date, gambler_name  -- get me these columns
  from gambler;                  -- from this table
;
select birth_date, gambler_name    -- columns in the result
  from gambler                     -- table with the rows 
 where gambler_name = 'S.Q. Elle'  -- which rows you want in the result (note string in apostrohes)
 ;
 select birth_date, gambler_name   -- columns in the result
  from gambler                     -- table with the rows 
 where gambler_name Like '%Q%';     -- rows where gambler_name contains a 'Q'

-- SQL supports 3 date formats:
--
-- USA format: 'mm/dd/yyyy'   United States
-- EUR format: 'yyyy-mm-dd'   European
-- JIS format: 'dd.mm.yyyy'   Japanese industrial standard
--
-- You don't have to know or case what format the date is stored in
-- (actually it's none of those)
--
-- Each database manager has a default display format (USA, EUR, JIS)

select birth_date, gambler_name   -- columns in the result
  from gambler                     -- table with the rows 
 where birth_date between '1970-01-01' and '12/31/1979';  -- rows where gambler was born in the 70's
 

-- Display how old each person is and demonstrate date formattin
--
-- AGE() will calculate the duration between dates
--
-- Syntax: AGE(first-date, second-date)
--
-- to_char() allows you to format the date for display
--
-- Syntax:  to_char(date,'format-string')
--
--  Use the following codes in the format string for the date parts desired:
--
--              dd    - day of month from 01-31
--              Day   - day spelled out
--              MM    - month number from 01-12
--              Mon   - month name abbreviated
--              Month - month spelled out
--              yy    - year with two digits
--              yyyy  - year with four digits
--
-- the AS phrase will assign or change the names of the columns in the result
--    (columns derived from functions or calculations do not have names)
--  
select gambler_name, birth_date, 
      to_char(birth_date, 'MM/dd/yy')                  as USA_Format_2_Digit_Year,
  	  to_char(birth_date, 'MM/dd/yyyy')                as USA_Format_4_Digit_Year,
	  to_char(birth_date, 'Month dd, yyyy')              as Month_Full,
	  to_char(birth_date, 'Mon dd, yyyy')                as Month_Abbrev,
	  to_char(birth_date, 'Day Month dd, yyyy')          as Human_Format,
	  current_date - birth_date                          as Days_Old,
	  (current_date - birth_date) / 365.25               as Years_Old_EXACT,
	  round(((current_date - birth_date) / 365.25),1)    as Years_Old_1_Decimal,
	  AGE(current_date, birth_date)                      as Date_Diff,
      EXTRACT(YEAR FROM  AGE(current_date, birth_date))  as Years_Old
  from gambler    
  --
  --
  --