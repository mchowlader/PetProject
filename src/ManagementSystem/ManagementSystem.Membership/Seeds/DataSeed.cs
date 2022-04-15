using ManagementSystem.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Membership.Seeds
{
    public class DataSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role{Id = Guid.NewGuid(), Name ="SuperAdmin", NormalizedName="SUPERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new Role{Id = Guid.NewGuid(), Name ="InstituteAdmin", NormalizedName="INSTITUTEADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new Role{Id = Guid.NewGuid(), Name ="Student", NormalizedName="STUDENT", ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new Role{Id = Guid.NewGuid(), Name ="Teacher", NormalizedName="TEACHER", ConcurrencyStamp = Guid.NewGuid().ToString()}
                };
            }
        }
    }
}
