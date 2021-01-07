using AutoMapper;
using CursoMVC_DDD.Application.ViewModels;
using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CursoMVC_DDD.Application.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService, IMapper mapper)
        {
            _mapper = mapper;
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        //--------------------------------------------------------------------------
        // GET: ProdutoController
        public ActionResult Index()
        {
            IEnumerable<Produto> produtos = _produtoService.GetAll();            
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
            return View(produtoViewModel);
        }

        //--------------------------------------------------------------------------
        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            var categorias = _categoriaService.GetAll();
            ViewData["CategoriaId"] = new SelectList(categorias, "Id", "Descricao");
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = ViewModelToEntity(produtoViewModel);
                _produtoService.Add(produtoDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(produtoViewModel);
        }


        //--------------------------------------------------------------------------
        // GET: ProdutoController/Details/5
        public ActionResult Details(int? id)
        {
            return ExibirViewModel(id);
        }

        //--------------------------------------------------------------------------
        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            var categorias = _categoriaService.GetAll();
            ViewData["CategoriaId"] = new SelectList(categorias, "Id", "Descricao");            
            return ExibirViewModel(id);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProdutoViewModel produtoViewModel)
        {            
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var produtoDomain = ViewModelToEntity(produtoViewModel);
                _produtoService.Update(produtoDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(produtoViewModel);
        }

        //--------------------------------------------------------------------------
        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return ExibirViewModel(id);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            _produtoService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        //--------------------------------------------------------------------------        
        public Produto ViewModelToEntity(ProdutoViewModel produtoViewModel)
        {
            return _mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
        }

        public ProdutoViewModel EntityToViewModel(Produto produtoEntity)
        {
            return _mapper.Map<Produto, ProdutoViewModel>(produtoEntity);
        }

        private ActionResult ExibirViewModel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        
            var produtoDomain = _produtoService.GetById((int)id);

            if (produtoDomain == null)
            {
                return NotFound();
            }

            var produtoViewModel = EntityToViewModel(produtoDomain);
            return View(produtoViewModel);
        }
    }
}
