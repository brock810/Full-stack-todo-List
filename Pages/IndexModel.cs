using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication7000.Pages.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApplication7000.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Note> Notes { get; set; }

        public void OnGet()
        {
            Notes = _dbContext.Notes.ToList();
        }

        public IActionResult OnPostUpdateAsync(int id, string updatedContent)
        {
            var noteToUpdate = _dbContext.Notes.Find(id);

            if (noteToUpdate != null)
            {
                noteToUpdate.Content = updatedContent; 
                _dbContext.SaveChanges();
            }

            Notes = _dbContext.Notes.ToList();

            return Page(); 
        }



        public IActionResult OnPostDeleteAsync(int id)
        {
            var noteToDelete = _dbContext.Notes.Find(id);

            if (noteToDelete != null)
            {
                _dbContext.Notes.Remove(noteToDelete);
                _dbContext.SaveChanges();
            }

            return RedirectToPage();
        }

        public void OnPost(string newNote)
        {
            if (!string.IsNullOrWhiteSpace(newNote))
            {
                var note = new Note { Content = newNote };
                _dbContext.Notes.Add(note);
                _dbContext.SaveChanges();
            }

            Notes = _dbContext.Notes.ToList();
        }
    }
}
