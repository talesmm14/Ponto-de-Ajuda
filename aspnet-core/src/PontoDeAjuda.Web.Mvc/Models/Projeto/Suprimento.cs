using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PontoDeAjuda.Models
{
    public class Suprimento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuprimentoID { get; set; }
        public string Nome { get; set; }
        public int IconURL { get; set; }
    }
}
