using ABCUniversity1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ABCUniversity1.Pages
{
    public class PrivacyModel : PageModel
    {
        //private readonly ILogger<PrivacyModel> _logger;
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public PrivacyModel(ABCUniversity1.Data.ABCUniversity1Context context)
        {
            //_logger = logger;
            _context = context;
        }
        // String ErrorMsg = "";



        //public student student1 { get; set; } = default!;


        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.student == null)
        //    {

        //        return NotFound();
        //    }

        //    var student = await _context.student.FirstOrDefaultAsync(m => m.ID == id);
        //    if (student == null || student.Status == null)
        //    {
        //        ErrorMsg = "Student have not yet approved";
        //        return NotFound();
        //    }
        //    else
        //    {
        //        student = student1;
        //    }
        //    return Page();
        //}




        [BindProperty]
        public student student1 { get; set; } = new student();

        [TempData]
        public string ErrorMsg { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student = await _context.student.FirstOrDefaultAsync(m => m.ID == id);

            if (student == null || student.Status == null)
            {
                ErrorMsg = "Student has not been approved";
                return RedirectToPage("/Error");
            }
            else
            {
                student1 = student;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Validate the username and password here

                // For example, assuming you have a method to validate the credentials
                bool isValidCredentials = ValidateCredentials(student1.UserName, student1.Password);

                if (isValidCredentials && student1.Status != null)
                {
                    // Redirect to Student/Create page
                    return RedirectToPage("/Student/Create");
                }
                else
                {
                    ErrorMsg = "Invalid username, password, or student not approved.";
                    return RedirectToPage("/Error");
                }
            }

            // If ModelState is not valid, redisplay the form
            return Page();
        }

        private bool ValidateCredentials(string username, string password)
        {
            // Implement your logic to validate username and password
            // For example, check against a database or an external service
            // Return true if valid, false otherwise
            // Replace this with your actual validation logic
            return username == "validUsername" && password == "validPassword";
        }
    }

}
