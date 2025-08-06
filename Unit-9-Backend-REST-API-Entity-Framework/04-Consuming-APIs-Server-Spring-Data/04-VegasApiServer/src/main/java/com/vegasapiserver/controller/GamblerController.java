package com.vegasapiserver.controller;
// Anything associated with the server must be in the same package as the server
//     so the server can find it.
// Server, Controller, DAOs, POJO Model Class for data, Service, Repository, et al
//      are all in the same package as the server

// controllers contain methods that handle HTTP requests
// When the server receives a request,
//            it will route it to the appropriate controller

import com.vegasapiserver.dao.memory.GamblerDAO.GamblerMemoryDao;
import com.vegasapiserver.model.Gambler;
import org.springframework.web.bind.annotation.*;

import java.sql.Timestamp;
import java.text.ParseException;
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
@RequestMapping("/v1")
public class GamblerController {
    // This is where you will define your controller methods
    // Controller methods are the methods that handle HTTP requests
    // They are annotated with @GetMapping, @PostMapping, @PutMapping, @DeleteMapping, etc.

    // Usually controller methods are not very big and have no logic except for error handling
    // A typical controller:
    //
    //   1. Receives a request
    //   2. Retrieves any parameters passed in the URL (path variables or query parameters)
    //   3. Call the DAO to get the data
    //   4. Return the data retrieved from the DAO
    //

    // Data members for a class are defined outside any class (at the top)
    //    so all methods in the class can access them

    // Define a reference to the GamblerDAO so we can use it's methods to get data
    private GamblerMemoryDao gamblerDao;

    // Constructor to initialize the GamblerDAO
    public GamblerController() throws ParseException {
        // Instantiate the GamblerDAO object and assign it to the reference
        this.gamblerDao = new GamblerMemoryDao();
    }


    // Define a controller to handle a GET request to the root URL ("\" or nothing)
    // This method will return a simple greeting message
    // This annotation maps HTTP GET requests to this method for "/" or "/home" or nothing path
    @GetMapping({"","/","/home"}) // This annotation maps HTTP GET requests to this method for "/" path
    // This method returns a simple greeting message
    public String methodNameIsNotImportantButMustBeUnique() {
        logRequest("GET\trequest for /v1 or /home or nothing");
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
        logRequest("GET\trequest for /v1/gamblers");
        // Call the DAO method to get all gamblers
        //   and return the list of gamblers it gives us
        return gamblerDao.getGamblers();
    }  // End getAllGamblers

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
        logRequest("GET\trequest for /v1/gamblers/"+id);
        // Call the DAO method to get the gambler by id
        //   and return the gambler it gives us
        return gamblerDao.getGamblerById(id);
    } // End of getGamblerById() method

    // Define a controller method to handle a GET request to a
    //    specific Gamblers whose name contains a specified value
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
    public List<Gambler> getGamblerByName(@RequestParam String name) {
        logRequest("GET \trequest for /v1/gamblers/search?name="+name);
        // Call the DAO method to get the gambler by name
        //   and return the gambler it gives us
        return gamblerDao.getGamblerByName(name);
    } // End of getGamblerByName() method

    // Add a Gambler to the data source
    //   1. method returns a gambler: Gambler object that was added
    //   2. DAO method that add a Gambler: addGambler(aGambler)
    //   3. URL path:  /gamblers
    //   4. HTTP method: POST  --- POST HTTP request is used to add an object a data source
    //                         --- The data to be handled by the API is sent the request body for a POST
    //                         --- We retrieve the data from request with @RequestBody
    //                         --- @RequestBody will:
    //                         ---     1. Retrieve the JSON data from the body of the request
    //                         ---     2. Instantiate and object of the class given
    //                         ---     3. Use the standard named setters for the class to initialize the object
    //                         ---        The attribute names in the JSON stored in the request body
    //                         ---           must match the variable names in the class
    //                                    The JSON attribute name is used to construct the setter name
    //                         --            standard setter names: setVariableName
    @PostMapping("/gamblers")  // This method will handle a POST request for the URL "/gamblers"
    public Gambler addToDataSource(@RequestBody Gambler newGambler) {
        logRequest("POST\trequest for /v1/gamblers and object: " + newGambler);
        return gamblerDao.addGambler(newGambler);  // Call the DAO method to add the Gambler to the data source
    }

    // Update a Gambler to the data source
    //   1. method returns a gambler: Gambler object that was update
    //   2. DAO method that update a Gambler: updateGambler(aGambler)
    //   3. URL path:  /gamblers
    //   4. HTTP method: PUT   --- PUT HTTP request is used to update an object a data source
    //                         --- The data to be handled by the API is sent the request body for a PUT
    //                         --- We retrieve the data from request with @RequestBody
    //                         --- @RequestBody will:
    //                         ---     1. Retrieve the JSON data from the body of the request
    //                         ---     2. Instantiate and object of the class given
    //                         ---     3. Use the standard named setters for the class to initialize the object
    //                         ---        The attribute names in the JSON stored in the request body
    //                         ---           must match the variable names in the class
    //                                    The JSON attribute name is used to construct the setter name
    //                         --            standard setter names: setVariableName
    @PutMapping("/gamblers")
    public Gambler updateAObject(@RequestBody Gambler updatedGambler) {
        logRequest("PUT\trequest for /v1/gamblers and object: " + updatedGambler);
        return gamblerDao.updateGambler(updatedGambler);
    }

    // Delete a Gambler to the data source
    //   1. method returns a gambler: nothing
    //   2. DAO method that delete a Gambler: zapAGambler(aGambler)
    //   3. URL path:  /gamblers/{id}  -- path variables are usually used to indicate a primary key
    //   4. HTTP method: DELETE        --- DELETE HTTP request is used to delete an object a data source

    @DeleteMapping("/gamblers/{id}")  // Path variable called id in the URL
    public void removeAGambler(@PathVariable int id) { // parameter name must match the path variable for now
        logRequest("DEL\trequest for /v1/gamblers/" + id);
        gamblerDao.zapAGambler(id);  // Call the DAO to delete the object using teh id passed to us
    }

    /**
     * Log timestamp of request and request
     * @param message
     */
    static void logRequest(String message) {
        Timestamp timestamp = new Timestamp(System.currentTimeMillis());

        System.out.println(timestamp + " - " + message);
    }
}  // End of GamblerController class
