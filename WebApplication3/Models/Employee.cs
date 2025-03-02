using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        [ValidateNever]        
        public int Id {  get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Position is required")]
        [StringLength(50, ErrorMessage = "Position must be less than 50 characters")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

    }
}
