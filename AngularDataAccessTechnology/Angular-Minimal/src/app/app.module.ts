import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { BindingComponent } from './reactives/binding/binding.component';
import { TempletebindingComponent } from './templete/templetebinding/templetebinding.component';

@NgModule({
  declarations: [
    AppComponent,
    BindingComponent,
    TempletebindingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
