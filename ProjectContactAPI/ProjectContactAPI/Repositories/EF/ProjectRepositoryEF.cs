using Microsoft.EntityFrameworkCore;
using ProjectContactAPI.Models;
using ProjectContactAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Repositories.EF
{
    public class ProjectRepositoryEF : IProjectRepository
    {
        private readonly ManagingContext _context;

        public ProjectRepositoryEF(ManagingContext context)
        {
            _context = context;
        }

        public async Task<ProjectContact> AddContactAsync(int projectId, int contactId)
        {
            // var project = _context.Projects.SingleOrDefaultAsync(x => x.ProjectId == projectId);
            // var contact = _context.Contacts.SingleOrDefaultAsync(x => x.ContactId == contactId);
            var item = new ProjectContact()
            {
                ProjectId = projectId,
                ContactId = contactId
            };
            var result = await _context.ProjectContacts.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Project> CreateProjectAsync(Project model)
        {
            var result = await _context.Projects.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var item = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (item != null)
            {
                _context.Projects.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Project> GetProjectAsync(int projectId)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(x => x.ProjectId == projectId);

            return project;
        }

        public async Task<IEnumerable<ProjectContact>> GetContactsAsync(int projectId)
        {
            return await _context.ProjectContacts.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects= await this._context.Projects.ToListAsync();
            return projects;
        }

        public async Task RemoveContactAsync(int projectId, int contactId)
        {

            var item = await this._context.ProjectContacts.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.ContactId == contactId);

            if(item != null)
            {
                _context.ProjectContacts.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
