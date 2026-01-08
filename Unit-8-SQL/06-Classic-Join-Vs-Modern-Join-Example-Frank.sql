-- list all the Gamblers
select * from gambler;

-- list all the rows in the host table
select * from host;

-- Show the name of each gambler and the casino name that hosts them
--
-- gambler_name is in the gambler table
-- casino_name is in the host table
-- when you need data from more than one table you must find out what connects them
-- the id of the gambler connects the gambler to the host table
--
-- Because the id of the gambler has the same name in both tables
-- We have qualify which table we want take the id from
--
-- a qualified name: table-name.column-name
--
-- Whenever you need data from more than one table - its a JOIN (inner join)
--

-- 
-- Classic Syntax Join
--
--
-- if you forget the where clause ir wrong on the join you get a cartesian product 
-- (all rows from table with all rows from the other - NOT a JOIN)
-- No error would be generated
--
select gambler_name, casino_name  -- columns to see in result
  from gambler, host              -- table(s) that have the data you need
 where host.id = gambler.id       -- rows wanted in the result - rows that match between gambler and host tables 
;
--
-- Modern Syntax
--
-- You cannot forget the join condition - ON phrase as it will generate an error
--
select gambler_name, casino_name
from gambler     -- code one table on the from
     inner join  -- type of join (instead of a ,)
     host        -- code the other tabe
  on gambler.id = host.id -- join/match condition
;

select gambler_name, casino_name
from gambler inner join host   -- tables with the data
  on gambler.id = host.id      -- join/match condition - rows that match bewteen tables
;  