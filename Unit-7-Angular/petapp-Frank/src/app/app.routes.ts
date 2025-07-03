import { Routes } from '@angular/router';
import { Homepage } from './components/homepage/homepage';
// Routes object is an array of paths associated with components
// If you DON'T change the array name from 'routes' to something else, you're done
// (Just add the paths)
// If you change the array name from routes, YOU MUST MAKE CHANGES IN app.config.ts
export const routes: Routes = [
    // Associate a path to a component - use name of import for the component 
    {path: 'home',     component: Homepage}
];
