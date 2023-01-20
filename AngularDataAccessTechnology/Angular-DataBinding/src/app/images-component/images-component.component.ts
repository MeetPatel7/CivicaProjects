import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-images-component',
  templateUrl: './images-component.component.html',
  styleUrls: ['./images-component.component.css']
})
export class ImagesComponentComponent implements OnInit {

  image!:any[];
  imgName:any;
  imgPath:any;
  binding:any;

  constructor() { }

  ngOnInit(): void {
    this.image = [
      {
        imgName:"Italian",imgPath:"./assets/images/italian.png"
      },      
      {
        imgName:"Margerita",imgPath:"./assets/images/margerita.png"
      },
      {
        imgName:"Mexican",imgPath:"./assets/images/mexican.png"
      }

    ] 
  }

}
