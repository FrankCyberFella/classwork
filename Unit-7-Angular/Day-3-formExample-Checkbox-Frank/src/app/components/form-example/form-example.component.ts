import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { throwError } from 'rxjs';

@Component({
  selector: 'form-example',  // Name used in html to reference the component <form-example>
  standalone: true,
  imports: [FormsModule,    // Tell Angular we want Forms support for this code
            CommonModule],  // Tell angular we are using common processing like *ngFor
  templateUrl: './form-example.component.html',
  styleUrl: './form-example.component.css'
})
// Allow access to stuff defined this component from outside the component
export class FormExampleComponent {
  // Data to be shared with the Angular when processing the web page
  buttonClicked = false
  firstName = ""     // hold the data from first name from the form
  lastName = ""      // hold the data from last name from the form
  birthday = ""      // hold the data from birthday from the form
  foodPreference = ""
  emailAddress = ""
  sendEmail = ""
  // A checkbox control may have multiple values (many checkboxes can be checked)
  // sports is specified as a checkbox it's data will be returned as an array
  // With each element in the array corresponding to a choice
 
  // Define an array to hold the checkbox values
  // Each element in the array of objects with two properties
  //
  //    name:  what is displayed
  //    value: what is returned when th checkbox is checked
  sports : any[] = [ // any type is used to mae the array flexible - hold kind of data
    {name: 'European Football', value: "Soccer"},
    {name: 'Cricket'          , value: "Cricket"},
    {name: 'American Football', value: "Football"},
    {name: 'Baseball'         , value: "Baseball"},
    {name: 'Hockey'           , value: "Hockey"},
    {name: 'Other'            , value: "Other Sport"},
    {name: 'None'             , value: "None"}
  ]
  
 // Methods to handle interactions with the html/web page
  onSubmit() { // Handle the Submit button click on the  form
    this.buttonClicked = true
    console.log(`OK.... You Clicked Submit`)
    console.log(`You entered ${this.firstName} in the First Name field`)
    console.log(`You entered ${this.lastName} in the Last Name field`)
    console.log(`You entered ${this.emailAddress} in the email field`)
    //console.log(`You entered ${this.sports} as sports you like`)
    //console.table(this.sports)

    // Only display checkbox items that were checked
    // Loop through the checkbox array and find all the checkboxes where checked is true
    // Call function to return all the checkboxes that were checked
    //console.table(this.checkBoxResult)  // This will call a function named checkBoxResults and display as array

    // Display each item checked on line by itself
    console.log("You indicated you like the following sports: ")
    // Loop through an array of items checked and display them
    //
    // .forEach() - an array function that will loop through an array passing each element to an arrow function (=>)

    // Use checkBoxResult() function to get an array ot checked items
    //     then give the array to .forEach() to display each item
    this.checkBoxResult.forEach((aBox) => console.log(aBox.name))


  }  // End of onSubmit() function

 // This function will return an array of checkbox items that were checked
 // We designate it as "get" because it is returning something
  get checkBoxResult()  {

    // Loop through the checkbox array (called sports)
    // if an item has checked=true, save for return when done
    // When the loop is done, return all the items where checked was true
    //
    // .filter() is an array function that will go through an array one element at a time
    //           using an arrow (=>) function to tell it whether the current element
    //           should be saved in a new array
    //
    //           if the arrow (=>) returns true, the current element is saved in a new array
    //           
    //           After all elements in the array are processed, it returns the array it saved elements in
    return this.sports.filter((aCheckBox) => aCheckBox.checked)
  } // End of checkBoxResult() function

   // This function will check (or uncheck) all items in the checkbox list
  CheckAllOptions() {
    // if all checkboxes are checked - uncheck them all
    if(this.sports.every((aCheckBox) => aCheckBox.checked == true)) {
      // Go through all the checkboxes in the array and uncheck them
      this.sports.forEach((anElement) => anElement.checked = false)
    }
    else { // if all checkboxes are unchecked - check them all
      this.sports.forEach((aBox) => aBox.checked = true)

    }
    
  }

} // end of export