import { Component }         from '@angular/core';
import { GamblerDataLayout } from './interfaces/GamblerDataLayout';
import { Router }            from '@angular/router';
import { GamblerApiService } from './services/gambler-api-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'gamblerApp';

// Data for the app which will be initialized from the API Server
 public  theGamblers : GamblerDataLayout[] = []

// Define an object to hold new gambler data
newGambler : GamblerDataLayout = {
          id      : 0,
        name      : "",
        address   : "",
        salary    : 0,
        birthDate : ""
}


// Have the service Dependency Injected into the code
// Note: service object needs to be defined private
constructor (private gamblerService : GamblerApiService
            ,private router        : Router) {
              console.log("In constructor...")
             }
               
        
// ngOnInit() is executed before the constructor
// So its a great place to get the data from the API
//    to make the data available to all places in the component 
async ngOnInit()
{
  console.log("In ngOnInit...")
  await this.getDataFromAPI()
  window.location.reload() 
//  this.theGamblers = await this.gamblerService.getAllTheGambler();
//  console.table(this.theGamblers) // Optional for debugging
}

async getDataFromAPI() {
  this.theGamblers = await this.gamblerService.getAllTheGambler();
  console.table(this.theGamblers) // Optional for debugging
}


// Define a method to call a service method to store new gambler in the API
 async addGambler(newGambler : GamblerDataLayout) {
  await this.gamblerService.addGamblerToApi(newGambler)  // Call the service to store new object
                         
  this.theGamblers = await this.gamblerService.getAllTheGambler() // Refresh the data

  // this.getDataFromAPI()
} 

}
