using Core.Models.Concrete;

namespace WebUI.Areas.Admin.ViewModels
{
    public class AddUserRoleVM
    {
        public User User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
