import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './department/department.component';
import { EmployeeComponent } from './employee/employee.component';
import { AppRoutingModule } from './app-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    EmployeeComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
