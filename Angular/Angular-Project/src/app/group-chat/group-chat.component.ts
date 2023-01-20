import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-group-chat',
  templateUrl: './group-chat.component.html',
  styleUrls: ['./group-chat.component.scss']
})
export class GroupChatComponent implements OnInit {
  id: any;
  username: any;
  groupchatdata: any;
  getChatFromLocalStorage: any;
  user: any;
  groupchatuser: any;
  groupchatForm!: FormGroup

  constructor(private fb: FormBuilder, private activatedroute: ActivatedRoute) { }

  ngOnInit(): void {

    const messages = localStorage.getItem('groupchatLocalStorage');
    this.groupchatdata = messages != null ? JSON.parse(messages) : [];

    this.activatedroute.queryParams.subscribe((params: any) => {
      this.id = params.id;
    });

    const registerdata = localStorage.getItem('registerLocalStorage');
    this.user = registerdata != null ? JSON.parse(registerdata) : [];

    const userdata = this.user.filter((users: any) => {
      return this.id == users.id;
    });

    this.username = userdata[0].fullname;
    this.groupchatForm = this.fb.group({
      message: ['']
    })
  }

  savechat(): void {
    var chatInfo = {
      id: "M" + Number(new Date),
      datetime: new Date(),
      'username': this.username,
      'message': this.groupchatForm.value.message
    };

    this.getChatFromLocalStorage = JSON.parse(localStorage.getItem('groupchatLocalStorage')!);
    this.groupchatuser = this.getChatFromLocalStorage ? this.getChatFromLocalStorage : [];
    this.groupchatuser.push(chatInfo);
    localStorage.setItem("groupchatLocalStorage", JSON.stringify(this.groupchatuser));
    this.ngOnInit();
  }
}
