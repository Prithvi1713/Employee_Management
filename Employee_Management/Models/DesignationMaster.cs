using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Employee_Management.Models
{
    public class DesignationMaster
    {
        [Key]
        public int DesignationId { get; set; }
        [Display(Name =" Designation Code ")]
        [Required(ErrorMessage = " Please enter the Designation Code ")]
        [StringLength(5, MinimumLength =2 ,ErrorMessage =" Designation Code must be in between 2 to 5 character")]
        public string DesignationCode { get; set; } = string.Empty;
        [Required(ErrorMessage = " Please enter the Designation Name ")]
        [Display(Name = " Designation Name ")]
        [StringLength(32, ErrorMessage =" please length cannot be more than 32 character ")]
        public string DesignationName { get; set; } = string.Empty;
        [Display(Name = " Department Name ")]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public DepartmentMaster? departmentMaster { get; set; } 
    }
}
