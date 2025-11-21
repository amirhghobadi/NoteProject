using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteProject.Models;




namespace NoteProject.Controllers
{
    public class NotesController : Controller
    {
        private readonly NoteDBContext _context;

        public NotesController(NoteDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            var notes = await _context.Notes.OrderByDescending(n => n.LastModified).ToListAsync();
            return View(notes);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var note = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (note == null) return NotFound();
            return View(note);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreatedAt = DateTime.Now;
                note.LastModified = DateTime.Now;
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }







        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Note note)
        {
            if (id != note.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingNote = await _context.Notes.FindAsync(id);
                if (existingNote == null)
                    return NotFound();

                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                existingNote.LastModified = DateTime.Now;

                _context.Update(existingNote);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
