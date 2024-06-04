using AppAPI.IService;
using AppData;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Service
{
    public class NhanVienService : INhanVienService
    {
        AppDbContext _dbContext;
        public NhanVienService()
        {
            _dbContext = new AppDbContext();
        }
        public bool Create(NhanVien nhanVien)
        {
            try
            {
                nhanVien.ID = Guid.NewGuid();
                _dbContext.nhanViens.Add(nhanVien);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var a = _dbContext.nhanViens.Find(id);
                _dbContext.nhanViens.Remove(a);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<NhanVien> GetAll()
        {
            return _dbContext.nhanViens.ToList();
        }

        public NhanVien GetById(Guid id)
        {
           return _dbContext.nhanViens.Find(id);
        }

        public bool Update(NhanVien nhanVien)
        {
            try
            {
                var a = _dbContext.nhanViens.Find(nhanVien.ID);
                a.Name = nhanVien.Name;
                a.Role = nhanVien.Role;
                a.status = nhanVien.status;
                a.Age = nhanVien.Age;
                a.Luong = nhanVien.Luong;
                a.Email = nhanVien.Email;
                _dbContext.nhanViens.Update(a);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
