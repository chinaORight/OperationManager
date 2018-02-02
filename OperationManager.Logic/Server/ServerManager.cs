using System.Linq;
using OperationManager.Common;
using OperationManager.Model;
using OperationManager.ServiceModel.ServerRoute;
using ServiceStack.OrmLite;

namespace OperationManager.Logic.ServerManage
{
    public class ServerManager : BaseManager, IServerManager
    {
        public TableSource<ServerInfoModel> GetServerTable(GetServerTable param)
        {
            using (var db = DbFactory.Open())
            {
                var builder = db.From<ServerInfoModel>();

                if (!string.IsNullOrEmpty(param.ServerName))
                    builder.Where(x => x.ServerName.Contains(param.ServerName));

                var total = db.Count(builder);

                builder.Limit(param.Offset, param.Limit);

                var userlist = db.Select(builder);

                return new TableSource<ServerInfoModel> { Rows = userlist, Total = total };
            }
        }
        public ServerInfoModel GetServerByServerName(string servername)
        {
            using (var db = DbFactory.Open())
            {
                if (string.IsNullOrEmpty(servername))
                    return null;

                return db.Single((ServerInfoModel x) => x.ServerName== servername);

            }
        }
        public bool RemoveServer(RemoveServer param)
        {
            using (var db = DbFactory.Open())
            {

                return db.Delete<ServerInfoModel>(p => p.Id ==param.Id) > 0L;
            }
           
        }


    }


}

