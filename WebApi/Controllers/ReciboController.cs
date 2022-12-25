using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Domain.IServices;
using WebApi.Domain.Models;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly IReciboService _reciboService;
        private readonly IWebHostEnvironment _env;


        public ReciboController(IReciboService reciboService, IWebHostEnvironment env)
        {
            _reciboService = reciboService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Recibo> listRecibo = await _reciboService.GetListRecibos();
                return Ok(listRecibo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]ReciboDTO data)
        {
            try
            {
                Recibo recibo = JsonSerializer.Deserialize<Recibo>(data.recibo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                await _reciboService.SaveRecibo(recibo);

                if (data.archivo != null)
                {
                    int id = recibo.Id;
                    string extension = Path.GetExtension(data.archivo.FileName);
                    recibo.Logo = string.Concat(id, extension);
                    await _reciboService.UpdateLogoRecibo(recibo);
                    var physicalPath = Path.Combine(_env.ContentRootPath, "Logos", id + extension);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await data.archivo.CopyToAsync(stream);
                    }
                }
                return Ok(new { message = "Se agregó el recibo exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
