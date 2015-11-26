using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BaseRepositorio.Repositorio;
using BaseRepositorio.ViewModel;
using Microsoft.Practices.Unity;

namespace ApiVehiculos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        [Dependency]
        public GenericRepository<VehiculoViewModel> Repositorio { get; set; }

        public IEnumerable<VehiculoViewModel> Get()
        {
            return Repositorio.SelectAll();
        }

        [ResponseType(typeof(VehiculoViewModel))]
        public IHttpActionResult Get(int id)
        {
            var data = Repositorio.SelectById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [ResponseType(typeof(VehiculoViewModel))]
        public IHttpActionResult NuevoTipo(VehiculoViewModel model)
        {
            Repositorio.Insert(model);

            return Created("ApiVehiculos", model);
        }
    }
}
