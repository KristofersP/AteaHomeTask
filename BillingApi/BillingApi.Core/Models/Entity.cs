using BillingApi.Core.Interfaces;
using System.Text.Json.Serialization;

namespace BillingApi.Models
{
    public abstract class Entity : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
