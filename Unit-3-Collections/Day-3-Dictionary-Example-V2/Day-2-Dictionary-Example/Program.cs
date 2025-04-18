using System;
using System.Collections.Generic;  // Give me access to the systems generic collections stuff

namespace Day_2_Dictionary_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*********************************************************
             * Example use of a Dictionary with array/List value
             *********************************************************/
                
            // Ask the user for a name and a grade
            // Store them in a Dictionary
            
            // Dictionary to hold name (key) and grade (value)
            //         key     value
            //         type    type          name      = new Dictionary<key-type, value>();
            Dictionary<string, List<double>> gradeBook = new Dictionary<string, List<double>>();
            
            // Let's add students and grades until the user indicates they are done
            // Loop until the user satisfies a condition instead of a specific # of times
            // Replace the for-loop with either a while-loop or do-while()
            // Do we want loop at least once? Yes - do-while loop;  No - while loop
            // Is Ok to loop 0-times? Yes - while loop;  No - do-while loop
            //
            // In this case we have to ask the user at least once to enter some data
            // How do we want the user to let us know they are done?
            // Create an on/off switch
            // Prompt - ask if they are done
            // Set a condition based on what they tell us
            // Define data used in the loop BEFORE the loop so it's accessible
            //      both inside and outside loop
            // scope - where can a variable be used - only in the block it's defined
            string userResponse = "";
            do 
            {
                // Ask the user for the student name and grade
                Console.Write("Enter student name: ");
                string studentName = Console.ReadLine(); // Get student name// Ask the user for the student name
                //Console.Write("Enter grade: ");
                // Because the user might enter n non-numeri grade causing an exception
                // We should handle the exception so the program doesn't end
                //    with a message that will scare the human
                // We can use a try/catch to handle the exception
                // When the user enters a non-numeric grade:
                //      1. ignore it and keep going - We are doing this
                //                                    don't put student in dictionary
                //      2. Give them another chance to enter it
                //      3. Set the grade to 0

                // We need to define grade outside any block so it can be used by all code
                double grade = 0;
                string userGrade = "";
                List<double> grades = new List<double>();
                try {  // A statement inside this try block might cause an exception
                    // We need to get multiple grades for each student and store themin a List
                    string whatTheyTyped = "";
                    while (whatTheyTyped != "end") // Loop until the user enter "end"
                    {
                        Console.Write("Enter grade or end: ");
                        // Get the user input as a string in case we need it later
                        whatTheyTyped = Console.ReadLine();
                        if (whatTheyTyped == "end")
                        {
                            break; // exit the loop - continue would be OK too
                        }
                        grade = Double.Parse(whatTheyTyped); // convert the user input to number
                        grades.Add(grade); // Add the grade entered to list
                    }
                    // at then end of this look the grades list has all the grade
                }
                catch (FormatException exceptionObject) // if it throws a FormatException ...
                {
                    Console.WriteLine("The data you entered ("+ userGrade + ") is not a valid number");
                    Console.WriteLine("The data is ignored");
                    // Skip adding the student to the dictionary 
                    continue;  // skip the rest of the loop processing
                }

                // Add the data to our Dictionary only if we have a valid grade
                // Dictionary[key}     = value;
                gradeBook[studentName] = grades; // adding the list of grades for the student
                // We need to find out if they have more students to enter
                // We want to be sure they only enter responses we expect
                // Loop until we get a valid response...
                // for-loop - Do we know how many times we want to loop? NO
                // while    - Do we loop based on a condition? YES - Can we loop 0 times? - NO
                // do-while - Do we loop based on a condition? YES - Do we need loop at least once? - YES
                do
                {
                    Console.WriteLine("Are you done? (y/n)");
                    // Get a response from the user and convert to lowercase 
                    userResponse = Console.ReadLine().ToLower();
                    // We are checking userResponse AFTER we get it from the user
                } while (userResponse != "y" && userResponse != "n");
                
            } while (userResponse != "y");  // Loop while they are not done (done == "y")
            
            // Display the entrys in our Dictionary
            // Use a KeyValuePair type to get an entry from th Dictionary
            foreach (KeyValuePair<string, List<double>> anEntry in gradeBook)
            {
                Console.WriteLine(anEntry.Key + " has a grades of ");
                foreach (double grade in anEntry.Value)
                {
                    Console.WriteLine(grade);
                }
            }
            
            Console.WriteLine("Please press enter to end program...");
            Console.Read();
        }
    }
}