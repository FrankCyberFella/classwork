/*
    Example of a multi-line comment just like in C#/Java
*/

// Single line comment

/*****************************************************************************
 * We test the JavaScript code using Inspect in the browser
 ****************************************************************************/

/**
 * Functions start with the word function.
 * They don't have a return type and the naming convention is camel-case.
 */
function variables() {
  // Declares a variable where the value cannot be changed
  const aVariable = 42;
  
  // console.log() - display data on the console (Console.WriteLine() or System.out.println()) 
  // JavaScript support interpolation to construct strings similar to C#
  //
  // Interpolation:  `words ${variable}`  C#: $(words {aVariable})
  console.log(`The value in aVariable is: ${aVariable}`)

  // Declares a variable those value can be changed

  let itBe = 87.4;
  console.log(`The value in itBe is: ${itBe}`)

  itBe = 1776;
  console.log(`The value in itBe is: ${itBe}`)

  

  // Declares a variable that will always be an array
  let stuff = ["things", 'Kevin', "Hello", 774.6]
  console.log(`The value in stuff is: ${stuff}`) // Display the array as a variable - elements separated by ,
  console.log(stuff)    // display the array name is shows the array and it's elements in a dropdown
  console.table(stuff)

}
function varTest() {
{ // variables defined in a block are usually only available inside the block or block within it
  let num = 10;  // NOT available outside this block
  var someVariable = 10;  // var defined variables is known outside the block it is defined within
}

    //let someVariable = 999;  // Causes an error due to redefining a var variable
    console.log(`someVariable contains: ${someVariable}`)
    console.log(`num contains: ${num}`)  // ERROR! Because num is defined outside the block 
                                        //        this statement in coded in     
}

/**
 * Functions can also accept parameters.
 * Notice the parameters do not have types.
 * @param {Number} param1 The first number to display
 * @param {Number} param2 The second number to display
 */
function printParameters(param1, param2) {
  console.log(`The value of param1 is ${param1}`);
  console.log(`The value of param2 is ${param2}`);
}

/**
 * Compares two values x and y.
 * == is loose equality - values are the same, but types don't matter
 * === is strict equality - values and the type must be teh same
 * @param {Object} x
 * @param {Object} y
 */
function equality(x, y) {
  console.log(`x is ${typeof x}`);  // typeof will return the data type of the variable
  console.log(`y is ${typeof y}`);

  console.log(`x ==  y : ${x == y}`);  
  console.log(`x === y : ${x === y}`); 
}

/**
 * Each value is inherently truthy or falsy.
 * Every value if used in a conditional statement will be true or false
 * false, 0, '', null, undefined, and NaN are always false
 * everything else is always true
 * @param {Object} x The object to check for truthy or falsy,
 */
function falsy(x) {
  if (x) {  // Use the parameter in a conditional statement
    console.log(`${x} is truthy`);
  } else {
    console.log(`${x} is falsy`);
  }
}

/**
 * JavaScript Objects are NOT the same as Object-Oriented Objects
 *  
 * Objects are simple key-value pairs - a way to structure data
    - values can be primitive data types
    - values can be arrays
    - or they can be functions

    JSON - JavaScript Object Notation - How we share data on between devices
*/
function objects() {
  const person = {          // JavaScript objects are enclosed in {}
    firstName: "James T.",  // attributes in are specified with name : value
    lastName: "Kirk",       // multiple values are separated by commas
    age: 42,                // Numbers are coded as human, non-numbers are inside "" or ''
    employees: [            // Arrays are enclosed in []
      "Spock",              // elements in the array are separated by commas
      "McCoy",
      "Uhura",
      "Scotty"
    ]
  };

  // Log the object - display the object
    console.log(person);  // This will display the data in a pretty easy to read format
    console.log(`person contains: ${person}`); // This doesn't display the data
    console.table(person);  // Formatted display
   
  // Log the first and last name  - accessing attributes in an object: objectName.attrinuteName

    console.log(`Person's first name: ${person.firstName}`)
    console.log(`          last name: ${person.lastName}`)

    console.log(formatPerson(person))   // call print person function to display a sentence about the data

  // Log each employee - iterate/Go through an array of objects
  // Just like in C# and Java we use a for-loop to go through an array
  
  //               arrayName.length is the numbers of element
  for(let i=0; i < person.employees.length; i++) {
    console.log(`Employee #${i+1}: ${person.employees[i]}`)
  }
}

