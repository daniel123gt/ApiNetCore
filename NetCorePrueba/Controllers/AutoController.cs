using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.BE;
using NetCoreDAO;
using Microsoft.Extensions.Configuration;
using NetCore.BE.Transporte.Request;

namespace NetCorePrueba.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        AutoDAO da = new AutoDAO();
        MarcaDAO daMarcas = new MarcaDAO();

        private readonly IConfiguration _config;

        public AutoController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Auto        
        [HttpGet("{placa}/{marca}/{modelo}", Name = "GetAll")]
        public IActionResult GetAll(string placa="", int marca= 0, string modelo="")
        {
            placa = placa == "-" ? "" : placa;
            modelo = modelo == "-" ? "" : modelo;

            string cnn = _config.GetConnectionString("cnn");
            List<AutoBE> lista = da.getallAutos(placa, marca, modelo, cnn);

            return Ok(lista);
        }

       
        [HttpGet]
        public IActionResult GetMarcas()
        {
            string cnn = _config.GetConnectionString("cnn");
            List<MarcaBE> lista = daMarcas.getall(cnn);

            return Ok(lista);
        }

        // POST: api/Auto
        [HttpPost]
        public IActionResult Guardar([FromBody] AutoRequest autoRequest)
        {
            string cnn = _config.GetConnectionString("cnn");
            bool ok = da.Guardar(autoRequest, cnn);

            return Ok(ok);
        }

        // PUT: api/Auto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
