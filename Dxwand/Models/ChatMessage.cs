using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dxwand.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        public string Message { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RecivedDate { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }

        public string Language { get; set; }
    }
}