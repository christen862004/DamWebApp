﻿using System.ComponentModel.DataAnnotations;

namespace DamWebApp.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
