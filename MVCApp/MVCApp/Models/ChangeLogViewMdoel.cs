using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCApp.Models
{
    public class ChangeLogViewMdoel
    {
        public Guid Id { get; set; }

        public string ChangeLogType { get; set; }
        public DateTime ChangeLogTime { get; set; }

        public string Content { get; set; }       

    }
}
