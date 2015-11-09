using System;

namespace BugLogger.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public int Id { get; set; }

        [Range(0, 3)]
        public Status Status { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }
    }
}
