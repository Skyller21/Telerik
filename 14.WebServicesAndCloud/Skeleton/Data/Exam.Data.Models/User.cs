using System.Threading.Tasks;

namespace Exam.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;

    public class User : IdentityUser
    {
        private ICollection<Guess> guesses;

        public User()
        {
            this.guesses = new HashSet<Guess>();
        }

        public int Rank { get; set; }

        public ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
