package com.gamblerapi.model;

import java.util.Objects;

public class Casino {

    // Data members for the class

    private String casinoName;  // Casino Name
    private String location;    // Location
    private String owner;       // Owner
    private int    size;        // Size

    // Constructors

    public Casino() {}

    public Casino(String casinoName, String location, String owner, int size) {
        this.casinoName = casinoName;
        this.location = location;
        this.owner = owner;
        this.size = size;
    }

    // Standard Named Getters and Setters
    public String getCasinoName() {
        return casinoName;
    }
    public void setCasinoName(String casinoName) {
        this.casinoName = casinoName;
    }
    public String getLocation() {
        return location;
    }
    public void setLocation(String location) {
        this.location = location;
    }
    public String getOwner() {
        return owner;
    }
    public void setOwner(String owner) {
        this.owner = owner;
    }
    public int getSize() {
        return size;
    }
    public void setSize(int size) {
        this.size = size;
    }

    // Overrides for standard operations where the default behavior is undesirable
    //   toString, equals, hashCode
    @Override
    public String toString() {
        return "Casino{" +
                "casinoName='" + casinoName + '\'' +
                ", location='" + location + '\'' +
                ", owner='" + owner + '\'' +
                ", size=" + size +
                '}';
    }
    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Casino casino = (Casino) o;
        return size == casino.size && Objects.equals(casinoName, casino.casinoName) && Objects.equals(location, casino.location) && Objects.equals(owner, casino.owner);
    }
    @Override
    public int hashCode() {
        return Objects.hash(casinoName, location, owner, size);
    }
} // End of Casino class
