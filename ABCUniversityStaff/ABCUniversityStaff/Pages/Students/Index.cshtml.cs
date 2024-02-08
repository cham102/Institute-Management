using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABCUniversityStaff.Data;
using ABCUniversityStaff.models;

namespace ABCUniversityStaff.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ABCUniversityStaff.Data.ABCUniversityStaffContext _context;

        public IndexModel(ABCUniversityStaff.Data.ABCUniversityStaffContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
    }
}
