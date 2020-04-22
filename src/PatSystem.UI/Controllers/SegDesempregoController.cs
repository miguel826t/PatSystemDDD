using Microsoft.AspNetCore.Mvc;
using PatSystem.Domain.Entities.SegDesemprego;
using PatSystem.Domain.Interfaces;
using PatSystem.UI.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.Controllers
{
    public class SegDesempregoController : Controller
    {
        #region Chamada de Servicos

        private readonly IRepository<Seguro> _Seg;
        private readonly IRepository<Empresa> _Emp;
        private readonly IRepository<Cbo> _Cbo;

        #endregion


        public SegDesempregoController(
            IRepository<Seguro> Seg,
            IRepository<Empresa> Emp,
            IRepository<Cbo> Cbo)
        {
            _Seg = Seg;
            _Emp = Emp;
            _Cbo = Cbo;
        }





        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> ListAsync()
        {
            var Seguro = await _Seg.FindAllAsync();
            var Empresa = await _Emp.FindAllAsync();
            var Cbo = await _Cbo.FindAllAsync();

            var join = from seg in Seguro

                       join emp in Empresa
                       on seg.EmpresaId
                       equals emp.EmpresaId

                       join cbo in Cbo
                       on seg.CodCboid
                       equals cbo.CodCboId

                       select new SegListViewModel
                       {
                           SegId = seg.SeguroId,
                           CodSeguro = seg.CodSeguro,
                           Profissao = cbo.Desc,
                           Empresa = emp.Nome,
                           Segmento = emp.Segmento
                       };

            return View(join);
        }


        [HttpGet]
        public async Task<IActionResult> Create(SegCreateViewModel segCreate)
        {
            segCreate.Cbos = await _Cbo.FindAllAsync();



            return View(segCreate);
        }


        [HttpPost]
        public async Task<IActionResult> Create()
        {




            return View();
        }

    }
}