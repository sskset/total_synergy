using ProjectContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();

        Task<Contact> CreateContactAsync(string fistName, string lastName);

        Task DeleteContactAsync(int contactId);
    }
}
