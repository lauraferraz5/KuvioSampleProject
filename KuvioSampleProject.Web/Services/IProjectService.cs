using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task<Project> UpdateProject(Project updatedProject);
        Task<Project> CreateProject(Project newProject);
        Task DeleteProject(int id);
    }
}
