using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string fname { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string lname { get; set; }

        [Required]
        [Range(18, 81)]
        public int age { get; set; }

        [Required]
        [MaxLength(20)]
        public string username { get; set; }
        [Required]
        [MaxLength(70)]
        public string password { get; set; }
        [Required]
        [MaxLength(20)]
        public string email { get; set; }

        [ForeignKey("User")]
        public List<User> friends { get; set; }
        
        
        [ForeignKey("Interest")]
        public List<Interest> interests { get; set; }
        
        private User()
        {

        }

        public User(int ID, string fname, string lname, int age, string username, string password, string email)
        {
            this.ID = ID;
            this.fname = fname;
            this.lname = lname;
            this.age = age;
            this.username = username;
            this.password = password;
            this.email = email;
        }

    }
}
