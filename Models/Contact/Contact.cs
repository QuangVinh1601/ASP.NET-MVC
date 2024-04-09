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
        [Required(ErrorMessage ="Vui lòng nhập {0}")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [Display(Name="Họ tên")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phải nhập {0}")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ Email")]
        [EmailAddress(ErrorMessage ="Sai định dạng Email")]
        public string Email { get; set; }
        [Display(Name="Số điện thoại")]
        [Phone(ErrorMessage ="Sai định dạng số điện thoại")]
        public string Phone { get; set; }
        public DateTime? DateSend { get; set; }
        [Display(Name="Lời nhắn")]
        public string Message { get; set; }
    }
}
