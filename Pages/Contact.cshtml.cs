using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage2.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public CustomerInfo CustomerInfo { get; set; }

        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Choose a file to upload")]
        // [FileExtensions(Extensions = "jpg, png, gif")] // only work with string, not IFormFile
        [CheckFileExtensions(Extensions = "jpg, png, gif")] // clone FileExtensions source to custome for IFormFile
        [DisplayName("File upload")]
        public IFormFile FileUpload { get; set; }

        [BindProperty]
        [DataType(DataType.Upload)]
        // [Required(ErrorMessage = "Choose files to upload")]
        [DisplayName("Files upload")]
        public IFormFile[] FileUploads { get; set; }

        public string Message { get; set; }
        private readonly IWebHostEnvironment _environment;

        public ContactModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Data is valid";

                if (FileUpload != null)
                {
                    // Create filepath to save file
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", FileUpload.FileName);
                    // Create filestream to write file
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    // Copy file to filestream
                    FileUpload.CopyTo(filestream);
                }

                foreach (var file in FileUploads)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    file.CopyTo(filestream);
                }
            }
            else
            {
                Message = "Data is invalid";
            }
        }
    }
}
