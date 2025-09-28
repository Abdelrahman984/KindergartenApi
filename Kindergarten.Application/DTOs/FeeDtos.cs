using System.ComponentModel.DataAnnotations;

namespace Kindergarten.Application.DTOs;

public record FeeCreateDto(
    [Required, Range(1, double.MaxValue, ErrorMessage = "المبلغ يجب أن يكون أكبر من 0")]
    decimal Amount,

    [Required, DataType(DataType.Date)]
    DateTime DueDate,

    [Required]
    Guid StudentId,

    [Required]
    Guid ParentId
);

public record FeeReadDto
{
    public Guid Id { get; init; }
    public decimal Amount { get; init; }
    public DateTime DueDate { get; init; }
    public DateTime? PaymentDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public Guid StudentId { get; init; }
    public string StudentName { get; init; } = string.Empty;
    public string ClassName { get; init; } = string.Empty;
    public Guid ParentId { get; init; }
    public string ParentName { get; init; } = string.Empty;
    public string? TransactionId { get; init; }
}

public record PayFeeDto(
    string Method, // ex: "VodafoneCash" or "InstaPay"
    string Reference, // رقم الهاتف أو الحساب
    string TransactionId // كود العملية لو متاح
);

public class FeeStatsDto
{
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal PendingAmount { get; set; }
    public decimal OverdueAmount { get; set; }

    public int PaidCount { get; set; }
    public int PendingCount { get; set; }
    public int OverdueCount { get; set; }

    public double CollectionRate => TotalAmount == 0 ? 0 : (double)PaidAmount / (double)TotalAmount * 100;
}
