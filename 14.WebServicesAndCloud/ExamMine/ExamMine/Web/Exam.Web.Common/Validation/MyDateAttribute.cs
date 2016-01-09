namespace Exam.Web.Common.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            var parsed = DateTime.TryParse((string) value, out dt);
            if (!parsed)
            {
                return false;
            }

            if (dt.Year < RealEstateConstants.MinimumConstructionYear)
            {
                return false;
            }

            return true;
        }
    }
}