using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.API.Models
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAssignments();
        Task<Assignment> GetAssignment(int assignmentId);
        Task<Assignment> AddAssignment(Assignment assignment);
        Task<Assignment> UpdateAssignment(Assignment assignment);
        Task<Assignment> DeleteAssignment(int assignmentId);
    }
}
