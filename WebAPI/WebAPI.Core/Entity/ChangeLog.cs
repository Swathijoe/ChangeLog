using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAPI.Core.Enum;

namespace WebAPI.Core.Entity
{
    public class ChangeLog
    {
        [Key]
        public Guid Id { get; set; }

        public string ChangeLogType { get; set; }
        public DateTime ChangeLogTime { get; set; }

        public string Content { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
