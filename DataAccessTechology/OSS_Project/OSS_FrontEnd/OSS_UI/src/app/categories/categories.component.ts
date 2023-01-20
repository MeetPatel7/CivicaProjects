import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../categories.service';
import { ICategories } from '../icategories';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categoriesData !: ICategories[];

  constructor(private categoriesService:CategoriesService) { }

  ngOnInit(): void {
    this.viewCategories();
  }

  viewCategories(){
    this.categoriesService.getCategories().subscribe(
      data => {
        this.categoriesData = data;
        console.log(this.categoriesData);
      }
    )
  }
}
