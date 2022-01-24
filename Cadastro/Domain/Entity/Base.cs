using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cadastro.Domain.Entity
{
    public class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
    }
}