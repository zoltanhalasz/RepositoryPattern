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
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(_unitOfWork.Projects.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetProjectsById([FromRoute] int id)
        {
            return Ok(_unitOfWork.Projects.GetById(id));
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project Project)
        {            
            _unitOfWork.Projects.Add(Project);            
            _unitOfWork.Complete();
            return Ok(Project);
        }
    }
}
