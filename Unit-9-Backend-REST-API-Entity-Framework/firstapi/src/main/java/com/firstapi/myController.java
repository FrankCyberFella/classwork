package com.firstapi;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class myController {

    @GetMapping
    public String anyName() {
        return "Hi There";
    }
}
