import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppChildComponent } from './app-child/app-child.component';

@NgModule({
  declarations: [
    AppComponent,
    AppChildComponent
    
  ],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class MainModule { }
