import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IFootwearDetails } from '../ifootwear-details';
import { FootwearDetailsService } from '../footwear-details.service';
import { getLocaleCurrencySymbol } from '@angular/common';

@Component({
  selector: 'app-footwear-details',
  templateUrl: './footwear-details.component.html',
  styleUrls: ['./footwear-details.component.css']
})
export class FootwearDetailsComponent implements OnInit {

  categoryId : any;
  footwearDetailsId : any;
  footwearDetailsData !: IFootwearDetails[];
  footwearDetails !: IFootwearDetails;

  constructor(private footwearDetailsService:FootwearDetailsService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get("id");
    this.footwearDetailsId = this.route.snapshot.paramMap.get("fid");
    this.viewFootwearDetails();
  }

  viewFootwearDetails(){
    this.footwearDetailsService.getFootwear(this.categoryId).subscribe(
      data => {
        this.footwearDetailsData = data;
        this.footwearDetails = data[this.footwearDetailsData.findIndex(x => x.id == this.footwearDetailsId)]
        console.log(this.footwearDetailsData);
      }
    )
  }

//  viewFootwearDetails(){
//     this.footwearDetailsService.getFootwearDetails(this.categoryId,this.footwearDetailsId).subscribe(
//       data => {
//         this.footwearDetailsData = data;
//       }
//     )
//   }

}
