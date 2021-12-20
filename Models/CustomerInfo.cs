using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
    [Display(Name = "Customer name")]
    public string CustomerName { get; set; }
    [DisplayName("Email address")]
    public string Email { get; set; }
    [Display(Name = "Year of birth")]
    public int? YearOfBirth { get; set; }
}