using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVehiculos
{
    public interface IServiciosRest<TModelo>
    {
        Task<TModelo> Add(TModelo modelo);
        Task Update(TModelo modelo);
        Task Delete(TModelo modelo);

        List<TModelo> Get();
        List<TModelo> Get(Dictionary<string, string> param);
        TModelo Get(int id);
    }
}
