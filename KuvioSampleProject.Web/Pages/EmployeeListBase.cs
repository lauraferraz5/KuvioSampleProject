using KuvioSampleProject.Models;
using KuvioSampleProject.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        
        //public string SearchTerm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        //public async Task OnGet()
        //{
        //    Employees = (await EmployeeService.Search(SearchTerm));
        //}

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleDelete(int id)
        {
            var employeeToDelete = await EmployeeService.GetEmployee(id);
            var idToDelete = employeeToDelete.Id;
            await EmployeeService.DeleteEmployee(idToDelete);
            NavigationManager.NavigateTo("/employees", true);
        }


    }
}
