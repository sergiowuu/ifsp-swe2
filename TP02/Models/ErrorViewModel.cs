namespace GerenciadorBLContainer.Models
{
    // Sérgio Wu (CB3025691)
    // Leonardo de Lima (CB3026655)
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
