namespace Exam.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.guesses = new HashSet<Guess>();
        }

        public ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GameConstants.MaxGameNameLength)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public GameState GameState { get; set; }

        public string RedUserId { get; set; }

        public virtual User RedUser { get; set; }

        public string RedUserNumber { get; set; }

        public string BlueUserId { get; set; }

        public virtual User BlueUser { get; set; }

        public string BlueUserNumber { get; set; }

        public GameResult GameResult { get; set; }
    }
}
