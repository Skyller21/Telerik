namespace Exam.Web.Common.Providers
{
    using System;

    public interface IRandomProvider
    {
        int GetRandomNumber(int min = 0, int max = int.MaxValue/2);

        double GetRandomFloat(double min, double max);

        string GetRandomString(int minLength = 0, int maxLength = int.MaxValue/2);

        DateTime GetRandomDate(DateTime? after = null, DateTime? before = null);
    }
}