// This a comment - everything after the is ignored
/*
 * This is a block comment - everything between the slash-asterisk
 *                           and asterrisk-slash is ignored
 *
 * This is useful if you have lot to say or to deactivate code
  
   The * at the start of each line is optional
 
 */

// A namespace identifies a context in which a word is known
//   allows the same name to be used in different context to mean different things
namespace Project_1;

// Everything is C# is defined in a Class
// a Class is group of related things
// A Class starts with the class keyword
class Program
// { } surround blocks of related code aka code-blocks
{ // Start of code for the class
    // Every application has a method called Main()
    // a method is a self-contained set code that performs a function
    // also known as: a function or a program
    // a method may return a value and accept data to process
    // method signature identifies what  the method returns it's name and what it accepts
    //    return-type name(data-it-accepts)
    
    // Main() is where every application starts
    // Every application has one and only Main() method
    
    // Below Main() is a method that returns void and accepts string[] called args
    //
    // void means it returns nothing
    // static means there can be one of these in the block or code (Program class)
    
    //     return
    //     type   name(data-it-accepts)
        static void   Main(string[] args)  // method signature
    {
        // Start of the code for Main()
        // This code will display whatever is between the ("") on the screen
        
        // Console is an object defined by C# to represent the screen
        // An object has certain behaviors
        // A behavior is something an object can do with data
        // behaviors are implemented using methods
        
        // object.method(data) - object oriented programming
        //
        // when you see a . after a name, the name too left of the . is probably and object
        //                name( , the name is a method
        //                name after the ., the name is usually a method
        
    //   object.method(data-for-the-method-to-process)    
        Console.WriteLine("Hello, Frank!"); // EVERY C# STATEMENT ENDS WITH A ;
        
    } // End of the code for Main()
} // End of code for the class