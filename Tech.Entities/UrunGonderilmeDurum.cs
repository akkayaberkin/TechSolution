using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Entities
{
    [Table("UrunGonderilmeDurum")]
    public class UrunGonderilmeDurum : MyEntityBase
    {

        [DisplayName("Adı"),  StringLength(60)]
        public string Adi { get; set; }

        [DisplayName("Kodu"), StringLength(2000)]
        public string Kodu { get; set; }

    }
}
