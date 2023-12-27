using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluguelTemas;
using Modelo;
using Servico;

namespace AluguelTemas.Controllers
{
    public class ItemController : Controller
    {
        private ItemService servico = new ItemService();
        // GET: Item
        public ActionResult Index()
        {
            return View(servico.ObterTodosItens());
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Apagar(long? id)
        {
            var item = servico.ObterTodosItens();
            if (id != null)
            {
                return View(item.FirstOrDefault(i => i.ItemId == id));
            }
            return RedirectToAction("Index");
        }
        public ActionResult Editar(long? id)
        {
            var item = servico.ObterTodosItens();
            if (id != null)
            {
                return View(item.FirstOrDefault(i => i.ItemId == id));
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(long? id)
        {
            var item = servico.ObterTodosItens();
            if (id != null)
            {
                return View(item.FirstOrDefault(i => i.ItemId == id));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CriarItem(ItemTema item)
        {
            servico.GravarItem(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApagarItem(ItemTema item)
        {
            var id = item.ItemId;
            if (id != 0)
            {
                servico.ApagarItem(id);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarItem(ItemTema item)
        {
            if (item != null)
            {
                if (ModelState.IsValid)
                {
                    servico.GravarItem(item);
                }
            }
            return RedirectToAction("Index");
        }
    }
}