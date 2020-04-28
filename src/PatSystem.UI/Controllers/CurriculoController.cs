using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatSystem.Domain.Common.Messages;
using PatSystem.Domain.Common.Validations;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using PatSystem.Infra.Repository;
using PatSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatSystem.Controllers
{
    public class CurriculoController : Controller
    {
        #region Servicos
        private readonly ClienteRepository _clienteService;
        private readonly CursoSuperiorRepository _cursoSuperiorService;
        private readonly CursoTecnicoRepository _cursoTecnicoService;
        private readonly ExperienciaRepository _experienciaService;
        private readonly IdiomaRepository _idiomaService;
        private readonly CurriculoRepository _curriculoService;
        #endregion

        #region Contrutor
        public CurriculoController(ClienteRepository clienteService, CursoSuperiorRepository cursoSuperior, CursoTecnicoRepository cursoTecnicoService, ExperienciaRepository experiencia, IdiomaRepository idioma, CurriculoRepository curriculoService)
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


            return View();
        }
        #endregion

        #region Create

        #region Create CR Superior
        public IActionResult CreateCursoSuperior(CRcreateViewModel createViewModel)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEmpty(createViewModel.CursoSuperior.Nome, string.Format(Messages.ItemRequired, "Nome do Curso"));
                AssertionConcern.AssertArgumentNotNull(createViewModel.CursoSuperior, string.Format(Messages.ItemRequired, "Curso Superior"));

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


                TempData["CreateCurriculo"] = JsonConvert.SerializeObject(createViewModel);

                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {
                string erro = "Erro ao criar Curso Superior" + ex.ToString();
                return RedirectToAction(nameof(Create), erro);
            }

        }
        #endregion

        #region CR Tecnico
        public IActionResult CreateCursoTecnico(CRcreateViewModel createViewModel)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEmpty(createViewModel.CursoTecnico.Nome, string.Format(Messages.ItemRequired, "Nome do Tecnico"));
                AssertionConcern.AssertArgumentNotNull(createViewModel.CursoTecnico, string.Format(Messages.ItemRequired, "Curso Tecnico"));

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



                TempData["CreateCurriculo"] = JsonConvert.SerializeObject(createViewModel);

                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {
                string erro = "Erro ao criar Curso Tecnico" + ex.ToString();
                return RedirectToAction(nameof(Create), erro);
            }

        }
        #endregion

        #region CR Idioma

        public IActionResult CreateIdioma(CRcreateViewModel createViewModel)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEquals(createViewModel.Idioma.Nome,0, string.Format(Messages.ItemRequired, "Nome do Tecnico"));
                AssertionConcern.AssertArgumentNotNull(createViewModel.Idioma, string.Format(Messages.ItemRequired, "Curso Tecnico"));

                List<Idioma> Idiomas = new List<Idioma>();
                if (createViewModel.Idiomas == null && createViewModel.Idioma.IdiomaId == 0)
                {
                    createViewModel.Idioma.IdiomaId = 1;
                }
                else
                {
                    if (createViewModel.Idioma.IdiomaId == 0)
                    {
                        Idiomas = createViewModel.Idiomas;
                        var ultId = createViewModel.Idiomas[Idiomas.Count - 1];
                        int IdLast = ultId.IdiomaId;
                        createViewModel.Idioma.IdiomaId = IdLast + 1;
                    }
                }
                Idiomas.Add(createViewModel.Idioma);
                createViewModel.Idiomas = Idiomas;



                TempData["CreateCurriculo"] = JsonConvert.SerializeObject(createViewModel);

                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {
                string erro = "Erro ao criar Idioma" + ex.ToString();
                return RedirectToAction(nameof(Create), erro);
            }

        }

        #endregion

        //Get
        [HttpGet]
        public IActionResult Create(CRcreateViewModel createViewModel, string erro)
        {
            if (TempData["CreateCurriculo"] != null)
            {
                //createViewModel = TempData["CreateCursoSuperior"] as CRcreateViewModel;
                createViewModel = JsonConvert.DeserializeObject<CRcreateViewModel>(TempData["CreateCurriculo"].ToString());

                return View(createViewModel);
            }

            if (erro != string.Empty)
            {
                createViewModel.Erros = erro;
            }


            return View(createViewModel);
        }

        //Post
        public async Task<ActionResult> CreateCR(CRcreateViewModel createViewModel)
        {
            try
            {
                await _clienteService.InsertAsync(createViewModel.Cliente);

                Curriculo curriculo = new Curriculo
                {
                    ClienteID = createViewModel.Cliente.ClienteId,
                    DataCriacao = DateTime.Now,
                };

                if (createViewModel.CursosSuperior == null)
                {
                    curriculo.CursoSuperiorSN = "Não";
                }
                else
                {
                    curriculo.CursoSuperiorSN = "Sim";
                }
                if (createViewModel.CursosSuperior == null)
                {
                    curriculo.CursoTecnicoSN = "Não";
                }
                else
                {
                    curriculo.CursoTecnicoSN = "Sim";
                }
                if (createViewModel.Idiomas == null)
                {
                    curriculo.IdiomaSN = "Não";
                }
                else
                {
                    curriculo.IdiomaSN = "Sim";
                }
                if (createViewModel.Experiencias == null)
                {
                    curriculo.ExperienciaSN = "Não";
                }
                else
                {
                    curriculo.ExperienciaSN = "Sim";
                }

                await _curriculoService.InsertAsync(curriculo);


                foreach (var item in createViewModel.CursosSuperior)
                {
                    item.CurriculoID = curriculo.CurriculoID;
                    await _cursoSuperiorService.InsertAsync(item);
                }

                foreach (var item in createViewModel.CursosTecnico)
                {
                    item.CurriculoID = curriculo.CurriculoID;
                    await _cursoTecnicoService.InsertAsync(item);
                }

                foreach (var item in createViewModel.Experiencias)
                {
                    item.CurriculoID = curriculo.CurriculoID;
                    await _experienciaService.InsertAsync(item);
                }

                foreach (var item in createViewModel.Idiomas)
                {
                    item.CurriculoID = curriculo.CurriculoID;
                    await _idiomaService.InsertAsync(item);
                }

                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                createViewModel.Erros = "Erro ao Criar Curriculo: " + ex;
                TempData["CreateCurriculo"] = JsonConvert.SerializeObject(createViewModel);
                return RedirectToAction(nameof(Create));
            }
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