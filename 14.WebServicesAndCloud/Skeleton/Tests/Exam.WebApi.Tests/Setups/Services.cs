namespace Exam.WebApi.Tests.Setups
{
    using Exam.Services.Data;
    using Exam.Services.Data.Contracts;

    public static class Services
    {
        public static IHighScoreService GetHighScoreService()
        {
            return new HighScoreService(Repositories.GetUsersRepository());
        }
    }
}
