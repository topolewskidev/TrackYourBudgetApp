using System.Linq;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.Business.Users.Queries
{
    public class GetUserIdByUserNameQuery : IGetUserIdByUserNameQuery
    {
        private readonly ApplicationContext _context;

        public GetUserIdByUserNameQuery(ApplicationContext context)
        {
            _context = context;
        }

        public int Get(string username)
        {
            using (_context)
            {
                return _context.Users
                    .Where(user => user.Username == username)
                    .Select(user => user.Id)
                    .Single();

            }
        }
    }
}