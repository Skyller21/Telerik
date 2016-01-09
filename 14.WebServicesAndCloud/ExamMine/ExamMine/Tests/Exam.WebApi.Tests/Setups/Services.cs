namespace Exam.WebApi.Tests.Setups
{
    using Exam.Services.Data;
    using Exam.Services.Data.Contracts;

    public static class Services
    {
        public static ICommentServices GetCommentServices()
        {
            return new CommentServices(Repositories.GetCommentsRepository(), null, null);
        }
    }
}

