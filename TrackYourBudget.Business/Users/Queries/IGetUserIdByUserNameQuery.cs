namespace TrackYourBudget.Business.Users.Queries
{
    public interface IGetUserIdByUserNameQuery
    {
        int Get(string username);
    }
}