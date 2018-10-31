using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Model.Report
{
    public class AuditCollectEntity : BaseModel
    {
        public string Id { get; set; }

        public int? SubricType { get; set; }
        public string SubricTypeName { get; set; }

        public string OrganizationName { get; set; }

        public string ServiceDate { get; set; }

        public string ServiceTime { get; set; }

        public int SubricCount { get; set; }
    }
}
