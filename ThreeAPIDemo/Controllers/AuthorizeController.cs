using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ThreeAPIDemo.Dtos;
using ThreeAPIDemo.Models;
using ThreeAPIDemo.Services;

namespace ThreeAPIDemo.Controllers
{
    [ApiController]
    public class AuthorizeController: BaseController
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AuthorizeController(IMapper mapper,
            IUserService userService,
            IOptions<JwtSettings> options) : base(mapper)
        {
            _userService = userService;
            _jwtSettings = options.Value;
        }

        /// <summary>
        ///  获取 token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public string Token(TokenDto request)
        {
            bool isValidate = _userService.ValidatePassword(request.UserName, request.Password);
            
            if(!isValidate) return string.Empty;
            
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name,request.UserName)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(20),
                creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}