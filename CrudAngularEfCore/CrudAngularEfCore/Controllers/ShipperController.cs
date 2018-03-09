using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudAngularEfCore.Models;
using CrudAngularEfCore.DataAccessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAngularEfCore.Controllers
{
    [Route("api/[controller]")]
    public class ShipperController : Controller
    {
        ShipperDA shipperDA = new ShipperDA();

        [HttpGet]
        [Route("api/Shipper/Index")]
        public IEnumerable<Shipper> Index()
        {
            return shipperDA.GetAllShipper();
        }

        [HttpPost]
        [Route("api/Shipper/Create")]
        public int Create([FromBody] Shipper employee)
        {
            return shipperDA.AddShipper(employee);
        }

        [HttpGet]
        [Route("api/Shipper/Details/{id}")]
        public Shipper Details(int id)
        {
            return shipperDA.GetShipper(id);
        }

        [HttpPut]
        [Route("api/Shipper/Edit")]
        public int Edit([FromBody]Shipper employee)
        {
            return shipperDA.UpdateShipper(employee);
        }

        [HttpDelete]
        [Route("api/Shipper/Delete/{id}")]
        public int Delete(int id)
        {
            return shipperDA.DeleteShipper(id);
        }
    }
}
