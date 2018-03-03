using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TrackYourBudget.Business.Common;
using TrackYourBudget.Business.Users.Queries;

namespace TrackYourBudget.Business.Users.Helpers
{
    public class UserTokenGenerator : IUserTokenGenerator
    {
        private readonly IGetUserIdByUserNameQuery _getUserIdByUserNameQuery;
        private readonly ApplicationSettingsProvider _applicationSettings;

        public UserTokenGenerator(
            IGetUserIdByUserNameQuery getUserIdByUserNameQuery,
            IOptions<ApplicationSettingsProvider> applicationSettings)
        {
            _getUserIdByUserNameQuery = getUserIdByUserNameQuery;
            _applicationSettings = applicationSettings.Value;
        }

        public UserTokenDto Generate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_applicationSettings.Secret);
            var userId = _getUserIdByUserNameQuery.Get(username);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.Now.AddYears(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserTokenDto()
            {
                Token = tokenString,
                UserId = userId
            };
        }
    }
}
