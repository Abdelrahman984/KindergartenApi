using Kindergarten.Domain.Enums;

namespace Kindergarten.Domain.Entities;

public class Fee
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public FeeStatus Status { get; private set; }  // Enum: Paid, Pending, Overdue
    public string? TransactionId { get; private set; } = string.Empty; // Optional: to store payment transaction reference
    // Relationships
    public Guid StudentId { get; private set; }
    public Student Student { get; private set; } = null!;

    public Guid ParentId { get; private set; }
    public Parent Parent { get; private set; } = null!;

    private Fee() { }

    public Fee(decimal amount, DateTime dueDate, Guid studentId, Guid parentId)
    {
        Amount = amount;
        DueDate = dueDate;
        StudentId = studentId;
        ParentId = parentId;
        Status = FeeStatus.Pending;
    }

    public void MarkAsPaid(string? transactionId = "")
    {
        Status = FeeStatus.Paid;
        PaymentDate = DateTime.UtcNow;
        TransactionId = transactionId;
    }

    public void MarkAsOverdue()
    {
        if (Status == FeeStatus.Pending && DateTime.UtcNow > DueDate)
            Status = FeeStatus.Overdue;
    }
}
