package com.firstapi;

// This file contains controllercode to handle HTTP requests sent to this server

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

// The @RestController annotation indicates that this class has REST controllers in it
// REST stands for Representational State Transfer,
//      which is an architectural style for designing networked applications.
// REST is a type of API - Most popular type of API in the world.
@RestController
public class myController {

    // The @GetMapping annotation maps HTTP GET requests to the specified method.
    // the following method will handle GET requests to the path http://localhost:8081/
    //     localhost is name for any process running your computer
    //     8081 is the port number that the application is running on
    @GetMapping // This method will handle GET requests to the root URL ("/") or nothing
    public String anyName() { // the method name can be anything you want
        // All this control does is return a string that say "Hi There"
        return "Hi There";
    }
    // This method will handle GET requests to the path http://localhost:8081/welcome
    @GetMapping("/welcome")
    public String controllerMethodNamesDoNotEverMatter() {
        // This method returns a string that says "Welcome to my first API"
        return "Welcome to my first API";
    }
}
