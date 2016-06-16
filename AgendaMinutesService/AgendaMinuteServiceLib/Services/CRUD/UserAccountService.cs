using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class UserAccountService
    {
        private DataAccess mDataAccess;

		public static UserAccountService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<UserAccountService>(info);
		}
		
        private UserAccountService() { }

        internal static UserAccountService Create(DataAccess da)
        {
            return new UserAccountService { mDataAccess = da };
        }

        public AMAPI.UserAccount Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.User.SelectUserAccount<LMUserAccount>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("UserAccount", id);

            return MappingHelper.MapLMDataObject<LMUserAccount, AMAPI.UserAccount>(mDataAccess, record, fields);  
        }
    }
}
