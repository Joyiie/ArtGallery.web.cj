using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.CJ.WEB.Infrastructure.Domain.Model
{
    public class User
    {
        public Guid? UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName
        {
            get
            {
                return (this.FirstName + " " + this.LastName);
            }
        }
        public Role UserRole { get; set; }
    }
}
