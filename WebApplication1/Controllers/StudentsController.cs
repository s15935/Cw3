using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService<Student> _dbService;

        public StudentsController(IDbService<Student> dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IdStudent = _dbService.NextId();
            _dbService.AddStudent(student);
            return Ok($"Utworzono studenta: {student}.");
        }

        [HttpPut("{idStudent}")]
        public IActionResult PutStudent([FromRoute] int idStudent, [FromBody] Student newStudent)
        {
            var student = _dbService.GetStudents(idStudent);
            if (student == null) return CreateStudent(newStudent);
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            return Ok($" Ąktualizacja dla {student} dokończona");
        }


        [HttpDelete("{idStudent}")]
        public IActionResult DeleteStudent([FromRoute] int idStudent)
        {
            var student = _dbService.GetStudents(idStudent);
            if (student == null) return NotFound($"Nie odnaleziono studenta o id: {idStudent}!");
            _dbService.RemoveStudent(student);
            return Ok($"Usuwanie {student} ukończone");
        }

        //URL
        [HttpGet("{idStudent}")]
        public IActionResult GetStudent([FromRoute] int idStudent)
        {
            var student = _dbService.GetStudents(idStudent);
            if (student == null) return NotFound($"Nie odnaleziono studenta o id: {idStudent}");
            return Ok(student);
        }

    }
}

