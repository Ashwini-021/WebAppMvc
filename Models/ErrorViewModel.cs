using System.ComponentModel.DataAnnotations;
using WebAppMVC.Models;

namespace WebAppMVC.Models
{
    public class ErrorViewModel
    {
        public string ShowRequestId => !string.IsNullOrEmpty(RequestId) ? RequestId : Guid.NewGuid().ToString();
        public bool ShowRequestIdFlag => !string.IsNullOrEmpty(RequestId);
        public string? RequestId { get; set; }
    
    }

}
