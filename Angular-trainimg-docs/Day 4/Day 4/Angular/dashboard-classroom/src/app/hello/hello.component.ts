import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-hello',
  templateUrl: './hello.component.html',
  styleUrls: ['./hello.component.scss']
})
export class HelloComponent implements OnInit {

  products: any;
  constructor(private productServ: ProductService) { }

  ngOnInit(): void {
    this.products = this.productServ.getProducts();
  }

}
