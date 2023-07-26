using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Notetaker.DataAccess;
using Notetaker.Interfaces;
using Notetaker.Models;
using static Notetaker.Services.NoteService;

namespace Notetaker.Services
{
	public class NoteService : INoteService
	{
		
		
			private readonly IMongoCollection<Note> _myCollectionName;
			private readonly IOptions<MongoDBSettings> _databaseSettings;
			public NoteService(IOptions<MongoDBSettings> mongodbSettings)
			{
				mongodbSettings = mongodbSettings;
				var mongoClient = new MongoClient(mongodbSettings.Value.ConnectionString);
				var mongoDatabase = mongoClient.GetDatabase(mongodbSettings.Value.myDatabaseName);
				_myCollectionName = mongoDatabase.GetCollection<Note>
					(mongodbSettings.Value.myCollectionName);
			}


		    public async Task<IEnumerable<Note>> GetAllAsync()=>

			    await _myCollectionName.Find(_ => true).ToListAsync();
		
			public async Task<Note> GetByIdAsync(string id) =>
				await _myCollectionName.Find(a => a.Id == id).FirstOrDefaultAsync();

			public async Task CreateAsync(Note note) =>
				await _myCollectionName.InsertOneAsync(note);

			public async Task UpdateAsync(string id, Note note) =>
				await _myCollectionName.ReplaceOneAsync(a => a.Id == note.Id, note);

			public async Task DeleteAsync(string id) =>
				await _myCollectionName.DeleteOneAsync(a => a.Id == id);

		    public async Task<Note> GetByNameAsync(string name) =>
			    await _myCollectionName.Find(a => a.userName == name).FirstOrDefaultAsync();


	}
}
