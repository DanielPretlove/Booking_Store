using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID {get; set; }
        public string Username {get; set; }
        public string Role {get; set; }
        public string EmailAddress {get; set; }
        public string Password {get; set; }
    }
}