using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PontoDeAjuda.Models
{
    public class AssignedDoacaoData
    {
        public int DoacaoID { get; set; }
        public string Nome { get; set; }
        public string icon { get; set; }
        public bool Assigned { get; set; }
    }
}