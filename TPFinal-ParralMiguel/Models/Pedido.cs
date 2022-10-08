namespace TPFinal_ParralMiguel.Models
{
    public class Pedido
    {
        //Atributos de la clase Pedido
        public int PedidoId { get; set; }
        public int PedidoUsuarioId { get; set; }
        public List<Plato> ListaPlatos { get; set; }
        public bool PedidoPreparado { get; set; }
        public float PrecioTotal { get; set; }
        public Usuario PedidoUsuario { get; set; }

    }

  
}
