using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BaseRepositorio.ViewModel;

namespace ApiVehiculos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        private readonly IViewModel<VehiculoViewModel> _repositorio;

        public VehicleController(IViewModel<VehiculoViewModel> model)
        {
            _repositorio = model;
        }

        public IEnumerable<VehiculoViewModel> Get()
        {
            return _repositorio.SelectAll();
        }

        [ResponseType(typeof(VehiculoViewModel))]
        public IHttpActionResult Get(int id)
        {
            var data = _repositorio.SelectById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [ResponseType(typeof(VehiculoViewModel))]
        public IHttpActionResult NuevoTipo(VehiculoViewModel model)
        {
            _repositorio.Insert(model);

            return Created("ApiVehiculos", model);
        }
    }
}
