package com.firstapi;

// This is generated for you when you create a Spring Boot application.
//     DO NOT CHANGE ANYTHING IN HERE!!!!!

// Spring Boot is a framework that simplifies the process of building Java applications.

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

// This is the main class for the Spring Boot application.
// It contains the main method which is the entry point of the application.
// The @SpringBootApplication annotation indicates that this is a Spring Boot application.
// This is what start when you run the application

@SpringBootApplication
public class FirstapiApplication {
    // The main method is the entry point of the application.
	public static void main(String[] args) {
		// SpringApplication.run() method is used to launch the application.
		// It takes the application class and command line arguments as parameters.
		SpringApplication.run(FirstapiApplication.class, args);
	}

}
