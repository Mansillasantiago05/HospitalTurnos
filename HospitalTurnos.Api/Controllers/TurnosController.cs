using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] // api/turnos
public class TurnosController : ControllerBase
{
    private readonly ApplicationDbContext _db; // conexion

    public TurnosController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet] // RF8 agenda del dia
    public IActionResult Get()
    {
        var lista = _db.Turnos.ToList(); // trae turnos
        return Ok(lista);
    }

    [HttpPost] // RF4 sacar turno
    public IActionResult Post(Turno turno)
    {
        try
        {
            _db.Turnos.Add(turno); // agrega
            _db.SaveChanges(); // si esta superpuesto falla aca por el indice unico RF5
            return Ok(turno);
        }
        catch (Exception ex)
        {
            return BadRequest("Turno superpuesto - ese medico ya tiene turno a esa hora");
        }
    }
        [HttpDelete("{id}")] // eliminar turno RF4
    public IActionResult Delete(int id)
    {
        var turno = _db.Turnos.Find(id); // busca turno
        if (turno == null) return NotFound();
        _db.Turnos.Remove(turno); // borra
        _db.SaveChanges();
        return Ok();
    }
}