using DddCqrs.Crud.Domain.Enums;
using System.Text.Json.Serialization;

namespace DddCqrs.Crud.Domain.Common
{
    public abstract class ApplicationDto
    {
        [JsonIgnore]
        public Status Status { get; }

        [JsonIgnore]
        public string? Message { get; }

        protected ApplicationDto(Status status, string? message = null)
        {
            Status = status;
            Message = message;            
        }
    }
}