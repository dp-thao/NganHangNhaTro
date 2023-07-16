using System.ComponentModel.DataAnnotations;

namespace NganHangNhaTro.Models.Views
{
    public class RegisterView
    {
        [Required(ErrorMessage ="Tài khoản không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tài khoản đăng nhập phải tối thiểu 4 kí tự.", MinimumLength = 4)]
        [RegularExpression(@"^[^\s\,]+$", ErrorMessage = "Tên đăng nhập không được có khoảng trắng")]
        public string username { get; set; }

        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số điện thoại không hợp lệ 1")]
        [StringLength(12, ErrorMessage = "Số điện thoại không hợp lệ 2.", MinimumLength = 10)]
        public string phone_number { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu chứa tối thiểu 6 kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Mật khẩu xác nhận không khớp!")]
        public string confirm_password { get; set; }

    }
}