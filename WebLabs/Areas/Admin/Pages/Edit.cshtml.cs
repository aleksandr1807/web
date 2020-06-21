using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebLabs.DAL.Data.ApplicationDbContext _context;
        public IHostingEnvironment _environment;

        public EditModel(WebLabs.DAL.Data.ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Tehnika Tehnika { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }

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
           ViewData["TehnikaGroupId"] = new SelectList(_context.TehnikaGroups, "TehnikaGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string path = "";
            string previousImage = String.IsNullOrEmpty(Tehnika.Images)
                ? ""
                : Tehnika.Images;
            if (image!=null)
            {
                Tehnika.Images = Tehnika.TehnikaId + Path.GetExtension(image.FileName);
                path = Path.Combine(_environment.WebRootPath, "images", Tehnika.Images);
            }

            _context.Attach(Tehnika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if(image!=null)
                {
                    if(!String.IsNullOrEmpty(previousImage))
                    {
                        var fileInfo = _environment.WebRootFileProvider
                            .GetFileInfo("/images/" + previousImage);
                        if(fileInfo.Exists)
                        {
                            var oldPath = Path.Combine(_environment.WebRootPath, "images", previousImage);
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var stream=new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    };
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehnikaExists(Tehnika.TehnikaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TehnikaExists(int id)
        {
            return _context.Tehniks.Any(e => e.TehnikaId == id);
        }
    }
}
