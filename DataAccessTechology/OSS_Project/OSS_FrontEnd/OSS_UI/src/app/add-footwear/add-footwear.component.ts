import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FootwearDetailsService } from '../footwear-details.service';
import { IFootwearDetails } from '../ifootwear-details';

@Component({
  selector: 'app-add-footwear',
  templateUrl: './add-footwear.component.html',
  styleUrls: ['./add-footwear.component.css']
})
export class AddFootwearComponent implements OnInit {

  allFootwear !: IFootwearDetails[];
  footwearDetailsId !: number;
  footwearData !: IFootwearDetails[];
  footwearDataById !: any;

  constructor(public footwearDatailsService:FootwearDetailsService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.footwearDetailsId = Number(this.route.snapshot.paramMap.get("id"));
    this.viewAllFootwear();
  }

  populateForm(data: any) {
    this.footwearDatailsService.footwearForm = Object.assign({}, data);
  }

  insertFootwear(footwearForm:NgForm)
  {
    this.footwearDatailsService.postFootwearDetails(footwearForm.value).subscribe(
      data => {
        this.footwearDatailsService.footwearForm;
        alert("Record Inserted");
      }
    )
  }

  updateFootwear(form:NgForm)
  {
    this.footwearDatailsService.putFootwearDetails().subscribe(
      data => {
        alert("record has been Updated");
      }
    )
  }

  viewAllFootwear()
  {
    this.footwearDatailsService.getAllFootwear().subscribe(
      data => {
        this.allFootwear = data;
        console.log(this.allFootwear);
      }
    )
  }

  deleteFootwear(id:number)
  {
    this.footwearDatailsService.deleteFootwearDetails(id).subscribe(
      data => {
        alert("record Has deleted");
      }
    )
  }

  onSubmit(form: NgForm) {
      if (this.footwearDatailsService.footwearForm.id == 0)
        this.insertFootwear(form);
  
      else
        this.updateFootwear(form);
    }
}

