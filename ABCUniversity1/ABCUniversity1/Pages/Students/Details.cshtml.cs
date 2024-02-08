using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABCUniversity1.Data;
using ABCUniversity1.models;

namespace ABCUniversity1.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public DetailsModel(ABCUniversity1.Data.ABCUniversity1Context context)
        {
            _context = context;
        }

      public student student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student1 = await _context.student.FirstOrDefaultAsync(m => m.ID == id);
            if (student1 == null)
            {
                return NotFound();
            }
            else 
            {
                student = student1;
            }
            return Page();
        }
    }
}
