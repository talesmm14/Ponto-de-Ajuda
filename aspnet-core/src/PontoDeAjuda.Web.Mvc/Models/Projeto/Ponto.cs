using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PontoDeAjuda.Models
{
    public class Ponto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Informacoes { get; set; }
        public string Loc_map { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public Suprimento Suprimentos { get; set; }
    }
}
