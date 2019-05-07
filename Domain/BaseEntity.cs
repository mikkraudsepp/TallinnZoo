using System;
using Contracts.DAL.Base;

namespace Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; } // Primary Key   
    }

}