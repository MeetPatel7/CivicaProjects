import { Component, OnInit, Input } from '@angular/core';
import { IRegister } from '../iregister';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  @Input() id: any;
  //userdata: IRegister[] = [];
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    console.log(this.id);
  }

}
