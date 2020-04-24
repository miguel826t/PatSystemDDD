using Microsoft.AspNetCore.Mvc;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Interfaces;
using PatSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.UI.ViewComponents.Lists
{
    [ViewComponent(Name = "ListCurriculos")]
    public class ListCurriculosViewComponents : ViewComponent
    {
        #region Chamada de Servicos
        private readonly IRepository<Curriculo> _CR;
        private readonly IRepository<Cliente> _CL;
        #endregion
            
        #region Construtor
        public ListCurriculosViewComponents(IRepository<Curriculo> CR, IRepository<Cliente> CL)
        {
            _CR = CR;
            _CL = CL;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var curriculos = await _CR.FindAllAsync();
            var clientes = await _CL.FindAllAsync();


            var join = from cr in curriculos
                       join cl in clientes
                       on cr.ClienteID
                       equals cl.ClienteId
                       select new CRindexViewModel
                       {
                           CurriculoID = cr.CurriculoID,
                           Nome = cl.Nome,
                           Idade = cl.Idade,
                           AreaAtuacao = cl.AreaAtuacao,
                           EnsinoMedio = cl.EnsinoMedio,
                           CursoTecnicoSN = cr.CursoTecnicoSN,
                           CursoSuperiorSN = cr.CursoSuperiorSN,
                           IdiomaSN = cr.IdiomaSN,
                           ExperienciaSN = cr.ExperienciaSN
                       };


            return View(join);
        }
    }
}
