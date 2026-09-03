using Employee_Management.ApplicationDbContext;
using Employee_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DepartmentMasterController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentList()
        {
            var departmentlist = await _context.departmentMasters.ToListAsync();
           
            return Ok(departmentlist);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentMaster department)
        {
            _context.departmentMasters.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var departData = await _context.departmentMasters.FirstOrDefaultAsync(d => d.DepartmentId == id);
            if (departData == null)
            {
                return NotFound(" Department Id not found");
            }
            return Ok(departData);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id , DepartmentMaster department)
        {
            var departmentData = await _context.departmentMasters.FirstOrDefaultAsync(d => d.DepartmentId == id);
            if(departmentData == null)
            {
                return NotFound(" Department ID Not Found");
            }
            // _context.departmentMasters.Update(department);
            departmentData.DepartmentName = department.DepartmentName;
            departmentData.DepartmentCode = department.DepartmentCode;
            departmentData.IsActive = department.IsActive;
             await _context.SaveChangesAsync();
            return Ok(" Department Data Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentData = await _context.departmentMasters.FirstOrDefaultAsync(d => d.DepartmentId == id);
            if(departmentData == null)
            {
                return NotFound(" Department Data not Found..!!");
            }
             _context.departmentMasters.Remove(departmentData);
            await _context.SaveChangesAsync();
            return Ok(" Department Data is Deleted Successfully..!!");
        }
    }
}
