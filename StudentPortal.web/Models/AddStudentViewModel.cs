using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;

namespace StudentPortal.web.Models
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Suscriber { get; set; }
    }
}
