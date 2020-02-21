using System.ComponentModel.DataAnnotations;

namespace WebApp24I.WebApiApp.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[^_]\w+")]
        public string ExchangeName { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[^_.][\w.]+")]
        public string RoutingKey { get; set; }

        public object Data { get; set; }
    }
}
