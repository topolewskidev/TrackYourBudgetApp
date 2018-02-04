using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TrackYourBudget.Business.Users.Queries;

namespace TrackYourBudget.Business.Users.Helpers
{
    public class UserTokenGenerator : IUserTokenGenerator
    {
        private readonly IGetUserIdByUserNameQuery _getUserIdByUserNameQuery;

        public UserTokenGenerator(IGetUserIdByUserNameQuery getUserIdByUserNameQuery)
        {
            _getUserIdByUserNameQuery = getUserIdByUserNameQuery;
        }

        public UserTokenDto Generate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("testSecret");
            var userId = _getUserIdByUserNameQuery.Get(username);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
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
