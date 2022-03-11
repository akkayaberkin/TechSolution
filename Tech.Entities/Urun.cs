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
    [Table("Urun")]
    public class Urun : MyEntityBase
    {

        [DisplayName("Adı"),  StringLength(60)]
        public string Adi { get; set; }

        [DisplayName("Kodu"), StringLength(2000)]
        public string Kodu { get; set; }

        [DisplayName("Durum"), StringLength(2000)]
        public string Durum { get; set; }

        [DisplayName("Fotoğraf Uzantısı")]
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }

        public virtual TechUser Owner { get; set; }

    }
}
