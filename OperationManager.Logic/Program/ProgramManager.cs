using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationManager.Common;
using OperationManager.Model;
using OperationManager.ServiceModel.Route;
using ServiceStack.OrmLite;
using OperationManager.ServiceModel.ServerRoute;

namespace OperationManager.Logic.ItemManage
{
   public  class ProgramManager:BaseManager,IProgramManager
    {
        public TableSource<ProgramInfoModel> GetProgramTable(GetProgramTable param)
        {
            using (var db = DbFactory.Open())
            {
                var builder = db.From<ProgramInfoModel>();

                if (!string.IsNullOrEmpty(param.ItemName))
                    builder.Where(x => x.ProgramName.Contains(param.ItemName));

                var total = db.Count(builder);

                builder.Limit(param.Offset, param.Limit);

                var userlist = db.Select(builder);

                return new TableSource<ProgramInfoModel> { Rows = userlist, Total = total };
            }
        }

        public ProgramInfoModel GetProgramByItemName(string itemname)
        {
            using (var db = DbFactory.Open())
            {
                if (string.IsNullOrEmpty(itemname))
                    return null;

                return db.Single((ProgramInfoModel x) => x.ProgramName == itemname);

            }
        }
    }
}
