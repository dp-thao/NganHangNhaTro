using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models
{
    [Table("motels")]
    public partial class Motel
    {
        // Id
        [Key]
        public int id { get; set; }

        // Tiêu đề
        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        public string title { get; set; }

        // Mô tả
        public string? description { get; set; }

        // Chi tiết
        public string detail { get; set; }

        // Địa chỉ
        public string address { get; set; }

        // Giá phòng
        public string price { get; set; }

        // Ảnh
        public string image { get; set; }

        // Người tạo phòng
        public int created_by { get; set; }

        // Trạng thái
        public bool status { get; set; }

        // Ngày đăng
        public DateTime created_at { get; set; }

        public User user { get; set; }
    }
}
