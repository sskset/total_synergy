using Microsoft.AspNetCore.Mvc;
using ProjectContactAPI.Models;
using ProjectContactAPI.Repositories;
using ProjectContactAPI.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var items = await _projectRepository.GetProjectsAsync();

            return Ok(items);
        }

        [HttpGet("{projectId}/contacts")]
        public async Task<IActionResult> GetContacts(int projectId)
        {
            var items = await _projectRepository.GetContactsAsync(projectId);
            var result = items.Select(x => x.ContactId).ToList();
            return Ok(result);
        }

        [HttpPost("{projectId}/contacts")]
        public async Task<IActionResult> AddContactToProject(int projectId, dynamic dto)
        {
            int contactId = dto.ContactId;

            var item = await _projectRepository.AddContactAsync(projectId, contactId);

            return Ok(item);
        }

        [HttpDelete("{projectId}/contacts/{contactId}")]
        public async Task<IActionResult> RemoveContactFromProject(int projectId, int contactId)
        {
            await _projectRepository.RemoveContactAsync(projectId, contactId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync(dynamic model)
        {
            var project = new Project()
            {
                ProjectName = model.ProjectName
            };

            var result = await _projectRepository.CreateProjectAsync(project);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteProjectAsync(id);

            return Ok();
        }
    }
}
