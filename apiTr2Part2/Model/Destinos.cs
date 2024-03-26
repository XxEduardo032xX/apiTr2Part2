namespace apiTr2Part2.Model
{
    public class Destinos
    {
        public int ID_Destino { get; set; }
        public string NombreDestino { get; set; }
        public string Descripcion { get; set; }
        public string CorreoElectronico { get; set; }
        public Decimal PrecioPorPersona { get; set; }
        public DateTime FechaInicioDisponibilidad { get; set; }
        public DateTime FechaFinDisponibilidad { get; set; }
        public Boolean Disponibilidad { get; set; }
    }
}
