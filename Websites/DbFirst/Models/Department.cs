using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbFirst.Models;

public partial class Department
{
    public int DeptNo { get; set; }

    [Display(Name = "Department")]
    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
