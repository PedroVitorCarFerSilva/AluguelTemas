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
            return View(servico.ObterTodosItens);
        }
        public ActionResult CadastrarItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarItem(ItemTema tema)
        {
            servico.GravarItem(tema);
            return RedirectToAction("Index");
        }
    }
}