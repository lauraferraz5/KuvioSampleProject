using KuvioSampleProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient httpClient;

        public ProjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Project> CreateProject(Project newProject)
        {
            var responseMessage = await httpClient.PostAsJsonAsync<Project>("api/projects", newProject);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Project>(content);
            return result;
        }

        public async Task DeleteProject(int id)
        {
            await httpClient.DeleteAsync($"api/projects/{id}");
        }

        public async Task<Project> GetProject(int id)
        {
            return await httpClient.GetFromJsonAsync<Project>($"api/projects/{id}");
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await httpClient.GetFromJsonAsync<Project[]>("api/projects");
        }

        public async Task<Project> UpdateProject(Project updatedProject)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<Project>($"api/projects/{updatedProject.ProjectId}", updatedProject);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Project>(content);
            return result;
        }
    }
}
