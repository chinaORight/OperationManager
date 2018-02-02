using OperationManager.Common;
using OperationManager.Model;
using OperationManager.ServiceModel.Route;
using OperationManager.ServiceModel.ServerRoute;

namespace OperationManager.Logic.ItemManage
{
    public interface IProgramManager
    {
        TableSource<ProgramInfoModel> GetProgramTable(GetProgramTable param);
        ProgramInfoModel GetProgramByItemName(string itemname);
    }
}
