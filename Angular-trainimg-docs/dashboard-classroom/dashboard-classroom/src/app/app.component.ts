import { Component } from '@angular/core';

@Component({ // decorator
  selector: 'app-root', // name for this component
  templateUrl: './app.component.html', // html
  styleUrls: ['./app.component.scss'] // css
})
export class AppComponent {
  title = 'dashboard';
  message: string = "Programming with Harsh";  // property
}

// component = template + class (properties and method) + metadata
