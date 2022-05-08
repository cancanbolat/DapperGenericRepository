using AutoMapper;
using LearnDapper.Data.Entities;
using LearnDapper.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(UserVM model)
        {
            await userRepository.CreateAsync(mapper.Map<User>(model));
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindAll()
        {
            await userRepository.FindAllAsync();
            return Ok();
        }
    }
}
