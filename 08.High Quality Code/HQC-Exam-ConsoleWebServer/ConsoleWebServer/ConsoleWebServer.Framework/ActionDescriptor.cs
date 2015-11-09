namespace ConsoleWebServer.Framework
{
    using System;

    public class ActionDescriptor
    {
        private const string ControllerDefaultName = "Home";
        private const string ActionDefaultName = "Index";
        private const string ParameterDefaultName = "Param";

        public ActionDescriptor(string uri)
        {
            uri = uri ?? string.Empty;

            var uriParts = uri.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ControllerName = uriParts.Length > 0 ? uriParts[0] : ControllerDefaultName;

            this.ActionName = uriParts.Length > 1 ? uriParts[1] : ActionDefaultName;

            this.Parameter = uriParts.Length > 2 ? uriParts[2] : ParameterDefaultName;
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public string Parameter { get; private set; }

        public override string ToString()
        {
            return string.Format("/{0}/{1}/{2}", this.ControllerName, this.ActionName, this.Parameter);
        }
    }
}