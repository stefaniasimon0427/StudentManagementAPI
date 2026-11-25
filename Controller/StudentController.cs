using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models.Entity;
using StudentManagementAPI.Models.DTO;

namespace StudentManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentDbContext _context;

    public StudentsController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: api/students
    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _context.Students.ToListAsync();
        return Ok(students);
    }

    // GET: api/students/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound("Student not found");

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public async Task<IActionResult> AddStudent(AddStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Age = dto.Age,
            Course = dto.Course,
            Address = dto.Address
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetStudentById),
            new { id = student.StudentId },
            student);
    }

    // PUT: api/students/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(Guid id, UpdateStudentDto dto)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound("Student not found");

        student.Name = dto.Name;
        student.Email = dto.Email;
        student.Phone = dto.Phone;
        student.Age = dto.Age;
        student.Course = dto.Course;
        student.Address = dto.Address;

        await _context.SaveChangesAsync();

        return Ok(student);
    }

    // DELETE: api/students/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound("Student not found");

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok("Student deleted successfully");
    }
}