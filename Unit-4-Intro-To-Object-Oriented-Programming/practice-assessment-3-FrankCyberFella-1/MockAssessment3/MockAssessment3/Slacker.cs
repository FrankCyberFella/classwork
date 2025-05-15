namespace MockAssessment3;
//   a Slacker is-a Villager == Inheritace
//          subclass : superclass
public class Slacker : Villager
{
    // Constructor - Initialize data for the class
    //               Runs when an object of the class is created
    //               Farmer aFarmer = new Farmer();
    //
    // Contructor has:
    //     1. public access
    //     2. the same name as the class
    //     3. may take parameters used to initialize the data
    public Slacker()
    {
        Hunger = 3;  // Put the value 3 in the variable Hunger
    }

    // Override or add the abstract method required by Villager (superclasss)
    // The override attribute tells C# this was required by abstract class
    // The method signature MUST match the method signature of abstract method
 // public abstract int Farm();  // Signature of the abstract method
    public override int Farm()
    { 
        return 0;  // Send back a 0 to whatever called this method
    }
}