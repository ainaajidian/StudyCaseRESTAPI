using AutoMapper;
using EnrollmentService.Data;
using EnrollmentService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent _student;
        private IMapper _mapper;

        public StudentController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentNullException(nameof(student));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();

            /*List<StudentDto> lstStudentDto = new List<StudentDto>();
            foreach (var student in students)
            {
                lstStudentDto.Add(new StudentDto
                {
                    ID = student.ID,
                    Name = $"{student.FirstName} {student.LastName}",
                    EnrollmentDate = student.EnrollmentDate
                });
            }*/

            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<StudentDto>(result));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post([FromBody] StudentCreateDto studentCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentCreateDto);
                var result = await _student.Insert(student);
                var studentReturn = _mapper.Map<StudentDto>(result);
                return Ok(studentReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Put(int id, [FromBody] StudentCreateDto studentCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentCreateDto);
                var result = await _student.Update(id.ToString(), student);
                var studentdto = _mapper.Map<StudentDto>(result);
                return Ok(studentdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "admin, student")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _student.Delete(id.ToString());
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}