using CookingMasterAPI.Data;
using CookingMasterAPI.Helpers;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request;
using CookingMasterAPI.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables
        private readonly APIDbContext _context;
        private readonly IEmailGenerateService _emailGenerateService;
        #endregion
        public AuthController(APIDbContext context, IEmailGenerateService emailGenerateService)
        {
            _context = context;
            _emailGenerateService = emailGenerateService;
        }

        #region PostMethods
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest(ExceptionManager.requestIsNull);
                }
                if (_context.Users.Any(u => u.EmailAddress == request.EmailAddress))
                {
                    return BadRequest(ExceptionManager.mailAlreadyInUse);
                }
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


                var user = new User
                {
                    Username = request.Username,
                    EmailAddress = request.EmailAddress,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    VerificationToken = _emailGenerateService.CreateRandomToken()
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                _emailGenerateService.SendEmail(user.VerificationToken);
                return Ok("User successfully created");
            }
            //Change this in the future
            catch (Exception)
            {
                throw;
            }                
        }
        #endregion

        #region Methods
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        #endregion
    }
}


