namespace AddSomeNumbers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---- Start of Program -----");
        
        // Ask the user for 3 numbers one at a time
        // to produce a sum
        
        // 1. Do this 3 times - A loop allows code to executed multiple times
        //      Ask user to enter a number
        //      Get the number from user
        //      Add the number to a sum
        //
        // 2. Display the sum of the numbers
        
        // Data we need:
        //
        //  1. a place to hold the number entered by the user
        //  2. a place to hold the sum of the numbers
        
        // Define a place to hold the number entered by the user
        int firstEntry = 0;
        
        // Define a place to hold the sum of the numbers
        int sum = 0;
        
        // Loop through our process 3 times
        // If you know the number of times you want to loop
        //    Use a for-loop
        //
        // Syntax of a for loop:
        //                (1)                        (2a)                     (2b)
        //          initialization-part       ; loop-condition-part       ; increment
        //    for(int variable = initial-value; variable < #-times-to-Loop; variable++) {
        //    }
        //
        // The for-loop is controlled by the variable defined within it:
        //
        //    1. int variable=initial-value - initializes the variable (usually to 0)
        //    2. the condition following the variable definition is tested:
        //          a.  if true - perform the process between the {} for the for-loop
        //          b.  increment (++) the variable according the last part of the loop
        //              go back to #2
        //          c.  if false - exit the loop after the closing brace }

        for (int i=0; i < 5; i++) // i=0, 1, 2 inside the loop - 3 causes it to exit
        {
            // Ask the user to enter a number
            Console.WriteLine("Please enter a number: ");
            // Get the number they enter
            string theUserResponse = Console.ReadLine(); // Get data from keyboard
            firstEntry = int.Parse(theUserResponse); // Convert data to an int

            // Alternate way to get the number without using a string variable
            // Combine multiple statements into one
            // firstEntry = int.Parse(Console.ReadLine());

             // Add the number to the sum
             sum = sum + firstEntry; // sum += firstEntry; works too
        }

        // Display the sum of the numbers
        Console.WriteLine("The sum of all your wonderful numbers is: " + sum);

        Console.WriteLine("---- End  of Program -----");
        
    }
}