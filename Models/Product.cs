using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models
{
    public class Product
    {
        //creates product table
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        [ForeignKey("ProductCategory")] //category
        public int Product_Category { get; set; }
        public Category? ProductCategory { get; set; }
        public int Available { get; set; }
        public DateTime DateAdded { get; set; }
        public string? UserEmail { get; set; }
    }
}
