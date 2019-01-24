using ProjectContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();

        Task<Project> CreateProjectAsync(Project model);

        Task DeleteProjectAsync(int projectId);

        Task<Project> GetProjectAsync(int projectId);

        Task<ProjectContact> AddContactAsync(int projectId, int contactId);

        Task RemoveContactAsync(int projectId, int contactId);

        Task<IEnumerable<ProjectContact>> GetContactsAsync(int projectId);
    }
}
