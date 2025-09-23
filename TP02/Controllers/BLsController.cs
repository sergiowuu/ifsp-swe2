using GerenciadorBLContainer;
using GerenciadorBLContainer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// Sérgio Wu (CB3025691)
// Leonardo de Lima (CB3026655)
public class BLsController : Controller
{
    private readonly GerenciadorBLContext _context;

    public BLsController(GerenciadorBLContext context)
    {
        _context = context;
    }

    // GET: BLs
    public async Task<IActionResult> Index()
    {
        return View(await _context.BLs.ToListAsync());
    }

    // GET: BLs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bL = await _context.BLs
            .FirstOrDefaultAsync(m => m.ID == id);
        if (bL == null)
        {
            return NotFound();
        }

        return View(bL);
    }

    // GET: BLs/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BLs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Numero,Consignee,Navio")] BL bL)
    {
        // Adicione esta linha para ignorar a validação da propriedade Containers
        ModelState.Remove("Containers");

        if (ModelState.IsValid)
        {
            _context.Add(bL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bL);
    }

    // GET: BLs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bL = await _context.BLs.FindAsync(id);
        if (bL == null)
        {
            return NotFound();
        }
        return View(bL);
    }

    // POST: BLs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Consignee,Navio")] BL bL)
    {
        // Adicione esta linha
        ModelState.Remove("Containers");

        if (id != bL.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bL);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BLExists(bL.ID))
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
        return View(bL);
    }

    // GET: BLs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bL = await _context.BLs
            .FirstOrDefaultAsync(m => m.ID == id);
        if (bL == null)
        {
            return NotFound();
        }

        return View(bL);
    }

    // POST: BLs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var bL = await _context.BLs.FindAsync(id);
        _context.BLs.Remove(bL);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BLExists(int id)
    {
        return _context.BLs.Any(e => e.ID == id);
    }
}