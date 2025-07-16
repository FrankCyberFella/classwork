-- Some common Postgres SQL string function examples
--
-- This code assumes usage of the world database, country table
--
-- ||                                           -- string concatenation operator
-- lower(string)                                -- returns string in lower case
-- upper(string)                                -- returns string in upper case
-- length(string)                               -- returns length of string
-- substring(string from start-pos for length)  -- returns substring of string as specified
-- left(string, n)                              -- returns first n chars in string
-- right(string, n)                             -- returns last n chars in string
-- repeat(string, n)                            -- returns string repeated n times
-- reverse(string)                              -- returns chars in string in reverse order
-- replace(string,from-char,to-char)            -- returns string with all occurances of from-char replaced by to-char
-- ltrim(string)                                -- returns string with leading spaces removed
-- rtrim(string)                                -- returns string with trailing spaces removed
-- ltrim(string,'char')                         -- returns string with leading char removed
-- rtrim(string,'char')                         -- returns string with trailing char removed
--
-- other string functions and variations of these functions are available
-- please refer to the postgres documention for more information (Google 'postgres string functions')
--
select gambler_name                                  -- gambler name 
      ,lower(gambler_name )                          -- convert gambler name to lower case
      ,upper(gambler_name )                          -- convert gambler name to upper case
      ,length(gambler_name )                         -- return length of gambler name
      ,substring(gambler_name  from 3 for 2)         -- substring(gambler name from third char for 2 chars)
      ,left(gambler_name ,5) as first_5_char         -- left 5 chars of gambler name
      ,right(gambler_name ,5) as last_5_char         -- last 5 chars of gambler name
      ,repeat('-',10)                                -- repeat('-',10 times)
      ,repeat(left(gambler_name ,3)||' ',5)          -- repeat 1st 3 chars of gambler name followed by a space 5 times
      ,reverse(gambler_name )                        -- reverse the characters in gambler name
      ,replace(gambler_name ,'a','@')                -- replace any 'a' in gambler name with '@'
	  
      ,'Hello ' || ltrim('    Frank        ') || ' Fella' as ltrim  -- trim leftmost/leading spaces from string
      ,'Hello ' || rtrim('    Frank        ') || ' Fella' as rtrim  -- trim rightmost/trailing spaces from string
      ,'Hello ' || trim(both ' ' from '    Frank        ') || ' Fella' as trim_both -- trim both leading and trailing spaces from string
      
	  ,ltrim('$19.95','-$')  as no_dash_$    -- remove leading - or $ from string
      ,ltrim('-$19.95','-$') as no_dash_$    -- remove leading - or $ from string
      ,ltrim('$-19.95','-$') as no_dash_$    -- remove leading - or $ from string
      
from gambler -- Table containing data needed
limit 10     SO-- Limit result to first 10 rows
;