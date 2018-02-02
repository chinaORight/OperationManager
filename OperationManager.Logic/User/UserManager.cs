using OperationManager.Common;
using OperationManager.Model.User;
using OperationManager.ServiceModel.Route;
using ServiceStack.OrmLite;

namespace OperationManager.Logic.User
{
    public class UserManager : BaseManager, IUserManager
    {
        public TableSource<UserInfoModel> GetUserTable(GetUserTable param)
        {
            using (var db = DbFactory.Open())
            {
                var builder = db.From< UserInfoModel>();

                if (!string.IsNullOrEmpty(param.DisplayName))
                    builder.Where(x => x.DisplayName.Contains(param.DisplayName) || x.UserName.Contains(param.DisplayName));

                var total = db.Count(builder);

                builder.Limit(param.Offset, param.Limit);

                var userlist = db.Select(builder);

                return new TableSource<UserInfoModel> { Rows = userlist, Total = total };
            }
        }


        public UserInfoModel GetUserDetailByUserName(string username)
        {
            using (var db = DbFactory.Open())
            {
                if (string.IsNullOrEmpty(username))
                    return null;

                return db.Single((UserInfoModel x) => x.UserName == username);

            }
        }




    }
}