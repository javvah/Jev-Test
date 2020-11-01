using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace jevtest.Models
{
    public class UserRolls
    {
        [Key]
        public int id { get; set; }
        public string Roll { get; set; }

        public List<Users> users { get; set;}    //ilişki için lazim bir table property degil
    }
}
