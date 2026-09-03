using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee_Management.ApplicationDbContext;
using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationMasterController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DesignationMasterController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDesignationList() 
        {
            var departmentList =await _context.designationMaster.ToListAsync();
            return Ok(departmentList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignationDataById(int id) 
        {
            var designationData = await _context.designationMaster.FirstOrDefaultAsync(d => d.DesignationId == id);
            if(designationData == null)
            {
                return NotFound(" Designation Data not found");
            }
            return Ok(designationData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDesignation(DesignationMaster designation) 
        {
             _context.designationMaster.Add(designation);
            await _context.SaveChangesAsync();
            return Ok(" Designation Data Inserted Successfully...!!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDesignation(int id,DesignationMaster designation) 
        {
            var designationData = await _context.designationMaster.FirstOrDefaultAsync(d => d.DesignationId == id);
            if (designationData == null)
            {
                return NotFound(" Not found");
            }
            designationData.DesignationName = designation.DesignationName;
            designationData.DesignationCode = designation.DesignationCode;
            designationData.DepartmentId = designation.DepartmentId;
             _context.designationMaster.Update(designationData);
            await _context.SaveChangesAsync();
            return Ok("Designation Data Updated Successfully...!!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignation(int id) 
        {
            var designationData = await _context.designationMaster.FirstOrDefaultAsync(d => d.DesignationId == id);
            if(designationData == null)
            {
                return NotFound(" Designation Data not exist...!!");
            }
            _context.designationMaster.Remove(designationData);
            await _context.SaveChangesAsync();
            return Ok(" Designation Data Deleted Successfully...!!");
        }


    }
}
