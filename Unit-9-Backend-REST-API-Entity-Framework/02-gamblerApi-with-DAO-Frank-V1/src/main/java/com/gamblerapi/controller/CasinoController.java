package com.gamblerapi.controller;

import com.gamblerapi.dao.CasinoDAO.CasinoMemoryDao;
import com.gamblerapi.model.Casino;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController  // Tell the server thi class has controller methods
public class CasinoController {

    // Define the data source
    CasinoMemoryDao casinoDataSource;

    // Constructor
    public CasinoController() {
        this.casinoDataSource = new CasinoMemoryDao();
    }

    // Provide a method to return all the casinos
    @GetMapping("/casinos")
        public List<Casino> getCasinos() {
            return casinoDataSource.getTheCasinos();
        }
}
