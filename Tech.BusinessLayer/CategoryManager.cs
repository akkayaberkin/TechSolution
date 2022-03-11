using Tech.BusinessLayer.Abstract;
using Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.BusinessLayer
{
    public class CategoryManager : ManagerBase<Category>
    {
        public override int Delete(Category category)
        {
            KayitManager kayitManager = new KayitManager();
          
            foreach (Kayit kayit in category.Kayits.ToList())
            {
                kayitManager.Delete(kayit);
            }

            return base.Delete(category);
        }
    }
}
