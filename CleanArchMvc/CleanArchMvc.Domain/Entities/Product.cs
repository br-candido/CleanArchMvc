using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }

        public int CategoryId { get;  set; }
        public Category Category { get;  set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name should be at least 3 characters long.");
            DomainExceptionValidation.When(name.Length > 30, "Invalid name. Name should be at most 30 characters long.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description. description should be at least 5 characters long.");

            DomainExceptionValidation.When(price < 0, "Invalid Price Value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock Value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid Image. Image should be at most 250 characters long.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string? image)
        {
            DomainExceptionValidation.When(id < 0, "Id Invalid.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}
