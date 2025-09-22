using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Model
{
    public class Employee
    {
            public int Id { get; set; }               
            public string Name { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
            
            [Column(TypeName = "decimal(18,2)")]
            public decimal Salary { get; set; }
        
    }
}

