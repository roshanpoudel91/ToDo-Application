using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.DataTransferObjects;
using static Shared.Constants;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTConfig _jwtConfig;

        public UserService(UserManager<User> userManager, IOptions<JWTConfig> jwtConfig, IMapper mapper)
        {
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
            _userManager = userManager;
        }

        public async Task<UserView> AddAsync(UserView userView)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = userView.FirstName,
                    LastName = userView.LastName,
                    UserName = userView.Email,
                    NormalizedUserName = userView.Email.ToUpper(),
                    Email = userView.Email,
                    NormalizedEmail = userView.Email.ToUpper(),
                    PhoneNumber = userView.PhoneNumber
                };

                var result = await _userManager.CreateAsync(newUser, userView.Password);

                if (result.Succeeded)
                {
                    newUser = await _userManager.FindByEmailAsync(newUser.Email);

                    await _userManager.AddToRoleAsync(newUser, RoleNames.User);

                    var returnResult = _mapper.Map<UserView>(newUser);
                    return returnResult;
                }

                var errors = result.Errors.Select(x => x.Description).ToArray();
                throw new ApplicationException(string.Join(",", errors));
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<UserView>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = _userManager.Users.ToList();
                    ICollection<UserView> returnResult = _mapper.Map<ICollection<UserView>>(result.ToList());
                    return returnResult;
                }
                catch
                {
                    throw;
                }
            });
        }

        public async Task<ICollection<UserView>> GetAllByRole(string role)
        {
            try
            {
                var result = await _userManager.GetUsersInRoleAsync(role);
                ICollection<UserView> returnResult = _mapper.Map<ICollection<UserView>>(result.ToList());
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserView> GetAsync(string id)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(id);
                UserView returnResult = _mapper.Map<UserView>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserView> RemoveAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return default;
                }

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return default;
                }

                var errors = result.Errors.Select(x => x.Description).ToArray();
                throw new ApplicationException(string.Join(",", errors));
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserView> UpdateAsync(UserView userView, string id)
        {
            try
            {
                if (userView == null || string.IsNullOrEmpty(id) || userView.UserviewId != id)
                {
                    return null;
                }

                var existing = await _userManager.FindByIdAsync(id);
                if (existing != null)
                {
                    // Only update FirstName, LastName, and PhoneNumber
                    existing.FirstName = userView.FirstName;
                    existing.LastName = userView.LastName;
                    existing.PhoneNumber = userView.PhoneNumber;

                    var result = await _userManager.UpdateAsync(existing);

                    if (result.Succeeded)
                    {
                        existing = await _userManager.FindByIdAsync(id);
                        var returnResult = _mapper.Map<UserView>(existing);
                        return returnResult;
                    }

                    var errors = result.Errors.Select(x => x.Description).ToArray();
                    throw new ApplicationException(string.Join(",", errors));
                }
                return default;
            }
            catch
            {
                throw;
            }
        }

        private string GenerateToken(User user, List<string> roleaas)
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
