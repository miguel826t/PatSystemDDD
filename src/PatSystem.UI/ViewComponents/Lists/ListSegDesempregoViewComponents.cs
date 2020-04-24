using Microsoft.AspNetCore.Mvc;
using PatSystem.Domain.Entities.SegDesemprego;
using PatSystem.Domain.Interfaces;
using PatSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.UI.ViewComponents.Lists
{

    [ViewComponent(Name = "ListSegDesemprego")]
    public class ListSegDesempregoViewComponents : ViewComponent
    {

        #region Chamada de Servicos
        private readonly IRepository<Seguro> _Seg;
        private readonly IRepository<Empresa> _Emp;
        private readonly IRepository<Cbo> _Cbo;
        #endregion

        #region Construtor
        public ListSegDesempregoViewComponents(
             IRepository<Seguro> Seg,
            IRepository<Empresa> Emp,
            IRepository<Cbo> Cbo)
        {
            _Seg = Seg;
            _Emp = Emp;
            _Cbo = Cbo;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
