using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Keyless]
    public class Prestacao
    {
        public Contrato Contrato { get; set; }
        public DateTime Data_Venc { get; set; }
        public DateTime Data_Pag { get; set; }
        public int Valor { get; set; }
        public string Status { get; set; }
    }
}
