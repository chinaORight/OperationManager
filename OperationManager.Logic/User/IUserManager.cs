using OperationManager.Common;
using OperationManager.Model.User;
using OperationManager.ServiceModel.Route;

namespace OperationManager.Logic.User
{
    public interface IUserManager
    {
        TableSource<UserInfoModel> GetUserTable(GetUserTable param);

        UserInfoModel GetUserDetailByUserName(string username);

    }
}