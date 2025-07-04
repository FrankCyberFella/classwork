// To add a component to this component
//   1. import the component you to add in the .ts file
//   2. Add the import name to the imports property in @Component object in the .ts file
//   3. Add the component selector to the .html for this component

import { Component } from '@angular/core';
@Component({
  selector: 'home-page',
  standalone : true,  // Added so we can use the imports property
  imports: [],
  templateUrl: './homepage.html',
  styleUrl: './homepage.css'
})
export class Homepage {

}