function formatPerson(somePerson) {
  return `${somePerson.firstName} is ${somePerson.age} years old and their last name is ${somePerson.lastName}`
}

/*
########################
Function Overloading
########################

In C# and Java Function Overloading is when functions have the same name, but different parameters
and the compiler determines which function to call based on the data types of the parameters

In C#/Java function overloads are used for multiple constructors of a class

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overridden and the most recent one will be used.
*/

function Add(num1, num2) { // This function is overridden by the one defined below
  return num1 + num2;      // it will never be called
}

function Add(num1, num2, num3) { // This function overrides any previously defined with the same name
  return num1 + num2 + num3;
}

/*
########################
Math Library
########################

A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
  console.log("Math.PI : " + Math.PI);
  console.log("Math.LOG10E : " + Math.LOG10E);
  console.log("Math.abs(-10) : " + Math.abs(-10));
  console.log("Math.floor(1.99) : " + Math.floor(1.99));
  console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
  console.log("Math.random() : " + Math.random());
 
}

/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {
  console.log(`.length -  ${value.length}`);
  console.log(`.endsWith('World') - ${value.endsWith("World")}`);
  console.log(`.startsWith('Hello') - ${value.startsWith("Hello")}`);
  console.log(`.indexOf('Hello') - ${value.indexOf("Hello")}`);

  console.log(`.split(value, ' ') - ${value.split(" ")}`);
  console.table(value.split(" "))

  // Both substr and substring start at character 0 (sae as C#/Java) 

  // Extract 5 chars starting at position 2 from the string using substr(start-pos, #-of-chars)
             console.log(`value.substr(5,9) - ${value.substr(5,9)}`);

  // Extract chars 2 & 3 from the string using substring(start-pos, end-pos)
  //         substring will return characters up to but not including the character at end-pos
  console.log(`value.substring(5,9) - ${value.substring(5,9)}`);

   /* Other Methods
        - split(string)
        - substr(number, number)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
}

/*
 ###################################
  Array Manipulation Functions
 ###################################
*/
function arrayFunctions() {


let stooges = [              // Define a JavaScript array
              "Moe",
              "Larry",
              "Curly"
              ]
console.table(stooges) // Display array as formatted display

// JavaScript array is like a List in C# or ArrayList in Java

stooges.push("Shemp")  // Add an element to the end of the array
console.table(stooges) // Display array as formatted display

stooges.unshift("Curly Joe")  // Add an element to the start of the array
console.table(stooges)        // Display array as formatted display

// To insert into an array: splice(start-index, 0, "new-elements")

stooges.splice(3,0, "Groucho", "Chico", "Harpo") // insert elements before index 3
console.table(stooges)        // Display array as formatted display

// To delete elements into an array: splice(start-index, #-elems-to-delete)

stooges.splice(3,1)       // delete the element at index 3
console.table(stooges)    // Display array as formatted display

stooges.splice(3,2)       // delete 2 elements at index 3
console.table(stooges)    // Display array as formatted display

// shift() will remove the first element in the array and return it
// splice(0,1) will remove the first element in the array and NOT return it as an element
stooges.shift()           // delete first element and return it
console.table(stooges)    // Display array as formatted display

stooges.pop()           // delete last element and return it
console.table(stooges)  // Display array as formatted display

let marxBros = [
               "Groucho",
               "Chico",
               "Harpo"
               ]

// combine arrays using .concat()
let oldFunnyGuys = stooges.concat(marxBros);
console.table(oldFunnyGuys);    

}