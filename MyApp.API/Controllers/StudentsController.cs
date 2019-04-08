using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MyApp.API.Data;
using MyApp.API.Dtos;
using MyApp.API.Helpers;
using MyApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMyRepository _repo;
        private readonly IMapper _mapper;

        public StudentsController(IMyRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery]StudentParams studentParams)
        {
            var students = await _repo.GetStudents(studentParams);

            var studentsToReturn = _mapper.Map<IEnumerable<StudentForListDto>>(students);

            Response.AddPagination(students.CurrentPage, students.PageSize,
                students.TotalCount, students.TotalPages);

            return Ok(studentsToReturn);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _repo.GetStudent(id);

            var studentToReturn = _mapper.Map<StudentForDetailedDto>(student);

            return Ok(studentToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentForUpdateDto studentForUpdateDto)
        {
            var studentFromRepo = await _repo.GetStudent(id);

            _mapper.Map(studentForUpdateDto, studentFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating student {id} failed on save");
        }


    }
}