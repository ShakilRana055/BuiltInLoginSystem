﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltInLoginSystem.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
