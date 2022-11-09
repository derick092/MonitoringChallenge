using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Model
{
    public class VideoFile
    {
        public Guid Id { get; set; }
        public Guid ServerId { get; set; }
        public string? Description { get; set; }
        public byte[]? File { get; set; }
        public DateTime Created { get; set; }
    }
}
