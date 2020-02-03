using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class User : IdentityUser
    {
        public int? GroupId { get; set; }
    }
}
