namespace GerenciadorBLContainer.Models
{
    // Sérgio Wu (CB3025691)
    // Leonardo de Lima (CB3026655)
    public class Container
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }

        public int BLId { get; set; }
        public virtual BL BL { get; set; }
    }
}
