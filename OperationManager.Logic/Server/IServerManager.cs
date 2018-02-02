using OperationManager.Common;
using OperationManager.Model;
using OperationManager.ServiceModel.ServerRoute;

namespace OperationManager.Logic.ServerManage
{
    public interface IServerManager
    {
        TableSource<ServerInfoModel> GetServerTable(GetServerTable param);
        ServerInfoModel GetServerByServerName(string servername);
        bool RemoveServer(RemoveServer param);

    }
}
