namespace TPFinal_ParralMiguel.Models
{
    public class Usuario
    {
        //Atributos de la clase Usuario
        public int? UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioMail { get; set; }
        public string? Contrasenia { get; set; }
        public string UsuarioRol { get; set; }
        public List<Pedido> UsuarioPedidos { get; set; } 

    }
}
