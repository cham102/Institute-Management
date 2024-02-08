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

namespace ABCUniversity1.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public CreateModel(ABCUniversity1.Data.ABCUniversity1Context context)
        {
            _context = context;
        }

        [TempData]
        public string ErrorMsg { get; set; } = "";

        public IActionResult OnGet()
        {
            ErrorMsg = "";
            return Page();
        }

        [BindProperty]
        public student student { get; set; } = default!;
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //2023/06/12---
            var student1 = await _context.student.FirstOrDefaultAsync(m => m.UserName == student.UserName);
            if (student1 == null) 
            {          
            
                if (!ModelState.IsValid || _context.student == null || student == null)
                {
                    return Page();
                }
                student.AddUser = 123;
                student.Session = student.UserName;
                student.AddDate = DateTime.Now;
                student.AddMach = "Dell";
                student.RecordId = 1123;
                student.timestamp_column = default;

                _context.student.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToPage("/UserLogin");

            }
             else if (student1.UserName == student.UserName)
            {
                ErrorMsg = "UserName have already used!Please Enter anaother UserName";
                return Page();
            }
            return Page();

        }
    }
}
