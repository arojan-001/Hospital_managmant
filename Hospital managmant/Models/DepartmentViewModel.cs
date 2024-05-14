namespace Hospital_management.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DepartmentViewModel
    {
        public int DeptNo { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
