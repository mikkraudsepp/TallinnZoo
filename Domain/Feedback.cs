using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;

namespace Domain
{
    public class Feedback : BaseEntity
    {
        [Required]
        [MaxLength(2000, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string SenderEmail { get; set; }
    }
}