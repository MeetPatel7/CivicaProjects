import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { HelloComponent } from './hello/hello.component';
import { FormsModule } from '@angular/forms';
import { ConvertToSpacesPipe } from './convert-to-spaces.pipe';
import { ProductFilterPipe } from './product-filter.pipe';
import { StarComponent } from './star/star.component';
import { HttpClientModule } from '@angular/common/http';
import { UsersListComponent } from './users-list/users-list.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    LoginComponent,
    ProductListComponent,
    HelloComponent,
    ConvertToSpacesPipe,
    ProductFilterPipe,
    StarComponent,
    UsersListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [ProductListComponent] // default component
})
export class AppModule { }
