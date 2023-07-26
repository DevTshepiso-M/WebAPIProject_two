using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Notetaker.Models
{
	public class Note
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("username")]
		public string? userName { get; set; }

		[BsonElement("title")]
		public string? Title { get; set; }

		[BsonElement("noteItems")]
		public List<string>? NoteItems { get; set; }

		[BsonElement("createdAt")]
		public DateTime CreatedAt { get; set; }

		[BsonElement("updatedAt")]
		public DateTime UpdatedAt { get; set; }
		

		
	}
}
