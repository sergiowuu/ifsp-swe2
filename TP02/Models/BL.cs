namespace GerenciadorBLContainer.Models
{
    // Sérgio Wu (CB3025691)
    // Leonardo de Lima (CB3026655)
    public class BL
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
