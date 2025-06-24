//This starts the Angular application
// when you do ng serve it looks for main.ts to start app
// This is where you define the component representing the home page

import { bootstrapApplication } from '@angular/platform-browser';  // Starts the Angular app
import { appConfig } from './app/app.config';                      // Angular app configurion information

// Specify the folder containing the home page and its name

// import {name-used-in-this-code} from 'path-to-the-component-files'
// The component path contains folder and high-level name of the component
// The component path is relative to src folder
// ./app/app
//
// . - the folder you are in (src folder)
// /app - the folder named app in the folder you are in
// /app - all files related to the component will start with 'app'
//        .component is assume
// The name of the import must match an export class in a Typescript file
import {App} from './app/app'; // Get the Angular component stuff from './app/app'

// Clearer coding technique
//import { App } from './app/app.component'; // Get the Angular component stuff from './app/app'

// bootstrapApplication function is what the Angular server calls to start the app
// Give it: (name-of-import-for-component, configuration)
bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));
