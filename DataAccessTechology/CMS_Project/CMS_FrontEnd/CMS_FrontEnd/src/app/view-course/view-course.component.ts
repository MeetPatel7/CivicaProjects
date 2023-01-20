import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { ICourse } from '../icourse';

@Component({
  selector: 'app-view-course',
  templateUrl: './view-course.component.html',
  styleUrls: ['./view-course.component.css']
})
export class ViewCourseComponent implements OnInit {

  courseData !: ICourse[];

  constructor(private courseService:CourseService) { }

  ngOnInit(): void {
    this.viewCourse();
  }

  viewCourse(){
    this.courseService.getCourse().subscribe(
      data => {
        this.courseData = data;
        console.log(this.courseData);
      }
    )
  }

  deleteCourse(id: number) {
    this.courseService.deleteCourse(id).subscribe(
      data => {
        alert("record has been deleted"),
          (error: any) => {
            alert(error.error.message);
          }
        this.ngOnInit();
      }
    )
  }

}
