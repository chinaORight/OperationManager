using OperationManager.Common;
using OperationManager.Model.User;
using OperationManager.ServiceModel.Route;
using ServiceStack.OrmLite;

namespace OperationManager.Logic
{
    public class CommonManager : BaseManager, ICommonManager
    {
        public T GetDetailById<T>(int id)
        {
            using (var db = DbFactory.Open())
            {
                if (id == 0)
                    return default(T);

                return db.SingleById<T>(id);

            }
        }



    }
}
