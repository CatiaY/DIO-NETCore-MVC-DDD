using AutoMapper;
using CursoMVC_DDD.Application.ViewModels;
using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Infra.Data.Context;
using CursoMVC_DDD.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CursoMVC_DDD.Application.Controllers
{    
    public class CategoriaController : Controller
    {
        /* REMOVER O CONTEXT!! ---------------------------------------------------------------*/
        private readonly MySqlContext Db;
        private readonly CategoriaRepository _categoriaRepository;  
        private readonly IMapper _mapper;

        public CategoriaController(MySqlContext context, IMapper mapper)
        {
            Db = context;
            _mapper = mapper;
            _categoriaRepository = new CategoriaRepository(Db);
    }
        

        // GET: CategoriaController
        public ActionResult Index()
        {
            var lista = _categoriaRepository.GetAll();
            var categoriaViewModel = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(lista);            
            return View(categoriaViewModel);            
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaDomain = _mapper.Map<CategoriaViewModel, Categoria>(categoria);
                _categoriaRepository.Add(categoriaDomain);
                
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
