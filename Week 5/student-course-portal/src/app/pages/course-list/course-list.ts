import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  studentName = "Swaraj More";

  totalCredits = 20;

  selectedCourse = "";

  courses = [

    {
      id:1,
      name:"Angular",
      code:"ANG101",
      credits:4,
      gradeStatus:"Passed"
    },

    {
      id:2,
      name:"Java",
      code:"JAVA201",
      credits:5,
      gradeStatus:"Running"
    },

    {
      id:3,
      name:"Python",
      code:"PY301",
      credits:3,
      gradeStatus:"Passed"
    }

  ];

  enroll(course:string){

    this.selectedCourse=course;

    alert("Enrolled in "+course);

  }

}