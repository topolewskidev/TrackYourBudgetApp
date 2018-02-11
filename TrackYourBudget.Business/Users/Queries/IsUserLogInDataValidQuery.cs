using System;
using System.Linq;
using System.Text;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.Business.Users.Queries
{
    public class IsUserLogInDataValidQuery : IIsUserLogInDataValidQuery
    {
        private readonly ApplicationContext _context;

        public IsUserLogInDataValidQuery(ApplicationContext context)
        {
            _context = context;
        }

        public bool Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
            {
                return false;
            }

            return IsPasswordValid(password, user.PasswordHash, user.PasswordSalt);
        }

        private bool IsPasswordValid(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hashAlgorithm = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
