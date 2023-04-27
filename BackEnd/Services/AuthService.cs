using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.DataTransferObjects;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTConfig _jwtConfig;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JWTConfig> jwtConfig, IMapper mapper)
        {
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserView> LoginAsync(UserView userView)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userView.Email, userView.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(userView.Email);
                    if (user != null)
                    {
                        var returnResult = _mapper.Map<UserView>(user);

                        returnResult.AccessToken = GenerateToken(user, null);

                        return returnResult;
                    }
                    else
                        throw new ApplicationException("Couldn't find user");
                }

                throw new ApplicationException("Incorrect email or password");

            }
            catch
            {
                throw;
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();

            }
            catch
            {
                throw;
            }
        }

        private string GenerateToken(User user, List<string> roles)
        {
            var claims = new List<System.Security.Claims.Claim>(){
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId,user.Id),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email,user.Email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           };


            //foreach (var role in roles)
            //{
            //    claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role));
            //}

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
