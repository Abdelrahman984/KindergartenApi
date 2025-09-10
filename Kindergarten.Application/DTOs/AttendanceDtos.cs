namespace Kindergarten.Application.DTOs;

public record AttendanceCreateDto(Guid StudentId, DateTime Date, bool IsPresent);
public record AttendanceReadDto(Guid Id, Guid StudentId, DateTime Date, bool IsPresent);
public record AttendanceRateDto(Guid StudentId, DateTime From, DateTime To, int PresentDays, int TotalDays, double Rate);
public record AttendanceAggregateRateDto(DateTime From, DateTime To, int PresentDays, int TotalDays, double Rate);
