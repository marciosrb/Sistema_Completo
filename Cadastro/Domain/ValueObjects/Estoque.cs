using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace CQRS.Domain.ValueObjects
{
    public class Estoque
    {

        [ExcludeFromCodeCoverage]
        [BsonElement("EstoqueMinimo")]
        public string EstoqueMinimo { get; set; }

        [BsonElement("EstoqueAtual")]
        public string EstoqueAtual { get; set; }
    }
}