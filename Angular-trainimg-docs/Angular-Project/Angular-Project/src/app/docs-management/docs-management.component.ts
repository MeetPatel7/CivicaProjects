import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-docs-management',
  templateUrl: './docs-management.component.html',
  styleUrls: ['./docs-management.component.scss']
})
export class DocsManagementComponent implements OnInit {

  myuploads:any;
  shareduploads:any;
  constructor() { }

  ngOnInit(): void {
    this.myuploads=[
      {
        label:"Sales Report",
        filename:"sale-Sep2014.xls"
      },
      {
        label:"Quaterly Summary",
        filename:"SummaryQ4-2014.ppt"
      },
      {
        label:"Projection 2013-14",
        filename:"SalesProfitProjection.xls"
      }
    ]

    this.shareduploads=[
      {
        label:"Sales Team Attendance Sept 2014",
        filename:"Sale-Attend-Sep2014.xls",
        sharedby:"rk@gmail.com"
      },
      {
        label:"Office Rules",
        filename:"OfficeRule.doc",
        sharedby:"hp@gmail.com"
      },
    ]
  }

}
