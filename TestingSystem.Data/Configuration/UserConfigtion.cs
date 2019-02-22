using TestingSystem.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace TestingSystem.Data.Configuration 
{
    class UserConfigtion : EntityTypeConfiguration<User>
    {
        public UserConfigtion()
        {
            
        }
    }
}
