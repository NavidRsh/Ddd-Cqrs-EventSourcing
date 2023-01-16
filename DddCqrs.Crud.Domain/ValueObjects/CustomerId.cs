using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Domain.ValueObjects
{
    public class CustomerId : IEquatable<CustomerId>
    {
        private const string IdAsStringPrefix = "Customer-";

        public Guid Id { get; private set; }

        private CustomerId(Guid id)
        {
            Id = id;
        }

        public CustomerId(string id)
        {
            Id = Guid.Parse(id.StartsWith(IdAsStringPrefix) ? id.Substring(IdAsStringPrefix.Length) : id);
        }

        public static CustomerId NewCustomerId()
        {
            return new CustomerId(Guid.NewGuid());
        }

        public bool Equals(CustomerId other) => this.Id == other.Id;

        public override bool Equals(object obj) => 
            obj is CustomerId && Equals(Id, ((CustomerId)obj).Id);
        

        public override string ToString()
        {
            return IdAsString();
        }

        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        
        public string IdAsString()
        {
            return $"{IdAsStringPrefix}{Id.ToString()}";
        }
                
    }
}
