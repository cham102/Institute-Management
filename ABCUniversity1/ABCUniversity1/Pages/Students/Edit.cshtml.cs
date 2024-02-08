using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABCUniversity1.Data;
using ABCUniversity1.models;

namespace ABCUniversity1.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public EditModel(ABCUniversity1.Data.ABCUniversity1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public student student1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student =  await _context.student.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            student1 = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(student1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentExists(student1.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
               
            }

            // return RedirectToPage("./Index");
            return RedirectToPage("/Students/Details", new {id = student1.ID });
        }

        private bool studentExists(int id)
        {
          return (_context.student?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
