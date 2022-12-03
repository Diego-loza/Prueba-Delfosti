using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace delfosti_api.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public string name { get; set; } = null!;

        public Element category { get; set; } = null!;

        public Element brand { get; set; } = null!;

        public string slug { get; set; } = null!;

        public int status { get; set; } = 1;
    }

    public class Element
    {
        public string name { get; set; } = null;
        public string slug { set; get; } = null!;
    }
}
