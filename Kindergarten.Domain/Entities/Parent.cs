namespace Kindergarten.Domain.Entities;

public class Parent
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FullName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string? Address { get; private set; } = null!;

    // Relationships
    public ICollection<Student> Childrens { get; private set; } = new List<Student>();
    public ICollection<Fee> Fees { get; private set; } = new List<Fee>();

    // Auth
    public string? ApplicationUserId { get; private set; }
    public ApplicationUser? User { get; private set; }
    // domain method to link
    public void LinkApplicationUser(string applicationUserId)
    {
        ApplicationUserId = applicationUserId;
    }

    private Parent() { }

    public Parent(string fullName, string phoneNumber, string? address = "")
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public void UpdateInfo(string fullName, string phoneNumber, string? address = "")
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
