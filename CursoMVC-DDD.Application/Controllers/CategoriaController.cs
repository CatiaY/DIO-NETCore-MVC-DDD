using AutoMapper;
using CursoMVC_DDD.Application.ViewModels;
using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CursoMVC_DDD.Application.Controllers
{
    public class CategoriaController : Controller
    {   
        private readonly ICategoriaService _categoriaService;  
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaService = service;
        }

        //--------------------------------------------------------------------------
        // GET: CategoriaController
        public ActionResult Index()
        {            
            var categoriaViewModel = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaService.GetAll());            
            return View(categoriaViewModel);            
        }

        //--------------------------------------------------------------------------
        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaDomain = ViewModelToEntity(categoriaViewModel);
                _categoriaService.Add(categoriaDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(categoriaViewModel);
        }

        //--------------------------------------------------------------------------
        // GET: CategoriaController/Details/5
        public ActionResult Details(int? id)
        {
            return ExibirViewModel(id);
        }
                

        //--------------------------------------------------------------------------
        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int? id)
        {
            return ExibirViewModel(id);            
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var categoriaDomain = ViewModelToEntity(categoriaViewModel);
                _categoriaService.Update(categoriaDomain);
             
                return RedirectToAction(nameof(Index));
            }

            return View(categoriaViewModel);
        }

        //--------------------------------------------------------------------------
        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int? id)
        {
            return ExibirViewModel(id);            
        }

        // POST: CategoriaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                return NotFound();
            }
                        
            _categoriaService.Delete(id);

            return RedirectToAction(nameof(Index));
        }


        //--------------------------------------------------------------------------                
        private ActionResult ExibirViewModel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        
            var categoriaDomain = _categoriaService.GetById((int)id);

            if (categoriaDomain == null)
            {
                return NotFound();
            }

            var categoriaViewModel = EntityToViewModel(categoriaDomain);
            return View(categoriaViewModel);
        }

        private Categoria ViewModelToEntity(CategoriaViewModel categoriaViewModel)
        {
            return _mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
        }

        private CategoriaViewModel EntityToViewModel(Categoria categoriaEntity)
        {
            return _mapper.Map<Categoria, CategoriaViewModel>(categoriaEntity);
        }
    }
}
