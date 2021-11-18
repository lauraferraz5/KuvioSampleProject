using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.API.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Project> AddProject(Project project)
        {
            var result = await appDbContext.Projects.AddAsync(project);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> DeleteProject(int projectId)
        {
            var result = await appDbContext.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (result != null)
            {
                appDbContext.Projects.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Project> GetProject(int projectId)
        {
            return await appDbContext.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await appDbContext.Projects.ToListAsync();
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var result = await appDbContext.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == project.ProjectId);

            if (result != null)
            {
                result.Title = project.Title;
                result.Description = project.Description;
                result.CustomerFirstName = project.CustomerFirstName;
                result.CustomerLastName = project.CustomerLastName;
                result.CustomerEmail = project.CustomerEmail;
                result.CustomerPhone = project.CustomerPhone;
                result.Deadline = project.Deadline;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
