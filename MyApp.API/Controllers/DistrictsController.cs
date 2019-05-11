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
    public class DistrictsController : ControllerBase
    {
        private readonly IMyAppRepository _repo;
        private readonly IMapper _mapper;

        public DistrictsController(IMyAppRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult> Districts()
        {

            var Districts = await _repo.GetDistrictsAsync();
            var DistrictsToReturn = _mapper.Map<IEnumerable<DistrictsForListDto>>(Districts);
                return Ok(DistrictsToReturn);

        }
    }

}