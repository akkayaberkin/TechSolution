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
    [Table("TSKayit")]
    public class Kayit : MyEntityBase
    {
        [DisplayName("Kayıt Başlığı"), Required, StringLength(60)]
        public string Konu { get; set; }

        [DisplayName("Kayit Metni"), Required, StringLength(2000)]
        public string Text { get; set; }


        [DisplayName("Kategori")]
        public int CategoryId { get; set; }

      
        [DisplayName("Fotoğraf Uzantısı")]
        public string ImagePath { get; set; }

        public virtual TechUser Owner { get; set; }
        public virtual Category Category { get; set; }


    }
}
