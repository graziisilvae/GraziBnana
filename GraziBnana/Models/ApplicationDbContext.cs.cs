using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraziBnana.Models
{
  public class IndexModel : PageModel // Classe que representa o modelo de página
para a página Index.
{
private readonly ApplicationDbContext _context; // Campo para armazenar o
contexto do banco de dados.
// Construtor que injeta o ApplicationDbContext para acesso ao banco de dados.
public IndexModel(ApplicationDbContext context)
{
_context = context;
}

public IList<Student> Students { get; set; } 
public async Task OnGetAsync()
{
Students = await _context.Students.ToListAsync(); 
}

public async Task<IActionResult> OnPostAddAsync(Student newStudent)
{
if (!ModelState.IsValid) 
{
return Page(); 
}
_context.Students.Add(newStudent); 
await _context.SaveChangesAsync(); 
return RedirectToPage(); 
}

public async Task<IActionResult> OnPostDeleteAsync(int id)
{
var student = await _context.Students.FindAsync(id); 
if (student != null)
{
_context.Students.Remove(student); 
await _context.SaveChangesAsync(); 
}
return RedirectToPage(); 
}
}
