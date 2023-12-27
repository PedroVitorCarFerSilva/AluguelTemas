using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;

namespace Servico
{
    public class ItemService
    {
        private ItemDAL itemDAL = new ItemDAL();
        public ItemTema ObterItemPorId(long id)
        {
            return itemDAL.ObterItemPorId(id);
        }
        public IEnumerable<ItemTema> ObterTodosItens()
        {
            return itemDAL.ObterTodosItens();
        }
        public void GravarItem(ItemTema item)
        {
            itemDAL.GravarItem(item);
        }
        public void ApagarItem(long id)
        {
            itemDAL.ApagarItem(id);
        }
    }
}
