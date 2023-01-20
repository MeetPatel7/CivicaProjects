import { Component,   VERSION } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent {

  public name = "Nitya";
  message:string='';

  constructor()
  {}
  
  ngOnInit(): void
  {}

  receiveData(msg:string)
  {
    this.message=msg;
  }
}
