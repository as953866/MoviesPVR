using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    /// <summary>
    /// Represent User INformation
    /// </summary>
    public class User
    {
        // Represent User ID
        [Key]
        public string UserID { get; set; }

        // Represent Password of user
        [Required, StringLength(100),Display(Name ="User Password")]
        public string Password { get; set; }

        // Represent First Name
        [Required, StringLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Represent Last Name of User
        [Required, StringLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Represent Role Name of User
        [Required, StringLength(100), Display(Name = "Role Name")]
        public string RoleName { get; set; }

        // Represent Account ID
        [Required, StringLength(100), Display(Name = "Account ID")]
        public string AccountID { get; set; }
    }
}