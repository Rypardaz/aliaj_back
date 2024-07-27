using PhoenixFramework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.Infrastructure.Query.Contracts.Shared
{
    public class DownloadSearchModel
    {
        public string? Title { get; set; }
        public Guid? Guid { get; set; }
    }
}
