using AppData;
namespace AppAPI.IService
{
    public interface INhanVienService
    {
        public List<NhanVien> GetAll();
        public NhanVien GetById(Guid id);
        public bool Create (NhanVien nhanVien);
        public bool Update (NhanVien nhanVien);
        public bool Delete (Guid id);
    }
}
