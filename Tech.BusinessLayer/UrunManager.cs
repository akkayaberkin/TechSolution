using Tech.BusinessLayer.Abstract;
using Tech.DataAccessLayer.EntityFramework;
using Tech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.BusinessLayer
{
    public class UrunManager : ManagerBase<Urun>
    {
        public UrunManager()
        {
            Urun urun= new Urun();
            urun.Durum = "Warning";
        }
    }
}
