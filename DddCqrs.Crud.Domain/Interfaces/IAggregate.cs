using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Domain.Interfaces
{
    public interface IAggregate<TId>
    {
        TId Id { get; }
    }
}
