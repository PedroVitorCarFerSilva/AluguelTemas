using Modelo;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ItemDAL
    {
        private EFContext db = new EFContext();
        public ItemTema ObterItemPorId(long id)
        {
            return db.ItensTema.FirstOrDefault(p => p.ItemId == id);
        }
        public void GravarItem(ItemTema item)
        {
            db.ItensTema.Add(item);
            db.SaveChanges();
        }
    }
}
