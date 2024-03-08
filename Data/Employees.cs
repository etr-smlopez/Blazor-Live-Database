using Microsoft.EntityFrameworkCore;

namespace Blazor.Live.Database.Data
{
    [Keyless]
    public class Employees
    {

        public int EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}