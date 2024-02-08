using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABCUniversityStaff.Data;
using ABCUniversityStaff.models;

namespace ABCUniversityStaff.Pages.Staffs
{
    public class StaffDetailModel : PageModel
    {
        private readonly ABCUniversityStaff.Data.ABCUniversityStaffContext _context;

        public StaffDetailModel(ABCUniversityStaff.Data.ABCUniversityStaffContext context)
        {
            _context = context;
        }

      public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FirstOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }
            else 
            {
                Staff = staff;
            }
            return Page();
        }
    }
}
