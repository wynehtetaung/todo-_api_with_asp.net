using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoModel{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id {get; set;}
        public string? Item {get; set;}
        public bool Check {get; set;} = false;
        
    }
}