using Microsoft.AspNetCore.Mvc;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using PatSystem.Infra.Repository.Services;

using PatSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.Controllers
{
    public class CurriculoController : Controller
    {
        #region Servicos
        private readonly ClienteService _clienteService;
        private readonly CursoSuperiorService _cursoSuperiorService;
        private readonly CursoTecnicoService _cursoTecnicoService;
        private readonly ExperienciaService _experienciaService;
        private readonly IdiomaService _idiomaService;
        private readonly CurriculoService _curriculoService;
        #endregion

        #region Contrutor
        public CurriculoController(ClienteService clienteService, CursoSuperiorService cursoSuperior, CursoTecnicoService cursoTecnicoService, ExperienciaService experiencia, IdiomaService idioma, CurriculoService curriculoService)
        {
            _curriculoService = curriculoService;
            _clienteService = clienteService;
            _cursoSuperiorService = cursoSuperior;
            _cursoTecnicoService = cursoTecnicoService;
            _experienciaService = experiencia;
            _idiomaService = idioma;
        }
        #endregion

        #region PrincipalIndex
        public async Task<IActionResult> IndexAsync()
        {
            return View();
        }
        #endregion

        #region List
        public async Task<IActionResult> ListAsync()
        {
            var curriculos = await _curriculoService.FindAllAsync();
            var clientes = await _clienteService.FindAllAsync();

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
        #endregion

        #region Create

        //Get
        public IActionResult Create(CRcreateViewModel createViewModel)
        {

            #region CursosSuperior
            if (createViewModel.CursoSuperior != null)
            {
                List<CursoSuperior> CursosSuperior = new List<CursoSuperior>();
                if (createViewModel.CursosSuperior == null && createViewModel.CursoSuperior.CursoSuperiorId == 0)
                {
                    createViewModel.CursoSuperior.CursoSuperiorId = 1;
                }
                else
                {
                    if (createViewModel.CursoSuperior.CursoSuperiorId == 0)
                    {
                        CursosSuperior = createViewModel.CursosSuperior;
                        var ultId = createViewModel.CursosSuperior[CursosSuperior.Count - 1];
                        int IdLast = ultId.CursoSuperiorId;
                        createViewModel.CursoSuperior.CursoSuperiorId = IdLast + 1;
                    }
                }
                CursosSuperior.Add(createViewModel.CursoSuperior);
                createViewModel.CursosSuperior = CursosSuperior;
                createViewModel.CursoSuperior = null;
            }
            #endregion

            #region CursosTecnico
            if (createViewModel.CursoTecnico != null)
            {
                List<CursoTecnico> CursosTecnico = new List<CursoTecnico>();
                if (createViewModel.CursosTecnico == null && createViewModel.CursoTecnico.CursoTecnicoId == 0)
                {
                    createViewModel.CursoTecnico.CursoTecnicoId = 1;
                }
                else
                {
                    if (createViewModel.CursoTecnico.CursoTecnicoId == 0)
                    {
                        CursosTecnico = createViewModel.CursosTecnico;
                        var ultId = createViewModel.CursosTecnico[CursosTecnico.Count - 1];
                        int IdLast = ultId.CursoTecnicoId;
                        createViewModel.CursoTecnico.CursoTecnicoId = IdLast + 1;
                    }
                }
                CursosTecnico.Add(createViewModel.CursoTecnico);
                createViewModel.CursosTecnico = CursosTecnico;
                createViewModel.CursoTecnico = new CursoTecnico();
            }
            #endregion

            return View(createViewModel);
        }

        //Post
        public async Task<ActionResult> CreateCR(CRcreateViewModel createViewModel)
        {
            var cliente = createViewModel.Cliente;
            var cursoSuperior = createViewModel.CursoSuperior;
            var cursoTecnico = createViewModel.CursoTecnico;
            var experiencia = createViewModel.Experiencia;
            var idioma = createViewModel.Idioma;

            await _clienteService.InsertAsync(cliente);

            Curriculo curriculo = new Curriculo
            {
                ClienteID = cliente.ClienteId,
                DataCriacao = DateTime.Now,
            };

            if (createViewModel.CursoSuperior.Status == 0)
            {
                curriculo.CursoSuperiorSN = "Não";
            }
            else
            {
                curriculo.CursoSuperiorSN = "Sim";
            }
            if (createViewModel.CursoTecnico.Status == 0)
            {
                curriculo.CursoTecnicoSN = "Não";
            }
            else
            {
                curriculo.CursoTecnicoSN = "Sim";
            }
            if (createViewModel.Idioma.NivelFluencia == 0)
            {
                curriculo.IdiomaSN = "Não";
            }
            else
            {
                curriculo.IdiomaSN = "Sim";
            }
            if (createViewModel.Experiencia.NomeEmpresa == string.Empty)
            {
                curriculo.ExperienciaSN = "Não";
            }
            else
            {
                curriculo.ExperienciaSN = "Sim";
            }

            await _curriculoService.InsertAsync(curriculo);
            cursoSuperior.CurriculoID = curriculo.CurriculoID;
            await _cursoSuperiorService.InsertAsync(cursoSuperior);

            cursoTecnico.CurriculoID = curriculo.CurriculoID;
            await _cursoTecnicoService.InsertAsync(cursoTecnico);

            experiencia.CurriculoID = curriculo.CurriculoID;
            await _experienciaService.InsertAsync(experiencia);

            idioma.CurriculoID = curriculo.CurriculoID;
            await _idiomaService.InsertAsync(idioma);

            return RedirectToAction("List");
        }

        #endregion

        #region Edit
        //Get
        //public async Task<IActionResult> EditAsync(int? id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Curriculo curriculo)
        //{


        //    return RedirectToAction(nameof(Index));
        //}
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int id)
        {
            var cr = await _curriculoService.FindByIdAsync(id);
            var cl = await _clienteService.FindByIdAsync(id);

            var removeViewModel = new CrDeleteViewModel
            {
                CurriculoID = cr.CurriculoID,
                ClienteId = cl.ClienteId,
                Nome = cl.Nome
            };


            return View(removeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var cr = await _curriculoService.FindByIdAsync(id);
            await _clienteService.RemoveAsync(cr.ClienteID);
            await _cursoSuperiorService.RemoveAllAsync(id);
            await _cursoTecnicoService.RemoveAllAsync(id);
            await _idiomaService.RemoveAllAsync(id);
            await _experienciaService.RemoveAllAsync(id);
            //await _curriculoService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details
        public async Task<IActionResult> DetailsAsync(int id)
        {

            var curriculo = await _curriculoService.FindByIdAsync(id);
            var cliente = await _clienteService.FindByIdAsync(curriculo.ClienteID);
            var cursosSuperior = await _cursoSuperiorService.FindAllByIdAsync(id);
            var cursosTecnico = await _cursoTecnicoService.FindAllByIdAsync(id);
            var idiomas = await _idiomaService.FindAllByIdAsync(id);
            var experiencias = await _experienciaService.FindAllByIdAsync(id);

            var detailsviewmodel = new CRdetailsViewModel
            {
                Curriculo = curriculo,
                Cliente = cliente,
                CursosSuperior = cursosSuperior,
                CursosTecnico = cursosTecnico,
                Idiomas = idiomas,
                Experiencias = experiencias
            };


            return View(detailsviewmodel);
        }

        #endregion

    }
}