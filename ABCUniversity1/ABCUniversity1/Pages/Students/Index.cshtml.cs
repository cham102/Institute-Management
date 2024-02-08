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
    public class IndexModel : PageModel
    {
        private readonly ABCUniversity1.Data.ABCUniversity1Context _context;

        public IndexModel(ABCUniversity1.Data.ABCUniversity1Context context)
        {
            _context = context;
        }

        public IList<student> student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.student != null)
            {
                student = await _context.student.ToListAsync();
            }
        }
    }
}
