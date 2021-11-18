using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TruncksProject.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals( Entity other)
        {
           return Id == other.Id;
        }
    }
}
