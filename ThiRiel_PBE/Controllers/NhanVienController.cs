using AppData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ThiRiel_PBE.Controllers
{
    public class NhanVienController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            string request = $@"https://localhost:7238/api/NhanVienAPI/Get-All-NV";
            var response = client.GetStringAsync(request).Result;
            List<NhanVien> nv = JsonConvert.DeserializeObject<List<NhanVien>>(response);
            return View(nv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateNV(NhanVien nhanvien)
        {
            string rq = $@"https://localhost:7238/api/NhanVienAPI/Create-NV";
            var response = await client.PostAsJsonAsync(rq,nhanvien);
            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)
        {
            string rq = $@"https://localhost:7238/api/NhanVienAPI/Get-By-ID-NV?id={id}";
            var response = client.GetStringAsync(rq).Result;
            NhanVien nv = JsonConvert.DeserializeObject<NhanVien>(response);
            return View(nv);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateNV(NhanVien nhanVien)
        {
            string rq = $@"https://localhost:7238/api/NhanVienAPI/Update-NV";
            var response = await client.PostAsJsonAsync(rq, nhanVien);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            string rq = $@"https://localhost:7238/api/NhanVienAPI/Delete-NV?id={id}";
            var response = client.GetStringAsync(rq).Result;
            return RedirectToAction("Index");
        }
    }
}
