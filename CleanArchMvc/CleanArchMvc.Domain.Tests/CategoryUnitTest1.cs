using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Validate Category Creation With Valid Parameters")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Test Category");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Validate Category Creation With Negative Id")]
        public void CreateCategory_WithNegativeId_ResultDomainException()
        {
            Action action = () => new Category(-1, "Test Category");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Id should be greater than 0.");
        }

        [Fact(DisplayName = "Validate Category Creation With Empty Name")]
        public void CreateCategory_EmptyName_ResultDomainException()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Validate Category Creation With Short Name")]
        public void CreateCategory_ShortName_ResultDomainException()
        {
            Action action = () => new Category(1, "ab");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name should be at least 3 characters long.");
        }
    }
}