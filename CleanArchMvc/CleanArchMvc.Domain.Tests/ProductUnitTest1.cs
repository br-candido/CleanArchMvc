using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Validate Product Creation With Valid Parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Test Product","Test Description", 12.90m, 9, "mock_image_string" );
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Validate Product Creation With Invalid Id")]
        public void CreateProduct_WithInvalidId_ResultDomainException()
        {
            Action action = () => new Product(-1, "Test Product", "Test Description", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Id Invalid.");
        }

        [Fact(DisplayName = "Validate Product Creation With Empty Name")]
        public void CreateProduct_WithEmptyName_ResultDomainException()
        {
            Action action = () => new Product(1, "", "Test Description", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Validate Product Creation With Short Name")]
        public void CreateProduct_WithShortName_ResultDomainException()
        {
            Action action = () => new Product(1, "Te", "Test Description", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name should be at least 3 characters long.");
        }

        [Fact(DisplayName = "Validate Product Creation With Long Name")]
        public void CreateProduct_WithLongName_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product With An Absurdly Long And Unnescessary Extense Name To Break This Product", "Test Description", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name should be at most 30 characters long.");
        }

        [Fact(DisplayName = "Validate Product Creation With Empty Description")]
        public void CreateProduct_WithEmptyDescription_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. description is required.");
        }

        [Fact(DisplayName = "Validate Product Creation With Short Description")]
        public void CreateProduct_WithShortDescription_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "Desc", 12.90m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. description should be at least 5 characters long.");
        }

        [Fact(DisplayName = "Validate Product Creation With Invalid stock")]
        public void CreateProduct_WithInvalidStock_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "Test Description", 12.90m, -9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock Value");
        }

        [Fact(DisplayName = "Validate Product Creation With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "Test Description", -1.3m, 9, "mock_image_string");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price Value");
        }

        [Fact(DisplayName = "Validate Product Creation With Long Image String")]
        public void CreateProduct_WithLongImageString_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "Test Description", 1.3m, 9, "1816224259825007378451726\r\n6381347973970379203620378\r\n9778930951220909723058561\r\n8021662970240254485803040\r\n6129986503990947215976671\r\n4657317085966673982127984\r\n1338337542469566345840246\r\n8863575785332054450214410\r\n3927563858361558034915529\r\n6487321135961922669256854");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image. Image should be at most 250 characters long.");
        }

        [Fact(DisplayName = "Validate Product Creation With Null Image String")]
        public void CreateProduct_WithNullImageString_ResultDomainException()
        {
            Action action = () => new Product(1, "Test Product", "Test Description", 1.3m, 9, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
