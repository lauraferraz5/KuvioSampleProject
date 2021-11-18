using KuvioSampleProject.Models;
using KuvioSampleProject.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Pages
{
    public class EditProjectBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        public string PageHeaderText { get; set; }

        public Project Project { get; set; } = new Project();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int projectId);

            if(projectId != 0)
            {
                PageHeaderText = "Edit Project";
                Project = await ProjectService.GetProject(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Project";
                Project = new Project
                {
                    Deadline = DateTime.Now,
                };
            }

        }

        protected async Task HandleSubmit()
        {
            Project result = null;

            if(Project.ProjectId != 0)
            {
                result = await ProjectService.UpdateProject(Project);
            }
            else
            {
                result = await ProjectService.CreateProject(Project)
;            }

            if(result != null)
            {
                NavigationManager.NavigateTo("/projects");
            }
        }

        protected async Task Delete_Click()
        {
            await ProjectService.DeleteProject(Project.ProjectId);
            NavigationManager.NavigateTo("/projects");
        }
    }
}
