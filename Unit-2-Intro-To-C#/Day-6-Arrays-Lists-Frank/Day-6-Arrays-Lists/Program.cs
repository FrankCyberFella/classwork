namespace Day_6_Arrays_Lists;

// This program will ask for five numbers
//      add them together and display the total

class Program
{
    static void Main(string[] args)
    {
        // Define an array to hold 5 numbers
        int[] numbers = new int[3];  // numbers.Length=5; 4 is the largest allowable index

        // Define a variable to hold the sum of the numbers
        int sum = 0;

        Console.WriteLine("--- Starting program ---");
        
        // Normally we process an array from beginning to end
        //  (from the first element to last element, one at a time)
        //
        // a for-loop will loop through a process counting as it does so
        // a for-loop is an excellent tool for processing an array from start to end
        //
        // standard syntax: for(i=0; i < arrayName.Length; i++)
        //
        //  arrayName.Length represents the number of elements in the arry

        //   index      loop as
        //   start      long as the index      increment the 
        //    at 0      is not outside array   index for each loop
        for (int i=0; i < numbers.Length;      i++)  // i = 0, 1, 2 inside loop and 3 when exit loop
        {
            Console.WriteLine("Please enter a number:  "); // Asking for the number
            numbers[i] = int.Parse(Console.ReadLine());    // get a string from keyboard
                                                           // convert it toan int
                                                           // store it in numbers[i]
        }
        
        // Verify the array received the numbers correctly
        // Go through the array one element at a time and display the element
        for (int i=0; i < numbers.Length; i++) // i=0, 1, 2 
        {
            Console.WriteLine("Element #"+ i + " is: " + numbers[i]);
            sum = sum + numbers[i]; // add the current number in the array to sum
        }

        // Tell the requester the sum/total (display)
        Console.WriteLine("The sum is: " + sum);
        
        // Tell the requester the average of the numbers
        // divides the sum by the number of elements (arrayname.Length)
        
        // Note the cast of sum to a double so we get decimal places in the results
        Console.WriteLine("The average of the numbers is: " +  (double) sum / (double) numbers.Length);
        
        //  sum / numbers.Length
        //  int / int ---> integer arithmetic - divide gives two parts quotient and remainder
        //     int  (quotient 2)                                7 / 3 - quotient=2 remainder=1  
        
        // (double) sum / numbers.Length
        // convert sum
        //  to double   / int ----> floating point arithmetic
        //
        //              /  convert int to double (C# does this automatically)
        //   double     / double ---> floating point arithmetic
        //          double (2.333333)

        Console.WriteLine("--- Ending program ---");
    }
}