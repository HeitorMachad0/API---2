using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Contrato
    {
        [Key]
        public int ID{ get; set; }
        public DateTime Data_Contrato { get; set; }
        public int Qtd_Parcelas { get; set; }
        public int Valor_Finc { get; set; }
        public int Prestacoes { get; set; }
    }
}
