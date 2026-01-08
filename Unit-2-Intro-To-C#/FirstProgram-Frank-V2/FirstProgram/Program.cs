namespace FirstProgram;

// This program will ask for three numbers
//      add them together and display the total

// Programming Solution - Human thinking
// Identify the detailed steps
//
// Ask for the numbers one at time
// Write down each number as its given
// Add the numbers together create a sum/total
// Tell the requester the total (display)
//
// Now that we have the steps in our solution
// Identify any data/processes you need for the steps
//
// 1. A place to write down each number - a variable in a program
// 2. A place to hold the sum/total - a variable in a program
// 3. A way to ask for the numbers - a method in a program (object.method())
// 4. A way to receive the numbers - a method in a program (object.method())
// 5. A way to report the sum/total - a method in a program (object.method())
//
// Place the steps in the order and provide more detail if necessary
//  we need to solve the problem
//
// 1. Ask for the numbers one at time
//    a. Tell whatever is giving us the numbers to give me the first number
//    b. Receive the first number from sender
//    c. Write down the first number
//    d. Tell whatever is giving us the numbers to give me the second number
//    e. Receive the second number from sender
//    f. Write down the second number
//    g. Tell whatever is giving us the numbers to give me the third number
//    h. Receive the third number from sender
//    i. Write down the third number
//
// 2. Add the numbers together create a sum/total
//    a. Add the first number to a sum/total
//    b. Add the second number to a sum/total
//    c. Add the third number to a sum/total
//
// 3. Tell the requester the sum/total (display)
//
class Program
{
    static void Main(string[] args)
    {
        /*******************************************************************
         * Define ny data the program needs at the top of the program
         *
         * Data may be defined anywhere before it's used, it easier to
         * find at top of the program
         *
         * To define a variable:  data-type name = initial-value;
         *
         * Commonly used data types in C#:
         *
         *   int    - Numeric data that is a whole number between +/- 2 billion
         *   long   - A whole number greater than +/- 2 billion
         *   double - Numeric value with decimal places
         *   char   - a single alpha-numeric character
         *   string - a series of alpha-numeric characters (words or sentence)
         *   bool   - true or false value for conditons
         *
         *   examples:  10 -  int (or long)
         *              1.0 - double
         *              'a' - char (note it is enclosed in ' ')
         *              "some words" - string (note it is enclosed in " ")
         *
         *  Variable names C# are usually spelled in camelCase; Use _ to separate words
         *  (camelCase means the first letter is in lowercase all other words
         *             start with upper case letter)
         *
         * It's always good to initialize variables when defining them so you
         * know what is in them
         *********************************************************************/
        
        // Define the variables to hold the numbers we need to add
        int number1 = 0;  // Since we will be doing math it needs to be numeric
        int number2 = 0;  // Since we will be doing math it needs to be numeric
        int number3 = 0;  // Since we will be doing math it needs to be numeric
        
        // Define a variable to hold the sum of the numbers
        int sum = 0; 

        Console.WriteLine("--- Starting program ---");
        
        // Ask for the numbers one at time using the C# Console object
        //     which represents the keyboard and screen
        // Console.ReadLine() returns a string from keyboard - cannot store in an int
        Console.WriteLine("Please enter a number:  ");  // Asking for the number
        string theResponse;      // Define a string to hold the line of input from the keyboard
        theResponse = Console.ReadLine();               // Get a line from the keyboard
        // We need an int value to store our numbers
        // Console.ReadLine() only returns a string
        // So we need to convert the string from Console.ReadLine() to an int
        // int.Parse(string) will convert a string to an int
        number1 = int.Parse(theResponse);
        
        Console.WriteLine("Please enter a number:  ");
        theResponse = Console.ReadLine();  // Reuse theResponse define above
        number2 = int.Parse(theResponse);
        
        Console.WriteLine("Please enter a number:  ");
        theResponse = Console.ReadLine();  // Reuse theResponse define above
        number3 = int.Parse(theResponse);
        
        // Add the numbers together create a sum/total
        sum = number1 + number2 + number3;
        // Alternate coding method - Choose the coding style that you like
        // However you code as you get a correct solution 
        //         AND you understand it, it is right
        // sum = sum + number1;
        // sum = sum + number2;
        // sum = sum + number3;
        
        // Tell the requester the sum/total (display)
        Console.WriteLine("The sum is: " + sum);
        
        Console.WriteLine("--- Ending program ---");
    }
}