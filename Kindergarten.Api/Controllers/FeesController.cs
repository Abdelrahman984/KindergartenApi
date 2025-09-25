using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class FeesController : ControllerBase
{
    private readonly IFeeService _feeService;

    public FeesController(IFeeService feeService)
    {
        _feeService = feeService;
    }

    // GET: api/Fee
    [HttpGet]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetAll()
    {
        var fees = await _feeService.GetAllAsync();
        return Ok(fees);
    }

    // GET: api/Fee/{id}
    [HttpGet("{id:guid}")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var fee = await _feeService.GetByIdAsync(id);
        if (fee == null) return NotFound();
        return Ok(fee);
    }

    // GET: api/Fee/ByStudent/{studentId}
    [HttpGet("ByStudent/{studentId:guid}")]
    //[Authorize(Policy = "CanManageParents")]
    public async Task<IActionResult> GetByStudent(Guid studentId)
    {
        var fees = await _feeService.GetByStudentIdAsync(studentId);
        return Ok(fees);
    }

    // GET: api/Fee/ByParent/{parentId}
    [HttpGet("ByParent/{parentId:guid}")]
    //[Authorize(Policy = "CanManageParents")]
    public async Task<IActionResult> GetByParent(Guid parentId)
    {
        var fees = await _feeService.GetByParentIdAsync(parentId);
        return Ok(fees);
    }

    // GET: api/Fee/Overdue
    [HttpGet("Overdue")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetOverdue()
    {
        var fees = await _feeService.GetOverdueAsync();
        return Ok(fees);
    }

    // POST: api/Fee
    [HttpPost]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create([FromBody] FeeCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var fee = await _feeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = fee.Id }, fee);
    }

    // POST: api/Fee/{id}/mark-paid
    [HttpPost("{id}/mark-paid")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> MarkAsPaid(Guid id)
    {
        await _feeService.MarkAsPaidAsync(id);
        return NoContent();
    }

    // POST: api/Fee/{id}/pay
    [HttpPost("{id}/pay")]
    //[Authorize(Policy = "CanManageParents")]
    public async Task<IActionResult> PayFee(Guid id, [FromBody] PayFeeDto dto)
    {
        // dto يحتوي على: طريقة الدفع، رقم الهاتف/الحساب، transactionId إلخ
        var result = await _feeService.ProcessPaymentAsync(id, dto);
        return Ok(result);
    }

    // DELETE: api/Fee/{id}
    [HttpDelete("{id:guid}")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _feeService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
