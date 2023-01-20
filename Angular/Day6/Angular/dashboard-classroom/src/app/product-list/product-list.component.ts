import { Component, OnInit } from '@angular/core';
import { Iproduct } from '../iproduct';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list', // name of this component
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  productName: string = "";
  products: Iproduct[] = [];
  showImage: boolean = false;
  pagetTitle: string = "";
  constructor(private ProductServ: ProductService) { // service inject
  }

  ngOnInit(): void {
    this.ProductServ.getProducts().subscribe({
      next: products => {
        this.products = products;
      }
    })
  }

  toggleImage() {
    this.showImage = !this.showImage;
  }

  onRatingClicked(message: string) {
    this.pagetTitle = message;
  }


}
