using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices
{
    public interface IPermissionService
    {
        bool CheckPermission(int permissionId, int userId);

    }
}
