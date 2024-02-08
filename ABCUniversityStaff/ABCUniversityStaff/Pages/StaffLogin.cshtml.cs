using ABCUniversityStaff.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ABCUniversityStaff.Pages
{
    public class StaffLoginModel : PageModel
    {
        private readonly ABCUniversityStaff.Data.ABCUniversityStaffContext _context;

        public StaffLoginModel(ABCUniversityStaff.Data.ABCUniversityStaffContext context)
        {

            _context = context;
        }

        [TempData]
        public string ErrorMsg { get; set; } = "";

        [BindProperty]
        public Staff staff1 { get; set; }


        public IActionResult OnGet()
        {
            ErrorMsg = "";
            return Page();
        }







        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                var Staff2 = await _context.Staff.FirstOrDefaultAsync(m => m.StaffPassword == staff1.StaffPassword && m.StaffUserName == staff1.StaffUserName);
                if (Staff2 == null)
                {
                    ErrorMsg = "Invalid Creditials!!";
                    // return NotFound();
                    return Page();
                }
              
                else
                {
                    return RedirectToPage("/Students/Index");
                }

            }

            // If ModelState is not valid, redisplay the form
            return Page();
        }
    }
}
