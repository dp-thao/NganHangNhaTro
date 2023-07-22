using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;


namespace NganHangNhaTro.Repositories
{
    public interface IMotelRepository
    {

        // public User Add(User user);

        // public void SaveChanges();
        // Add other member-related methods as needed

        public List<Motel> GetAll(string title);

        public List<Motel> getAllWithCreatedBy(int created_by);

        public Motel show(int id);

        // Thêm phòng trọ mới
        public Motel add(Motel motel);
        // Cập nhật thông tin phòng trọ
        public Motel save(Motel motel);
        // Xóa phòng trọ
        public void destroy(int id);
    }
}