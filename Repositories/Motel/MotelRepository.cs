using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NganHangNhaTro.Repositories
{
    public class MotelRepository : IMotelRepository
    {
        private readonly dbContext _dbContext;

        public MotelRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy toàn bộ danh sách phòng trọ
        public List<Motel> GetAll(string title)
        {
            var data = _dbContext.Motel.Include(motel => motel.user)
            .OrderByDescending(m => m.created_at)
            .ToList();

            if (!string.IsNullOrEmpty(title))
            {
                // Perform case-insensitive comparison
                title = title.ToLower();
                data = data.Where(m => m.title.ToLower().Contains(title)).ToList();
            }

            return data;
        }

        public List<Motel> getAllWithCreatedBy(int created_by)
        {
            return _dbContext.Motel
                .Include(motel => motel.user)
                .Where(motel => motel.created_by == created_by)
                .OrderByDescending(m => m.created_at)
                .ToList();
        }


        public Motel show(int id)
        {
            return _dbContext.Motel.Include(motel => motel.user).FirstOrDefault(motel => motel.id == id);
        }

        // Tạo mới một phòng trọ
        public Motel add(Motel motel)
        {
            // Motel motel = new Motel();
            // motel.title = motelView.title;
            // motel.description = motelView.description;
            // motel.address = motelView.address;
            // motel.price = motelView.price;
            // // Lấy đường dẫn của ảnh
            // motel.image = "/app-assets/images/data/" + motelView.file.FileName;
            // motel.detail = motelView.detail;
            // motel.created_by = motelView.created_by;
            // motel.priceElectronicWater = motelView.priceElectronicWater;
            // motel.acreage = motelView.acreage;
            // motel.status = motelView.status;
            // motel.post = motelView.post;
            // Lưu thông tin motel
            _dbContext.Motel.Add(motel);

            _dbContext.SaveChanges();
            return motel;
        }

        // Tìm thông tin phòng trọ theo id
        public Motel save(Motel motel)
        {
            // Tìm thông tin phòng trọ theo id từ client truyền vào
            Motel existingMotel = _dbContext.Motel.Find(motel.id);

            if (existingMotel != null)
            {
                // Update the properties of the existing motel entity with the new values
                existingMotel.id = motel.id;
                existingMotel.title = motel.title;
                existingMotel.description = motel.description;
                existingMotel.detail = motel.detail;
                existingMotel.address = motel.address;
                existingMotel.price = motel.price;
                existingMotel.status = motel.status;
                // ... Update created_at properties as needed ...
                _dbContext.Motel.Update(existingMotel);

                // Save the changes to the database
                _dbContext.SaveChanges();

                // Return the updated motel entity
                return existingMotel;
            }

            return null;
        }

        // Xóa phòng trọ
        public void destroy(int id)
        {
            Motel motel = _dbContext.Motel.Find(id);
            _dbContext.Motel.Remove(motel);
            _dbContext.SaveChanges();
        }

        public List<Motel> GetMotelPage(int page, int pageSize)
        {
            // Tính toán vị trí bắt đầu và số lượng mục cần lấy
            int skipItems = (page - 1) * pageSize;

            // Lấy danh sách các mục từ nguồn dữ liệu, ví dụ: từ cơ sở dữ liệu
            // Dùng phương thức Skip() và Take() để chọn trang phù hợp
            List<Motel> motels = _dbContext.Motel
                .OrderBy(m => m.price) // Sắp xếp theo một trường nào đó (ví dụ: theo Id)
                .Skip(skipItems)    // Bỏ qua các mục ở trang trước đó
                .Take(pageSize)     // Lấy số lượng mục cho trang hiện tại
                .ToList();

            return motels;
        }
    }
}