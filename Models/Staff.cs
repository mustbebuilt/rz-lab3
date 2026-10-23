using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rz.Models;

public class Staff
{
    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    [Display(Name = "First Name")]
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    [Display(Name = "Last Name")]
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Work Email")]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a department.")]
    [Display(Name = "Department")]
    [Column("department")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Job title is required.")]
    [StringLength(60, ErrorMessage = "Job title cannot exceed 60 characters.")]
    [Display(Name = "Job Title")]
    [Column("job_title")]
    public string JobTitle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start date is required.")]
    [Display(Name = "Start date")]
    [Column("start_date")]
    public string StartDate { get; set; } = string.Empty;

    [Required(ErrorMessage = "Salary is required.")]
    [Range(15000, 300000, ErrorMessage = "Salary must be between £15,000 and £300,000.")]
    [Display(Name = "Annual Salary (£)")]
    [Column("salary")]
    public double Salary { get; set; }

    [Display(Name = "Employment Status")]
    [Column("is_active")]
    public int IsActive { get; set; } = 1; // 0 = Inactive, 1 = Active
}