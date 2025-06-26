import { Component } from '@angular/core';
// You must import any component you use in this component
// import for external component - may be automatically added by IDE
import { FormExampleComponent } from './components/form-example/form-example.component';
// @Component identifies all the Angular stuff you are using
//            including new components
@Component({
  selector: 'app-root',  // the name of the tag used in html to reference teh component
  standalone: true,
  // imports identifies external resources, like components, used in the app
  imports: [FormExampleComponent],      // Note the import name used here
  templateUrl: './app.component.html',  // The file containing the html for the component
  styleUrl:    './app.component.css'    // The file containing the css for the component
})
// export allows processes outside this component to access things defined in the component 
// any data or methods you want Angular to use must be export'd from Typescript file for the component
// To use One-Way Binding for data defined in this code in the HTML:  {{variable-name}}
export class AppComponent {
  pageHeading = "Welcome to Frank's AHBC - C#/Java - Contact Info Submission"
}
