import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Iproduct } from '../iproduct';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: any;
  constructor(private route: ActivatedRoute, private productServ: ProductService) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id')); // getting id from url
    this.getProduct(id); // get product by id
  }

  getProduct(id: number): void {
    this.productServ.getProduct(id).subscribe({
      next: product => this.product = product // assigning to product property
    })
  }

}
