using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVENTA1.Controllers.Models.Response
{
    public class Respuesta
    {
        public int success { get ; set; }
        public string messagge { get; set; }   
        public object Data { get; set; }
    }
}
