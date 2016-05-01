using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitetree.DataAccess.Models
{
    public class PageData
    {
        public Guid Id { get; set; }

        public Guid PageId { get; set; }

        public string Property { get; set; }

        public string Value { get; set; }
    }
}
