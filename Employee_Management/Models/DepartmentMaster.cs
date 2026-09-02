using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Employee_Management.Models
{
    public class DepartmentMaster
    {
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Code")]
        [StringLength(5,MinimumLength =2, ErrorMessage ="String Length must be in between 2 to 5")]
        [Required(ErrorMessage = " Please enter the Department Code")]
        public string DepartmentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = " Please enter the Department Name ")]
        [Display(Name = " Department Name")]
        [StringLength(20, ErrorMessage =" String Length Exceeded")]
        public string DepartmentName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
