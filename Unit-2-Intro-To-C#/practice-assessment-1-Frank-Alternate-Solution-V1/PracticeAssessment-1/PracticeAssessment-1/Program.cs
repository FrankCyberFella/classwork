namespace PracticeAssessment_1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Practice Assessment 1");
        
        // To test/verify a method does what it should
        // We call it with various options
        // Call it and display what it returns
        Console.WriteLine("Calling IsTheSame(5,5) expecting true, it returns: "  + IsTheSame(5, 5));
        Console.WriteLine("Calling IsTheSame(4,5) expecting false, it returns: " + IsTheSame(4, 5));
        
        // Test whether Subtract can handle negative, positive and zero value results
        //      as well as numbers with decimal places
        
        Console.WriteLine("Calling Subtract(4,5) expecting -1, it returns: " + Subtract(4, 5));
        Console.WriteLine("Calling Subtract(5,4) expecting 1,  it returns: " + Subtract(5, 4));
        Console.WriteLine("Calling Subtract(5,5) expecting 0,  it returns: " + Subtract(5, 5));
        Console.WriteLine("Calling Subtract(4.1,1.3) expecting 2.8,  it returns: " + Subtract(4.1, 1.3));
        Console.WriteLine("Calling Subtract(5,1.5) expecting 3.5,    it returns: " + Subtract(5, 1.5));
        Console.WriteLine("Calling Subtract(1.5, 1) expecting .5,    it returns: " + Subtract(1.5, 1));
        
        /* Test FindBuildingType using multiple values testing boundaries and between the boundaries
         
         house - 3 - max value
                 1 - min value (assumed)
                 2 - between the ranges
         office - 10 - max value
                  4  - min value 
                  8 - between the ranges    
         skyscraper - 49 - max value
                      11 - min value 
                      32 - between the ranges   
         super - 100 - max value
                  50 - min value                       
        */
        
        Console.WriteLine("Calling FindBuildingType(3) expecting house, it returns: " + FindBuildingType(3));
        Console.WriteLine("Calling FindBuildingType(1) expecting house, it returns: " + FindBuildingType(1));
        Console.WriteLine("Calling FindBuildingType(2) expecting house, it returns: " + FindBuildingType(2));
        
        Console.WriteLine("Calling FindBuildingType(10) expecting office, it returns: " + FindBuildingType(10));
        Console.WriteLine("Calling FindBuildingType(4) expecting office, it returns: " + FindBuildingType(4));
        Console.WriteLine("Calling FindBuildingType(8) expecting office, it returns: " + FindBuildingType(4));
        
        Console.WriteLine("Calling FindBuildingType(11) expecting skyscraper, it returns: " + FindBuildingType(11));
        Console.WriteLine("Calling FindBuildingType(49) expecting skyscraper, it returns: " + FindBuildingType(49));
        Console.WriteLine("Calling FindBuildingType(32) expecting skyscraper, it returns: " + FindBuildingType(32));
        
        Console.WriteLine("Calling FindBuildingType(50) expecting super, it returns: "  + FindBuildingType(50));
        Console.WriteLine("Calling FindBuildingType(100) expecting super, it returns: " + FindBuildingType(100));
        
    }  // End of Main()
    // Any methods used by Main() are defined after Main() method and before the end of the class
    
    // 1. Create a static method named IsTheSame() that returns a bool and takes in two numbers (int) as parameters.
    //
    //   To create a static method - code the word static at the start of the method
    //   Since the method will be used by Main() and Main() is static any method it uses must be static
    
    // method signature identifies the method name, what it returns and what it accepts
    //
    //     return
    //     type name(what-it-accepts) - parameters: data-type name
    static bool IsTheSame(int num1, int num2)
    {
        // // If num1 is equal to num2, return true
        // //  if (num1 == num2) return true; // this works, but non-standard (non-professional)
        // if (num1 == num2)
        // {
        //     // Industry standards expect the true processing to be inside { } 
        //     return true;
        // }
        // else  // If num1 is not equal to num2, return false.
        // { // Industry standards expect the false processing to be inside { } 
        //     return false; 
        // }
        // If a bool is being returned all you need is the conditional expression
        // (Don't need to have an if-else - its OK if you do)
        return num1 == num2; // works too
        // 1. C# will evaluate the num1 == num2 - result is true or false
        // 2. return the result from step1
        //
        // C# expressions always return  value that use however you need to
    } // End of IsTheSame()
    
    // Create a static method named Subtract() that takes in 2 parameters, all doubles: num1, num2.
    // (since all data is doubles, the return type should be double)
    //  This method should return num1 minus num2.
    // method parameters go inside ()
    static double Subtract(double num1, double num2)
    {
        return num1 - num2;  // (num1 - num2)  - parentheses optional 
    } // End of Subtract()

    
    /* Create a static method named FindBuildingType() takes in a number (int) as a parameter.
       (The following ranges are inclusive)
       
       If the number is 3 or less, return "This is a house!"
       If the number is between 4 and 10, return "This is an office building!"
       If the number is between 11 and 49, return "This is a skyscraper!"
       If the number is 50 or more, return "This is a SUPER skyscraper!" 
    */
    static string FindBuildingType(int num1)
    {
        // Solution using a switch statement
        // a switch is alternative to a series of if-else statements
        //
        // case statement identifies the condition you want to check
        //
        // two formats of the case statement:
        //
        // 1. case value - when you want to check the switch variable equal the value
        // 2. case datatype variable when condition - when you want to check for something other than equal
        //                  th value in the switch variable is assigned to variable defined after case

        switch (num1)  // check the value in num1
        {
            case int house when house <= 3:  // assign the value in num1 to new int house then check house <= 3
            {
                return "This is a house";
            }
            case int office when office >= 4 && office <= 10: // assign the value in num1 to new int office then check office
            {
                return "This is a office";
            }
            case int skyscraper when skyscraper >= 11 && skyscraper <= 49:
            {
                return "This is a skyscraper";
            }
            default: // if not of the cases are true do this
            {
                return "This is a SUPER skyscraper";
            }
        }
        
        
        // if (num1 <= 3)
        // {
        //     return "This is a house";
        // }
        // else if (num1 >=4 && num1 <= 10)
        // {
        //     return "This is an office building!";
        // }
        // else if (num1 >=11 && num1 <= 49)
        // {
        //     return "This is a skyscraper!";
        // }
        //
        // // We KNOW if we get here the number has to be 50 or greater 
        // // We've handled all other situations alread
        // return "This is a SUPER skyscraper!";
        
        // This return is required because C# doesn't know that we've handled all possible situations
        // so it wants a return in case we haven't
        //
        // to avoid this, remove the last else if
        //return "I don't know";
    }
    
} // End of class Program