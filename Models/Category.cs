using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models
{
    public class Category
    {
        //creates category table
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
