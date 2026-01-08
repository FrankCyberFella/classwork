// Created via ng g service services/pet.service
// Which makes it Dependency Injectable automatically
//       and creates an empty constructor
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PetService {

  constructor() { }
}
