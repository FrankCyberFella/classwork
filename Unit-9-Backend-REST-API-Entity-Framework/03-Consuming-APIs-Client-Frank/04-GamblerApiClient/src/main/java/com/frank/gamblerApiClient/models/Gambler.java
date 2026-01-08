package com.frank.gamblerApiClient.models;

import java.util.Objects;

public class Gambler {
    /***********************************************************************
     * Gambler Data Model Starter Code
     ***********************************************************************/

    // Data members

    private int      Id;
    private String   Name;
    private String   Address;
    private double   Salary;
    private String   BirthDate;

    // 0-arg constructor may be used by Java/C# when needed
    public Gambler() { }

    // 5-arg constructor - accepts all data members
    public Gambler(int id, String name, String address, double salary, String birthDate)
    {
        Id        = id;
        Name      = name;
        Address   = address;
        Salary    = salary;
        BirthDate = birthDate;
    }

    // Getters and Setters for each data member

    public int    getId() {
        return Id;
    }
    public void   setId(int id) {
        Id = id;
    }
    public String getName() {
        return Name;
    }
    public void   setName(String name) {
        Name = name;
    }
    public String getAddress() {
        return Address;
    }
    public void   setAddress(String address) {
        Address = address;
    }
    public double getSalary() {
        return Salary;
    }
    public void   setSalary(double salary) {
        Salary = salary;
    }
    public String getBirthDate() {
        return BirthDate;
    }
    public void   setBirthDate(String birthDate) {
        BirthDate = birthDate;
    }

    // Standard Overrides for methods you want to
    //    customize from the default behavior
    //
    // Most IDEs (like IntelliJ IDEA, Eclipse, etc.)
    //     will generate these for you

    // toString() method - returns a string representation of the object
    @Override
    public String toString() {
        return "Gambler{" +
                "Id=" + Id +
                ", Name='" + Name + '\'' +
                ", Address='" + Address + '\'' +
                ", Salary=" + Salary +
                ", BirthDate='" + BirthDate + '\'' +
                '}';
    }

    // equals() method - compares two objects for equality
    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Gambler gambler = (Gambler) o;
        return Id == gambler.Id && Double.compare(Salary, gambler.Salary) == 0 && Objects.equals(Name, gambler.Name) && Objects.equals(Address, gambler.Address) && Objects.equals(BirthDate, gambler.BirthDate);
    }

    // hashCode() method - returns a hash code for the object
    @Override
    public int hashCode() {
        return Objects.hash(Id, Name, Address, Salary, BirthDate);
    }

    public void displayGambler() {
        System.out.println("Gamlber Id:\t\t"+ Id);
        System.out.println("Gambler Name:\t" + Name);
        System.out.println("Gambler Addr:\t" + Address);
        System.out.println("Salary:\t\t\t" + Salary);
        System.out.println("Birth Date:\t\t" + BirthDate);
        System.out.println("-".repeat(50));
    }
} //End of Gambler class

