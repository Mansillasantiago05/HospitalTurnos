public class Turno 
{ 
    public int Id { get; set; } 
    public int PacienteId { get; set; } 
    public Paciente Paciente { get; set; }
    public int MedicoId { get; set; } 
    public Medico Medico { get; set; }
    public DateTime FechaHora { get; set; } 
    public string Estado { get; set; } = "Pendiente"; 
}