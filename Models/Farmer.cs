using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }
        [Required(ErrorMessage = "Email address is required.")] //if a user tries to add a farmer without the email address
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required.")] //if a user tries to add a farmer without the password
        public string? Password { get; set; }
        //[Required(ErrorMessage = "First name is required.")] //if a user tries to add a farmer without the first name
        public string? FarmerName { get; set; }
        //[Required(ErrorMessage = "Surname is required.")] //if a user tries to add a farmer without the surname
        public string? FarmerSurname { get; set; }
    }
}
