using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Model
{
    public class Server
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? IPAddress { get; set; }
        public int Port { get; set; }
        public bool Status { get; set; }
    }
}
