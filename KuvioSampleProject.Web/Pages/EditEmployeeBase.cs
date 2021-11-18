using KuvioSampleProject.Models;
using KuvioSampleProject.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public string PageHeaderText { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if(employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    DateOfBirth = DateTime.Now,
                };
            }

        }

        protected async Task HandleSubmit()
        {
            Employee result = null;

            if(Employee.Id != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee)
;            }

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            // get the difference in years
            int years = DateTime.Now.Year - dateOfBirth.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (DateTime.Now.Month < dateOfBirth.Month || (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
                years--;

            return years;
        }
    }
}
