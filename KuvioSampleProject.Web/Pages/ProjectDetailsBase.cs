using KuvioSampleProject.Models;
using KuvioSampleProject.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Pages
{
    public class ProjectDetailsBase : ComponentBase
    {
        public Project Project { get; set; } = new Project();
        protected string CssClass { get; set; } = null;

        [Inject]
        public IProjectService ProjectService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Project = await ProjectService.GetProject(int.Parse(Id));
        }

        [Parameter]
        public EventCallback<int> OnProjectDeleted { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ProjectService.DeleteProject(Project.ProjectId);
                NavigationManager.NavigateTo("/projects");
            }
        }
    }
}


