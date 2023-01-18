using FluentValidation;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Validators;

public class EmployeeValidator:AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(employee => employee.Password).NotNull().Length(8, 16).WithMessage("Password length must be between 8 and 16 characters");
        RuleFor(employee => employee.Email).NotNull().EmailAddress();
        RuleFor(employee => employee.Email).Must(ValidateEmailUniqueness).WithMessage("Email already registered");

    }

    private bool ValidateEmailUniqueness(string email)
    {
        // Business Logic
        return true;
    }
}