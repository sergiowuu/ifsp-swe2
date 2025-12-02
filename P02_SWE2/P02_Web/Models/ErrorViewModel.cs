// Sérgio de Chong Wu (CB3025691) e Leonardo de Lima Pedroso (CB3026655)
namespace TP03.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}