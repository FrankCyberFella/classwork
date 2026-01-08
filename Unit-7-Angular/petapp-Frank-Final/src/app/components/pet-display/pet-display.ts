import { Component }  from '@angular/core';
import { PetInfo }    from '../../interfaces/pet-info';
import { PetService } from '../../services/pet.service';
  import { CommonModule } from '@angular/common';

  @Component({
    selector: 'pet-display', // name used in the html tag to reference the component
    imports: [CommonModule],
    templateUrl: './pet-display.html',
    styleUrl: './pet-display.css'
  })
export class PetDisplay {
// We need to be sure we have a copy of the data so our htm can use it
// Call the service that has the data to get the data

ourPetInfo : PetInfo[]

constructor(thePetData : PetService) {
this.ourPetInfo  = thePetData.getPetData();
}
}
