using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace jevtest.Models
{

    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string companey { get; set; }

        public string username { get; set; }
        [PasswordPropertyText]
        public string password { get; set; }

        public int Rollid { get; set; }
        public UserRolls Roll { get; set; }

    }
}
