namespace Exam.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<RealEstate> realEstates;
        private ICollection<Rating> givenRatings;
        private ICollection<Rating> receivedRatings;
        private ICollection<Comment> comments;

        public User()
        {
            this.realEstates = new HashSet<RealEstate>();
            this.givenRatings = new HashSet<Rating>();
            this.receivedRatings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
        }


        public virtual ICollection<RealEstate> RealEstates
        {
            get { return this.realEstates; }
            set { this.realEstates = value; }
        }

        public virtual ICollection<Rating> GivenRatings
        {
            get { return this.givenRatings; }
            set { this.givenRatings = value; }
        }

        public virtual ICollection<Rating> ReceivedRatings
        {
            get { return receivedRatings; }
            set { receivedRatings = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
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