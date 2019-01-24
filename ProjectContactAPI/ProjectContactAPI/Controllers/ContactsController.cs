using Microsoft.AspNetCore.Mvc;
using ProjectContactAPI.Repositories;
using ProjectContactAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController:ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactsAsync()
        {
            var contacts = await _contactRepository.GetContactsAsync();

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(dynamic dto)
        {
            string firstName = dto.FirstName;
            string lastName = dto.LastName;

            var contact = await _contactRepository.CreateContactAsync(firstName,lastName);
            return Ok(contact);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContactAsync(int contactId)
        {
            await _contactRepository.DeleteContactAsync(contactId);
            return Ok();
        }
    }
}
