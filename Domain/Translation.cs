

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Translation : BaseEntity
    {
        [MaxLength(5)] // et-EE
        public string Culture { get; set; }
        
        [MaxLength(10240)]
        public string Value { get; set; }

        public Guid MultiLangStringId { get; set; }
        public virtual MultiLangString MultiLangString { get; set; }
    }
}