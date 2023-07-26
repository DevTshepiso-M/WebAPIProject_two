using Microsoft.AspNetCore.Mvc;
using Notetaker.Interfaces;
using Notetaker.Models;

namespace Notetaker.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class NotesController : ControllerBase
	{
		private readonly INoteService _noteService;

		public NotesController(INoteService noteService)
		{
			_noteService = noteService;
		}

		// GET: api/Contact
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var note = await _noteService.GetAllAsync();
			return Ok(note);
		}
		// GET api/<ValuesController>/
		[HttpGet("{id")]
		public async Task<IActionResult> Get(String id, string name)
		{
			var note = await _noteService.GetByIdAsync(id);

			return Ok(note);
		}
		

		[HttpPost]
		public async Task<IActionResult> Post(Note note)
		{
			await _noteService.CreateAsync(note);
			
			return Ok(note);
		}


		[HttpPut]
		public async Task<IActionResult> Put(string id, Note note)
		{
			await _noteService.UpdateAsync(id, note);
			return Ok("Updated Successfully");
		}
		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(String id)
		{
			await _noteService.DeleteAsync(id);
			return Ok("Deleted Successfully");
		}


	}
}
