namespace MockAssessment3;

public abstract class Villager
{
    // Define a property for the class
    //        with a getter and setter
    // Property names are in PascalCase
    // {get; set;} automatically generates private member
    //             variables for the property
    public int Hunger { get; set; }

    // Define an abstract method that returns and int
    //                       and receives no parameters
    //
    // Any sub-class MUST define any abstract method in this clas
 // access attribute   return
 //  type  (if needed) type   Name(any-parameters);
    public abstract    int    Farm(); // Note there are no {}
                                      // just a ; at for an abstract method
}