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

        theCasinos.add(new Casino("Caesers Palace"   , "Las Vegas"    , "Julius Caeser"    , 40000));
        theCasinos.add(new Casino("Harveys Casino"   , "Lake Tahoe"   , "Harvey Wallbanger", 28000));
        theCasinos.add(new Casino("Ballys"           , "Reno"         , "Bill Bally"       , 31500));
        theCasinos.add(new Casino("Trump Plaza"      , "Atlantic City", "Donut Trump"      , 22800));
        theCasinos.add(new Casino("Binions Horseshoe", "Las Vegas"    , "Fred Binyawn"     , 16900));
    }

    // Getter
    public List<Casino> getTheCasinos() {
        return theCasinos;
    }
}
