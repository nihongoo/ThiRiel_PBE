using System.ComponentModel.DataAnnotations;

namespace AppData
{
    public class NhanVien
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Không được nhập tên dài quá 30 ký tự")]
        public string Name { get; set; }
        [Required]
        [Range(18,50,ErrorMessage ="Chỉ dược nhập tuổi từ 18 đến 50 tuổi")]
        public int Age { get; set; }
        public int Role { get; set; }
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }
        [Required]
        [Range(5000000,30000000,ErrorMessage ="Chỉ được nhập lương từ 1jack đến 6jack")]
        public int Luong { get; set; }
        [Required]
        public bool status { get; set; }
    }
}