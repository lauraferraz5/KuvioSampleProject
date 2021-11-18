using KuvioSampleProject.Models;
using KuvioSampleProject.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Pages
{
    public class ProjectListBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Projects = (await ProjectService.GetProjects()).ToList();
        }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleDelete(int id)
        {
            var projectToDelete = await ProjectService.GetProject(id);
            var idToDelete = projectToDelete.ProjectId;
            await ProjectService.DeleteProject(idToDelete);
            NavigationManager.NavigateTo("/projects", true);
        }
    }
}
