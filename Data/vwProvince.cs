 
using Microsoft.EntityFrameworkCore;

namespace Blazor.Live.Database.Data
{
    [Keyless]
    public class vwProvince
    {
 
        public string Code { get; set; }

        public string Description { get; set; }
    }
}