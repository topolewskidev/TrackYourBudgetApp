using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.Users.Helpers;
using TrackYourBudget.Business.Users.Queries;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IIsUserLogInDataValidQuery _isUserLogInDataValidQuery;
        private readonly IUserTokenGenerator _userTokenGenerator;

        public UsersController(
            IIsUserLogInDataValidQuery isUserLogInDataValidQuery,
            IUserTokenGenerator userTokenGenerator)
        {
            _isUserLogInDataValidQuery = isUserLogInDataValidQuery;
            _userTokenGenerator = userTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody]UserLoginDto userLoginData)
        {
            var username = userLoginData.Username;
            var isUserDataValid = _isUserLogInDataValidQuery.Get(username, userLoginData.Password);

            if (!isUserDataValid)
            {
                return Unauthorized();
            }

            var userTokenDto = _userTokenGenerator.Generate(username);

            return Ok(userTokenDto);
        }
    }
}