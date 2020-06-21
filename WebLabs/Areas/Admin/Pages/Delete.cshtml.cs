using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebLabs.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(WebLabs.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tehnika Tehnika { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tehnika = await _context.Tehniks
                .Include(t => t.Group).FirstOrDefaultAsync(m => m.TehnikaId == id);

            if (Tehnika == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tehnika = await _context.Tehniks.FindAsync(id);

            if (Tehnika != null)
            {
                _context.Tehniks.Remove(Tehnika);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
