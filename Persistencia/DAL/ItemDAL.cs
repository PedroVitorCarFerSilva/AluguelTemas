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
        public IEnumerable<ItemTema> ObterTodosItens()
        {
            return db.ItensTema.ToList();
        }
        public void GravarItem(ItemTema item)
        {
            if (db.ItensTema.FirstOrDefault(i => i.ItemId == item.ItemId) == null)
            {
                db.ItensTema.Add(item);
            }
            else
            {
                var local = db.Set<ItemTema>().Local.FirstOrDefault(f => f.ItemId == item.ItemId);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public void ApagarItem(long id)
        {
            var item = db.ItensTema.FirstOrDefault(i => i.ItemId == id);
            db.ItensTema.Remove(item);
            db.SaveChanges();
        }
    }
}
