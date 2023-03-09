using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVENTA1.Models.Response
{
    public class Respuesta
    {
        public int success { get; set; }
        public string message { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.success = 0;
        }

    }
}
