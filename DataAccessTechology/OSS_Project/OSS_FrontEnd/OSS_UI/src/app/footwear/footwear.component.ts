import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FootwearDetailsService } from '../footwear-details.service';
import { IFootwearDetails } from '../ifootwear-details';

@Component({
  selector: 'app-footwear',
  templateUrl: './footwear.component.html',
  styleUrls: ['./footwear.component.css']
})
export class FootwearComponent implements OnInit {

  categoryId : any;
  footwearData !: IFootwearDetails[];
  //footwear !: IFootwearDetails[];

  constructor(private footwearDetailsService:FootwearDetailsService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get("id");
    console.log(this.categoryId);
    this.viewFootwear();
  }

  viewFootwear(){
    this.footwearDetailsService.getFootwear(this.categoryId).subscribe(
      data =>{
        this.footwearData = data;
        //this.footwear = data[this.footwearData.findIndex(x => x.CategoryId == this.categoryId)];
        console.log(this.footwearData);
      }
    )
  }

}
