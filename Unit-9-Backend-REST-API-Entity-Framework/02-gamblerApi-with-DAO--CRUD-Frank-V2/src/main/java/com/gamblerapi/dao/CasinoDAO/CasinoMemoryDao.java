package com.gamblerapi.dao.CasinoDAO;

import com.gamblerapi.model.Casino;

import java.util.ArrayList;
import java.util.List;

public class CasinoMemoryDao {

    // Define the data source
    List<Casino> theCasinos;

    // Constructor
    public CasinoMemoryDao() {
        this.theCasinos = new ArrayList<Casino>();
    }

    // Getter
    public List<Casino> getTheCasinos() {
        return theCasinos;
    }
}
