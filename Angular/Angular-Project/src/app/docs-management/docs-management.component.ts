import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-docs-management',
  templateUrl: './docs-management.component.html',
  styleUrls: ['./docs-management.component.scss']
})
export class DocsManagementComponent implements OnInit {

  getUploadDocumentFromLocalStorage: any;
  userUploadedDocument: any;
  id: any;
  fileuploadForm!: FormGroup;
  userUploadedData: any;
  getItemFromLocalStorage: any;
  userUploadDocument: any;
  shareduploads: any;

  constructor(private router: Router, private route: ActivatedRoute, private activatedroute: ActivatedRoute, private fb: FormBuilder) {

  }

  ngOnInit(): void {

    const getUserUploadedData = localStorage.getItem('UploadDocumentLocalStorage');
    let usersdata = getUserUploadedData != null ? JSON.parse(getUserUploadedData) : [];

    this.activatedroute.queryParams.subscribe((params: any) => {
      this.id = params.id;
    });

    this.userUploadedData = usersdata.filter((users: any) => {
      return this.id == users.userid;
    });

    this.fileuploadForm = this.fb.group({
      filedescription: ['', [Validators.required]],
      fileupload: ['', [Validators.required]]
    })
  }

  fileupload() {

    var uploaddocumentInfo = {
      uploadid: "U" + Number(new Date),
      userid: this.id,
      'filedescription': this.fileuploadForm.value.filedescription,
      'fileupload': this.fileuploadForm.value.fileupload
    };

    this.getUploadDocumentFromLocalStorage = JSON.parse(localStorage.getItem('UploadDocumentLocalStorage')!);
    this.userUploadedDocument = this.getUploadDocumentFromLocalStorage ? this.getUploadDocumentFromLocalStorage : [];
    this.userUploadedDocument.push(uploaddocumentInfo);
    localStorage.setItem("UploadDocumentLocalStorage", JSON.stringify(this.userUploadedDocument));

    this.ngOnInit();
  }

  deleteFile() {

    let userdocid: any = null;
    this.route.queryParams.subscribe((param: any) => {
      userdocid = param.docid;
    });

    const getUserUploadedData = localStorage.getItem('UploadDocumentLocalStorage');
    const user = getUserUploadedData != null ? JSON.parse(getUserUploadedData) : [];

    const foruserid = user.filter((users: any) => {
      return userdocid == users.uploadid;
    });

    let currentuserid = foruserid[0].userid;

    const a = user.findIndex((a: any) => a.uploadid == userdocid);
    user.splice(a, 1);
    localStorage.setItem("UploadDocumentLocalStorage", JSON.stringify(user));

    this.router.navigate(['/docs-management'], { queryParams: { id: currentuserid } });
  }

  editFile() {

    const updatefiledescription = (document.getElementById("updatefiledescription") as HTMLInputElement).value;

    const getUserUploadedData = localStorage.getItem('UploadDocumentLocalStorage');
    const user = getUserUploadedData != null ? JSON.parse(getUserUploadedData) : [];

    let userdocid: any = null;
    this.route.queryParams.subscribe((params: any) => {
      userdocid = params.docid;
    });

    const foruserdata = user.filter((users: any) => {
      return userdocid == users.uploadid;
    });

    let currentuserid = foruserdata[0].userid;

    var editdocument = {
      'uploadid': foruserdata[0].uploadid,
      'userid': foruserdata[0].userid,
      'filedescription': updatefiledescription,
      'fileupload': foruserdata[0].fileupload
    }

    const a = user.findIndex((a: any) => a.uploadid == userdocid);
    user.splice(a, 1);
    user.push(editdocument);
    localStorage.setItem("UploadDocumentLocalStorage", JSON.stringify(user));
    this.router.navigate(['/docs-management'], { queryParams: { id: currentuserid } });
  }

  reloadPage(): void {
    window.location.reload();
  }
}