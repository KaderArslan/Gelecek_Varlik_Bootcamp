using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Models;

namespace Workfollow.Dal.Abstract
{
    public interface IEmployeeRepository
    {
        //bana employee dondurur
        Employee Login(Employee login);

        Employee Add(Employee item);

        Employee Update(Employee item);

    }
}
