using Iusan_Irina_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Iusan_Irina_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Iusan_Irina_Lab2Context _context;

    public IndexModel(Iusan_Irina_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public int? AuthorID { get; set; }
    public SelectList? Authors { get; set; }

    public async Task OnGetAsync()
    {
        var books = _context.Book.AsQueryable();

        if (AuthorID != null)
        {
            books = books.Where(x => x.AuthorID == AuthorID);
        }

        Book = await books.Include(b => b.Publisher).Include(b => b.Author).ToListAsync();
        Authors = new SelectList(await _context.Author.ToListAsync(), "ID", "LastName");
    }
}
