using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicatingway.Client.Model.Configuration
{
    public class CommwayConfiguration
    {
        public string BasicAuthUsername { get; set; }
        public string BasicAuthPassword { get; set; }
        public string Endpoint { get; set; }
    }
}
