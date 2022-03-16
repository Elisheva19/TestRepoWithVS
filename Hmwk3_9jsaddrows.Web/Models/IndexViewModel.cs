using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hmwk3_9jsaddrows.Data;

namespace Hmwk3_9jsaddrows.Web.Models
{
    public class IndexViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
