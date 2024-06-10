namespace Inscripciones.Models
{
    public class DetalleInscripciones
    {
        public int Id { get; set; }
        public int ModalidadCursado { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public int MateriasId { get; set; }
        public Materia? materia { get; set; }

    }
}
