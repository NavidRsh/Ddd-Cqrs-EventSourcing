using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Domain.Events
{
    public sealed class EventData
    {
        public Guid EventId { get; private set; }
        public string EntityId { get; private set; }
        public string Type { get; private set; }
        public bool IsJson { get; private set; }
        public byte[] Data { get; private set; }
        public byte[] Metadata { get; private set; }

        public EventData(Guid eventId, string entityId, string type, bool isJson, byte[] data, byte[] metadata)
        {
            EventId = eventId;
            EntityId = entityId;
            Type = type;
            IsJson = IsJson;
            Data = data;
            Metadata = metadata; 
        }
    }
}
