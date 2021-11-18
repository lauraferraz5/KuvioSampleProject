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
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var responseMessage = await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Employee>(content);
            return result;
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        //public async Task<IEnumerable<Employee>> Search(string searchTerm)
        //{
        //    if(string.IsNullOrEmpty(searchTerm))
        //    {
        //        return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        //    }

        //    var employeeList = await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        //    var searchedEmp = employeeList.Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm));
        //    return searchedEmp;
        //}

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<Employee>($"api/employees/{updatedEmployee.Id}", updatedEmployee);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Employee>(content);
            return result;
        }
    }
}
