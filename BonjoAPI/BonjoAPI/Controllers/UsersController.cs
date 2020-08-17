using AutoMapper;
using BonjoAPI.Others;
using BonjoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonjoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UsersController(IUserService userService, IMapper mapper, AppSettings appSettings)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.appSettings = appSettings;
        }
    }
}