using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
    }
}
