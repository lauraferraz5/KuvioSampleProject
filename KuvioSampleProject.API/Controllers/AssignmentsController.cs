using KuvioSampleProject.API.Models;
using KuvioSampleProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentRepository;

        public AssignmentsController(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignments()
        {
            try
            {
                return Ok(await assignmentRepository.GetAssignments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            try
            {
                var result = await assignmentRepository.GetAssignment(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Assignment>> CreateAssignment(Assignment assignment)
        {
            try
            {
                if (assignment == null)
                {
                    return BadRequest();
                }

                var createdAssignment = await assignmentRepository.AddAssignment(assignment);

                return CreatedAtAction(nameof(GetAssignment), new { id = createdAssignment.AssignmentId }, createdAssignment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Assignment>> UpdateAssignment(int id, Assignment assignment)
        {
            try
            {
                if (id != assignment.AssignmentId)
                {
                    return BadRequest("Assignment ID mismatch");
                }

                var assignmentToUpdate = await assignmentRepository.GetAssignment(id);

                if (assignmentToUpdate == null)
                {
                    return NotFound($"Assignment with Id = {id} not found");
                }

                return await assignmentRepository.UpdateAssignment(assignment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Assignment>> DeleteAssignment(int id)
        {
            try
            {
                var assignmentToDelete = await assignmentRepository.GetAssignment(id);

                if (assignmentToDelete == null)
                {
                    return NotFound($"Assignment with Id = {id} not found");
                }

                return await assignmentRepository.DeleteAssignment(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                                  "Error deleting data");
            }
        }
    }
}
