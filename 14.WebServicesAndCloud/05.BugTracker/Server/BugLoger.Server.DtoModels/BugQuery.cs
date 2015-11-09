namespace BugLogger.Server.DtoModels
{
    using BugLogger.Models;
    using System;

    public class BugQuery
    {
        public DateTime? Date { get; set; }

        public Status? Status { get; set; }
    }
}