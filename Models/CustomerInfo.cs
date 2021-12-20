using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
    [Display(Name = "Customer name")]
    [Required(ErrorMessage = "{0} is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be between {2}-{1} characters")]
    public string CustomerName { get; set; }

    [DisplayName("Email address")]
    [Required(ErrorMessage = "{0} is required")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "{0} is not valid")]
    public string Email { get; set; }

    [Display(Name = "Year of birth")]
    [Range(1970, 2000, ErrorMessage = "{0} must between {1}-{2}")]
    public int? YearOfBirth { get; set; }
}