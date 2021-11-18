using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.API.Models
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext appDbContext;

        public AssignmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            var result = await appDbContext.Assignments.AddAsync(assignment);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Assignment> DeleteAssignment(int assignmentId)
        {
            var result = await appDbContext.Assignments
                .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);

            if (result != null)
            {
                appDbContext.Assignments.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Assignment> GetAssignment(int assignmentId)
        {
            return await appDbContext.Assignments
                .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            return await appDbContext.Assignments.ToListAsync();
        }

        public async Task<Assignment> UpdateAssignment(Assignment assignment)
        {
            var result = await appDbContext.Assignments
                .FirstOrDefaultAsync(a => a.AssignmentId == assignment.AssignmentId);

            if (result != null)
            {
                result.EmployeeId = assignment.EmployeeId;
                result.Employee = assignment.Employee;
                result.ProjectId = assignment.ProjectId;
                result.Project = assignment.Project;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
