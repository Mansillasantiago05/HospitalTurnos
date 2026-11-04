public class Turno 
{ 
    public int Id { get; set; } 
    public int MedicoId { get; set; } // solo el Id, no el objeto
    public int PacienteId { get; set; } 
    public DateTime FechaHora { get; set; } 
    public string Estado { get; set; } = "Pendiente"; 
}