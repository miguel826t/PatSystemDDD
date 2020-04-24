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

        #region Construtor
        public SegDesempregoController(
            IRepository<Seguro> Seg,
            IRepository<Empresa> Emp,
            IRepository<Cbo> Cbo)
        {
            _Seg = Seg;
            _Emp = Emp;
            _Cbo = Cbo;
        }
        #endregion




        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> ListAsync()
        {

            return View();
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