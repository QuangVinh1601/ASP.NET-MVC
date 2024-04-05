using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC_1.Models.Contact
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime DateSend { get; set; }

        public string Message { get; set; }
    }
}
