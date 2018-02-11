namespace TrackYourBudget.Business.Users.Queries
{
    public interface IIsUserLogInDataValidQuery
    {
        bool Get(string username, string password);
    }
}