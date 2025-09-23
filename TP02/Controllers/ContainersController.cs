using GerenciadorBLContainer;
using GerenciadorBLContainer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// Sérgio Wu (CB3025691)
// Leonardo de Lima (CB3026655)
public class ContainersController : Controller
{
    private readonly GerenciadorBLContext _context;

    public ContainersController(GerenciadorBLContext context)
    {
        _context = context;
    }

    // GET: Containers
    public async Task<IActionResult> Index()
    {
        var gerenciadorBLContext = _context.Containers.Include(c => c.BL);
        return View(await gerenciadorBLContext.ToListAsync());
    }

    // GET: Containers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers
            .Include(c => c.BL)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (container == null)
        {
            return NotFound();
        }

        return View(container);
    }

    // GET: Containers/Create
    public IActionResult Create()
    {
        ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero");
        return View();
    }

    // POST: Containers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Numero,Tipo,Tamanho,BLId")] Container container)
    {
        // Adicione esta linha para ignorar o erro de validação na propriedade de navegação.
        ModelState.Remove("BL");

        if (ModelState.IsValid)
        {
            _context.Add(container);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero", container.BLId);
        return View(container);
    }

    // GET: Containers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers.FindAsync(id);
        if (container == null)
        {
            return NotFound();
        }
        ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero", container.BLId);
        return View(container);
    }

    // POST: Containers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Tipo,Tamanho,BLId")] Container container)
    {
        if (id != container.ID)
        {
            return NotFound();
        }

        // Adicione esta linha para ignorar o erro de validação na propriedade de navegação 'BL'.
        ModelState.Remove("BL");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(container);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(container.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero", container.BLId);
        return View(container);
    }

    // GET: Containers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers
            .Include(c => c.BL)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (container == null)
        {
            return NotFound();
        }

        return View(container);
    }

    // POST: Containers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var container = await _context.Containers.FindAsync(id);
        _context.Containers.Remove(container);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContainerExists(int id)
    {
        return _context.Containers.Any(e => e.ID == id);
    }
}