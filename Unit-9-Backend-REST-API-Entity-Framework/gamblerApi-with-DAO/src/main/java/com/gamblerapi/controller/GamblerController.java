package com.gamblerapi.controller;
// Anything associated with the server must be in the same package as the server
//     so the server can find it.
// Server, Controller, DAOs, POJO Model Class for data, Service, Repository, et al
//      are all in the same package as the server

// controllers contain methods that handle HTTP requests
// When the server receives a request,
//            it will route it to the appropriate controller

import com.gamblerapi.dao.GamblerDAO.GamblerMemoryDao;
import com.gamblerapi.model.Gambler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

// When the server is looking for controller methods it searches for classes
//      that are annotated with @RestController
//
// If you forget to add the @RestContoller annotation,
//    the server will not be able to find your controller methods


@RestController // This annotation indicates that this class
                    //     contains REST a controller methods
                    // REST stands for REpresentational State Transfer
                    //      REST` is an architectural style for designing
                    //            networked applications
                    //      REST is protocol for communication between client and server
                    //           All request and repsonses follow a standard format
public class GamblerController {
    // This is where you will define your controller methods
    // Controller methods are the methods that handle HTTP requests
    // They are annotated with @GetMapping, @PostMapping, @PutMapping, @DeleteMapping, etc.

    // Data members for a class are defined outside any class (at the top)
    //    so all methods in the class can access them

    // Define a reference to the GamblerDAO
    private GamblerMemoryDao gamblerDao;

    // Constructor to initialize the GamblerDAO
    public GamblerController() {
        // Instantiate the GamblerDAO object and assign it to the reference
        this.gamblerDao = new GamblerMemoryDao();
    }


    // Define a controller to handle a GET request to the root URL ("\" or nothing)
    // This method will return a simple greeting message
    @GetMapping("/") // This annotation maps HTTP GET requests to this method for "/" path
    // This method returns a simple greeting message
    public String methodNameIsNotImportantButMustBeUnique() {
        return "Welcome to the Gambler API!";
    }

    // Define a controller to handle a GET request to return all the Gamblers
    //
    // We need:
    //   1. method return a list of all gamblers:  List<Gambler>
    //   2. DAO method that will return a list of gamblers: getGamblers()
    //   3. URL path: "/gamblers"
    //   4. HTTP method: GET

    // Tell the server that this method will handle GET requests
    //     for the URL path "/gamblers"
    @GetMapping("/gamblers")
    public List<Gambler> getAllGamblers() {
        // Call the DAO method to get all gamblers
        //   and return the list of gamblers it gives us
        return gamblerDao.getGamblers();
    }  // End getAllG

    // Define a controller method to handle a GET request to a specific Gambler by id
    //
    // We need:
    //   1. method return a gambler: Gambler object
    //   2. DAO method that will return a gambler by id: getGamblerById(int id)
    //   3. URL path: /gamblers/{id} --- {variable} is a placeholder for the id in the URL path
    //                               --- the path will look like /gamblers/12
    //                               --- a value included in the URL path is called a path variable
    //                               --- typically the path variable is the primary key of the data
    //                               ----    a primary key is a unique identifier for the data
    //   4. HTTP method: GET

    // This annotation maps HTTP GET requests to this method for "/gamblers/{id}" path
    @GetMapping("/gamblers/{id}")   // The {id} is a path variable
    // The @PathVariable annotation tells the server to extract the value of the path variable
    //     and pass it as a parameter to the method
    // For now the method paraeter and the path variable must have the same name
    public Gambler getGamblerById(@PathVariable int id) {
        // Call the DAO method to get the gambler by id
        //   and return the gambler it gives us
        return gamblerDao.getGamblerById(id);
    } // End of getGamblerById() method

    // Define a controller method to handle a GET request to a specific Gambler by name
    //
    // We need:
    //   1. method returns a gambler: Gambler object
    //   2. DAO method that will return a gambler by name: getGamblerByName(String name)
    //   3. URL path:  /gamblers?name={value} --- Because name is not the primary key (names may not be unique)
    //                                        ---    we are using a query parameter
    //                                        ---     instead of a path variable
    //                                        --- a query parameter is a key-value pair in the URL
    //                                        --- ? - indicates the start of query parameters (end of path)
    //                                        --- name={value} - is a query parameter placeholder
    //                                        --- /gamblers?name=Neil%20Bransfield
    //                                        ---    query parameter value may not contain spaces
    //                                        ---    code %20 (the URL encoding for a space character)
    //                                        ---      to represent a space in the URL
    //                                        --- & - separates multiple query parameters
    //   4. HTTP method: GET
    // Paths must be unique for an HTTP request
    //      so we cannot use the same path for the same HTTP request
    //      typically  descriptive word is used in the path to differentiate the request
    @GetMapping("/gamblers/search") // This maps the method to the URL path "/gamblers"
    // The @RequestParam annotation tells the server to
    //      extract the value of the query parameter "name"
    // For now, the name of the parameter in the method must match the name of the query parameter
    public Gambler getGamblerByName(@RequestParam String name) {
        // Call the DAO method to get the gambler by name
        //   and return the gambler it gives us
        return gamblerDao.getGamblerByName(name);
    } // End of getGamblerByName() method

}  // End of GamblerController class
