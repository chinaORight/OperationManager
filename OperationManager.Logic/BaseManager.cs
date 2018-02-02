using ServiceStack;
using ServiceStack.Caching;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using ServiceStack.Auth;
using OperationManager.Model;
using OperationManager.Model.User;

namespace OperationManager.Logic
{
    public class BaseManager
    {
        public int _UserId
        {
            get
            {
                var session = HostContext.AppHost.Resolve<ICacheClient>().SessionAs<CustomUserSession>();
                return Convert.ToInt32(session.UserAuthId);
            }
        }

        public string _UserName
        {
            get
            {
                var session = HostContext.AppHost.Resolve<ICacheClient>().SessionAs<CustomUserSession>();
                return session.UserAuthName;
            }
        }

        public string _DisplayName
        {
            get
            {
                var session = HostContext.AppHost.Resolve<ICacheClient>().SessionAs<CustomUserSession>();
                return session.DisplayName;
            }
        }

        public string _Role
        {
            get
            {
                var session = HostContext.AppHost.Resolve<ICacheClient>().SessionAs<CustomUserSession>();
                return session.Role.ToString();
            }
        }

        public string _Mobile
        {
            get
            {
                var session = HostContext.AppHost.Resolve<ICacheClient>().SessionAs<CustomUserSession>();
                return session.Mobile;
            }
        }

        public IDbConnectionFactory DbFactory { get; set; }

        protected IDbConnection GetConnection()
        {
            return DbFactory.Open();
        }

        
    }
}