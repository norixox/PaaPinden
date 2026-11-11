using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PåPinden.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PåPinden.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

        [InverseProperty(nameof(Follow.Follower))]
        public ICollection<Follow> Follows { get; set; } = new List<Follow>();

        [InverseProperty(nameof(Follow.Following))]
        public ICollection<Follow> Followers { get; set; } = new List<Follow>();    
    }

}
