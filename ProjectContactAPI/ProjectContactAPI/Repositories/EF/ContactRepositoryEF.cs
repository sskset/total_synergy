using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectContactAPI.Models;
using ProjectContactAPI.Repositories.Interfaces;

namespace ProjectContactAPI.Repositories.EF
{
    public class ContactRepositoryEF : IContactRepository
    {
        private readonly ManagingContext _contaxt;

        public ContactRepositoryEF(ManagingContext context)
        {
            _contaxt = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Contact> CreateContactAsync(string fistName, string lastName)
        {
            var contact = new Contact()
            {
                FirstName = fistName,
                LastName = lastName
            };

            await _contaxt.AddAsync(contact);
            await _contaxt.SaveChangesAsync();

            return contact;
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var item = await _contaxt.Contacts.FirstOrDefaultAsync(x => x.ContactId == contactId);

            if(item != null)
            {
                _contaxt.Contacts.Remove(item);
                await _contaxt.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            var contacts = await _contaxt.Contacts.ToListAsync();
            return contacts;
        }
    }
}
