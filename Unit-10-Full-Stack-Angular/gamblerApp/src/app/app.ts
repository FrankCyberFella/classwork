import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomePage } from "./components/home-page/home-page";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HomePage],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'gamblerApp';
}
