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
    public class ProdutoController : Controller
    {
        private readonly MySqlContext Db;
        private readonly ProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(MySqlContext context, IMapper mapper)
        {
            Db = context;
            _mapper = mapper;
            _produtoRepository = new ProdutoRepository(context);
        }

        // GET: ProdutoController
        public ActionResult Index()
        {
            var lista = _produtoRepository.GetAll();
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(lista);
            return View(produtoViewModel);
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoRepository.Add(produtoDomain);

                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
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

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
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
