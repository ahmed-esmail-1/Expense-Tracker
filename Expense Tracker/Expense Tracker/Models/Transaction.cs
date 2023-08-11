using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    // Define the Transaction class
    public class Transaction
    {
        // Primary key for the Transaction entity
        [Key]
        public int TransactionId { get; set; }

        // Foreign key to relate Transaction with Category
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Navigation property to create foreign key for integrity

        // Transaction amount validation
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        // Note associated with the transaction
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        // Transaction date (defaults to current date)
        public DateTime Date { get; set; } = DateTime.Now.Date;

        // Computed property combining Category icon and title
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        // Computed property for formatting amount with symbol based on type
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}
