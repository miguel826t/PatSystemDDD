using Microsoft.AspNetCore.Mvc;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using PatSystem.Domain.Common.Validations;
using PatSystem.Infra.Repository;
using PatSystem.Domain.Common.Messages;

using PatSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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


        public IActionResult CreateCursoSuperior(CRcreateViewModel createViewModel)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEmpty(createViewModel.CursoSuperior.Nome, string.Format(Messages.ItemRequired, "Nome do Curso é obrigatorio"));

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


                TempData["CreateCursoSuperior"] = JsonConvert.SerializeObject(createViewModel); 

                return RedirectToAction(nameof(Create));

            }catch(Exception ex)
            {
               string erro = "Erro ao criar Curso Superior" + ex.ToString();
                return RedirectToAction(nameof(Create), erro);
            }
            
        }



        public IActionResult CreateCursoTecnico(CRcreateViewModel createViewModel)
        {
            try
            {
                AssertionConcern.AssertArgumentNotEmpty(createViewModel.CursoSuperior.Nome, string.Format(Messages.ItemRequired, "Nome do Curso é obrigatorio"));

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


                TempData["CreateCursoSuperior"] = JsonConvert.SerializeObject(createViewModel);

                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {
                string erro = "Erro ao criar Curso Superior" + ex.ToString();
                return RedirectToAction(nameof(Create), erro);
            }

        }



        //Get
        [HttpGet]
        public IActionResult Create(CRcreateViewModel createViewModel,string erro)
        {
            if (TempData["CreateCursoSuperior"] != null)
            {
                //createViewModel = TempData["CreateCursoSuperior"] as CRcreateViewModel;
                createViewModel = JsonConvert.DeserializeObject<CRcreateViewModel>(TempData["CreateCursoSuperior"].ToString());
                
                return View(createViewModel);
            }


            //#region CursosTecnico
            //if (createViewModel.CursoTecnico != null)
            //{
            //    List<CursoTecnico> CursosTecnico = new List<CursoTecnico>();
            //    if (createViewModel.CursosTecnico == null && createViewModel.CursoTecnico.CursoTecnicoId == 0)
            //    {
            //        createViewModel.CursoTecnico.CursoTecnicoId = 1;
            //    }
            //    else
            //    {
            //        if (createViewModel.CursoTecnico.CursoTecnicoId == 0)
            //        {
            //            CursosTecnico = createViewModel.CursosTecnico;
            //            var ultId = createViewModel.CursosTecnico[CursosTecnico.Count - 1];
            //            int IdLast = ultId.CursoTecnicoId;
            //            createViewModel.CursoTecnico.CursoTecnicoId = IdLast + 1;
            //        }
            //    }
            //    CursosTecnico.Add(createViewModel.CursoTecnico);
            //    createViewModel.CursosTecnico = CursosTecnico;
            //    createViewModel.CursoTecnico = new CursoTecnico();
            //}
            //#endregion

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