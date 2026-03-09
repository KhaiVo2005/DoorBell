using DoorBell.Application.DTOs.UserDTOs;
using DoorBell.Application.Services;
using DoorBell.Application.Usecases.UserUsecase;
using DoorBell.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTService _jwtService;
        CreateUsecase _create;
        GetByMailUsecase _get;

        public AuthController(JWTService jwtService, CreateUsecase create, GetByMailUsecase get)
        {
            _jwtService = jwtService;
            _create = create;
            _get = get;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateDTO dto)
        {
            var user = new CreateDTO
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            await _create.Execute(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _get.Execute(dto.Email);

            if (user == null || user.Password != dto.Password)
            {
                return Unauthorized("Invalid email or password");
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                user.Id,
                user.Email
            });
        }
    }
}
