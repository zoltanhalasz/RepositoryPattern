using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetDevelopers()
        {
            return Ok(_unitOfWork.Developers.GetAll());
        }

        [HttpGet("popular")]
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            return Ok(_unitOfWork.Developers.GetPopularDevelopers(count));
        }

        [HttpGet("{id}")]
        public IActionResult GetDevelopersById([FromRoute] int id)
        {
            return Ok(_unitOfWork.Developers.GetById(id));
        }

        [HttpPost]
        public IActionResult AddDeveloper([FromBody] Developer Developer)
        {            
            _unitOfWork.Developers.Add(Developer);            
            _unitOfWork.Complete();
            return Ok(Developer);
        }
    }
}
