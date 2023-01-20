import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule }from '@angular/common/http';
import { CategoriesComponent } from './categories/categories.component';
import { FormsModule } from '@angular/forms';
import { FootwearComponent } from './footwear/footwear.component';
import { FootwearDetailsComponent } from './footwear-details/footwear-details.component';
import { AddFootwearComponent } from './add-footwear/add-footwear.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoriesComponent,
    FootwearComponent,
    FootwearDetailsComponent,
    AddFootwearComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
