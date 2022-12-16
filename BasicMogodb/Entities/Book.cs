﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasicMogodb.Entities
{
    public class Book
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }
    }
}
