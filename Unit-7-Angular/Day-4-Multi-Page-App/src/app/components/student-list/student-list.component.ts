// Generated by ng generate component command
// It has the basic/starter code for a component 

import { CommonModule } from '@angular/common';
import { Component }    from '@angular/core';   // Give me access to common Angular features like *ngFor

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
// export contains data and functions used by the html for the component
export class StudentListComponent {

  roster : any[] = [
    {name: "Youssef"},
    {name: "Zach"},
    {name: "Henrik"},
    {name: "Amber"},
    {name: "Ravyn"}
  ]

}
