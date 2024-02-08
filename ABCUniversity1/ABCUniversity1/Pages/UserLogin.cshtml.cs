using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ABCUniversity1.Data;
using ABCUniversity1.models;
using Microsoft.EntityFrameworkCore;

namespace ABCUniversity1.Pages
{
    public class UserLoginModel : PageModel
    {
        
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public UserLoginModel( ABCUniversity1.Data.ABCUniversity1Context context)
        {
          
            _context = context;
        }

        [TempData]
        public string ErrorMsg { get; set; } = "";

        [BindProperty]
        public student student2 { get; set; }


        public IActionResult OnGet()
        {
          
            ErrorMsg = "";
            return Page();
        }

     

     


        
        public async Task<IActionResult> OnPostAsync()
        {
            if (student2.Password != "" || student2.UserName !="")
            {
                                
                var student1 = await _context.student.FirstOrDefaultAsync(m => m.Password == student2.Password && m.UserName ==  student2.UserName);
                if (student1 == null)
                {
                    ErrorMsg = "Invalid Credentials!";
                    // return NotFound();
                    return Page();
                }
               else if(student1.Status == null)
                {
                    ErrorMsg = "Student have not yet approved";
                    //return NotFound();
                    return Page();
                }
                else if(student1.Status == "Approved")
                {
                    ErrorMsg = "";
                    return RedirectToPage("/Students/Edit", new { id = student1.ID });
                }
               
            }

            // If ModelState is not valid, redisplay the form
            return Page();
        }

      
    }
}
