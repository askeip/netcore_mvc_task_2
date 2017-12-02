using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Extreme_MVC_task_2.Models;

namespace Extreme_MVC_task_2
{
    public class StudentController : Controller
    {
        static List<StudentModel> Students = new List<StudentModel>
        {
            new StudentModel{StudentID = 1, Name = "Evgeny", Surname = "Petrosyan", Course = 4, Group = "FIIT"}
        };

        [HttpPost]
        public IActionResult CreateStudent([FromBody]StudentModel student)
        {
            if (ModelState.IsValid)
            {
                Students.Add(student);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetStudent(int studentID)
        {
            var student = Students.FirstOrDefault(x =>
                x.StudentID == studentID);
            if (student != null)
                return Json(student);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateStudent([FromBody]StudentModel student)
        {
            if (ModelState.IsValid)
            { 
                Students[Students.FindIndex(x => x.StudentID == student.StudentID)] = student;
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int studentID)
        {
            var student_index = Students.FindIndex(x => x.StudentID == studentID);
            if (student_index != -1)
            {
                Students.RemoveAt(student_index);
                return Ok();
            }

            return BadRequest();
        }
    }
}
