using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using Notetaker.Models;

namespace Notetaker.Interfaces
{
	public interface INoteService
	{
		
		// Create a new note.
		Task<IEnumerable<Note>> GetAllAsync();
		Task<Note> GetByIdAsync(string id);
		
		Task CreateAsync(Note note);
		Task UpdateAsync(string id, Note note);
		Task DeleteAsync(string id);

	}
}
