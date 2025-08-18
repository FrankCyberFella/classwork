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
export class App implements OnInit {

  protected title = 'Day-2-Gambler-App-V2';

  constructor(private gamblerApiService : GamblerApiService) {}

  theGamblers : any[] = [];

  newGambler : GamblerDataLayout = {
                                      id: 0,
                                      name: "",
                                      address: "",
                                      salary : 0,
                                      birthDate : ""
                                   }

  async ngOnInit() 
  {
  this.theGamblers = await this.gamblerApiService.getAllGamblers();
  }
  
  async addGambler(newGambler : GamblerDataLayout) {
    await this.gamblerApiService.addGambler(newGambler)
    this.theGamblers = await this.gamblerApiService.getAllGamblers()
  }
  
 

}
