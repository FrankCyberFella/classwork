namespace MockAssessment3;

//   a Farmer     is-a Villager == Inheritace
//          subclass: superclass
public class Farmer : Villager
{
    // Constructor - Initialize data for the class
    //               Runs when an object of the class is created
    //               Farmer aFarmer = new Farmer();
    //
    // Contructor has:
    //     1. public access
    //     2. the same name as the class
    //     3. may take parameters used to initialize the data
    public Farmer()
    {
        Hunger = 1; // Set Hunger to 1
    }

    // Override or add the abstract method required by Villager (superclasss)
    // The override attribute tells C# this was required by abstract class
    // The method signature MUST match the method signature of abstract method
    public override int Farm()
    {
        return 2;
    }

}