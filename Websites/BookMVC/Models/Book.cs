using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMVC.Models;

public partial class Book
{
    [Required]
    public int BookId { get; set; }

    [Required]
    public string BookName { get; set; } = null!;

    [Required]
    public string BookAuthor { get; set; } = null!;

    [Required]
    public decimal BookPrice { get; set; }
}
