using AppAPI.IService;
using AppAPI.Service;
using AppData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienAPI : ControllerBase
    {
        INhanVienService _service = new NhanVienService();
        [HttpGet("Cal-BMI")]
        public string CalBMI(double H, double W)
        {
            if (H == null || W == null) return "Bạn chưa nhập gì";
            else
            {
                var result = W / (H * H);
                return $"Chỉ số BMI của bạn là {result}";
            }
        }
        [HttpPost("Create-NV")]
        public ActionResult Create(NhanVien nhanVien)
        {
            if(_service.Create(nhanVien))
            return Ok();
            else return BadRequest();
        }
        [HttpPost("Update-NV")]
        public ActionResult Update(NhanVien nhanVien)
        {
            if (_service.Update(nhanVien))
                return Ok();
            else return BadRequest();
        }
        [HttpGet("Delete-NV")]
        public ActionResult Delete(Guid id)
        {
            if (_service.Delete(id))
            return Ok();
            else return BadRequest();
        }
        [HttpGet("Get-All-NV")]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("Get-By-ID-NV")]
        public ActionResult GetByID(Guid id)
        {
            return Ok(_service.GetById(id));
        }

    }
}
