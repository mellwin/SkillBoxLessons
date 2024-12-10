using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneContactController : ControllerBase
    {
        private readonly IRepository _repo;

        public PhoneContactController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/phonecontact
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repo.SelectAll();
            return Ok(contacts);
        }

        // GET: api/phonecontact/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var contact = await _repo.Find(id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact not found" });
            }
            return Ok(contact);
        }

        // POST: api/phonecontact
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create([FromBody] PhoneContact contact)
        {
            if (contact == null)
            {
                return BadRequest(new { Message = "Invalid contact data" });
            }

            contact.Id = Guid.NewGuid();
            await _repo.Insert(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        // PUT: api/phonecontact/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PhoneContact contact)
        {
            if (contact == null || id != contact.Id)
            {
                return BadRequest(new { Message = "Invalid contact data" });
            }

            var existingContact = await _repo.Find(id);
            if (existingContact == null)
            {
                return NotFound(new { Message = "Contact not found" });
            }

            await _repo.Update(contact);
            return NoContent();
        }

        // DELETE: api/phonecontact/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contact = await _repo.Find(id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact not found" });
            }

            await _repo.Delete(id);
            return NoContent();
        }
    }
}
