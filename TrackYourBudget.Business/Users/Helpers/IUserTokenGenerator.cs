namespace TrackYourBudget.Business.Users.Helpers
{
    public interface IUserTokenGenerator
    {
        UserTokenDto Generate(string username);
    }
}