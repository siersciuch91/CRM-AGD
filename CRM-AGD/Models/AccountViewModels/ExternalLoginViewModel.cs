using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
