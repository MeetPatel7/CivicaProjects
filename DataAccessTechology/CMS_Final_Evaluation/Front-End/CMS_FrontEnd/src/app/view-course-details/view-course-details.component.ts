import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-view-course-details',
  templateUrl: './view-course-details.component.html',
  styleUrls: ['./view-course-details.component.css']
})
export class ViewCourseDetailsComponent implements OnInit {

  courseId !: number;
  courseDetail : any;

  constructor(public courseService:CourseService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.courseId = Number(this.route.snapshot.paramMap.get("id"));
    this.viewCourseDetails();
  }

  viewCourseDetails(){
    this.courseService.getCourseDetail(this.courseId).subscribe(
      data => {
        this.courseDetail = data;
        console.log(this.courseDetail);
      }
    )
  }

}
