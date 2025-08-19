import { Component, OnInit } from '@angular/core';
import { GamblerApiService } from './services/gambler-api-service';
import { CommonModule }      from '@angular/common';
import { GamblerDataLayout } from './interfaces/GamblerInfoLayout';
import { FormsModule }       from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
// Use of ngOnInit() requires implements OnInit on the compnet class
export class App implements OnInit {

  protected title = 'Day-2-Gambler-App-V2';

  // Name the service objectand have it dependency injected into component processing
  constructor(private gamblerApiService : GamblerApiService) {}

  // define a data structure to hold the for the component
  // (data comes from APU calls)
  theGamblers : any[] = [];

  // If you wil be adding to teh API data source
  // define an object to hold the data to be added

  newGambler : GamblerDataLayout = {
                                      id: 0,
                                      name: "",
                                      address: "",
                                      salary : 0,
                                      birthDate : ""
                                   }
// ngOnInit() is run when Angular start processing the page
// Typically this is where you call the API to get the initial 
//           copy of the data from the data source
  async ngOnInit() 
  {
  this.theGamblers = await this.gamblerApiService.getAllGamblers();
  }
  
  async addGambler(newGambler : GamblerDataLayout) {
    // Call the API to add the new object to the data source
    await this.gamblerApiService.addGambler(newGambler)
    // Refresh the data in the component tp get the new data
    // (You could also add the new object the data source yourself)
    //  theGamblers.add(newGambler)
    this.theGamblers = await this.gamblerApiService.getAllGamblers()
  }
  
 

}
