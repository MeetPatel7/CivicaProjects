import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddFootwearComponent } from './add-footwear/add-footwear.component';
import { AppComponent } from './app.component';
import { CategoriesComponent } from './categories/categories.component';
import { FootwearDetailsComponent } from './footwear-details/footwear-details.component';
import { FootwearComponent } from './footwear/footwear.component';

const routes: Routes = [
  {
    path : '', component:CategoriesComponent
  },
  {
    path : 'Categories', component:CategoriesComponent
  },
  {
    path : 'Categories/:id/FootwearDetails', component:FootwearComponent
  },
  {
    path : 'Categories/:id/FootwearDetails/:fid', component:FootwearDetailsComponent
  },
  {
    path : 'AddFootwear', component:AddFootwearComponent
  },
  {
    path : 'ViewFootwear/AddFootwear/:id', component:AddFootwearComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
