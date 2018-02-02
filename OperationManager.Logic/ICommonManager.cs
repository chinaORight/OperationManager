using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Logic
{
    public interface ICommonManager
    {
        T GetDetailById<T>(int id);

      
    }
}
