using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;

namespace BitCalculator.Web.Constraints
{
    public class AdminConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values["controller"].ToString().StartsWith("admin", true, Thread.CurrentThread.CurrentCulture))
            {

                return false;
            }

            return true;
        }
    }
}