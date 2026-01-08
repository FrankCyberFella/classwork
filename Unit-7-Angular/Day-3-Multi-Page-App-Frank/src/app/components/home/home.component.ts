import { Component } from '@angular/core';

@Component({
  selector: 'home-page',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  pageTitle = 'Welcome to Grand Circus AHBC March, 2025 -  Angular App';
  rightnow  = Date();
  currentdatetime = Date().substring(0,15);
}
