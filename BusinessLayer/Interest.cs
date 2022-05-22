using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLayer
{
    public class Interest
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string name { get; set; }

        [ForeignKey("User")]
        public List<User> users { get; set; }
        
        [ForeignKey("Region")]
        public Region region { get; set; }


        private Interest()
        {

        }

        public Interest(int id, string name)
        {
            this.ID = ID;
            this.name = name;


        }
        
    }
}
