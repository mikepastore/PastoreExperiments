using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class FileFormatService
    {
        private DataAccess mDataAccess;

		public static FileFormatService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<FileFormatService>(info);
		}
		
        private FileFormatService() { }

        internal static FileFormatService Create(DataAccess da)
        {
            return new FileFormatService { mDataAccess = da };
        }

        public AMAPI.FileFormat Get(String id, string[] fields)
        {            
            var record = mDataAccess.LegiFile.SelectFileFormat<LMFileFormat>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("FileFormat", id);

            return MappingHelper.MapLMDataObject<LMFileFormat, AMAPI.FileFormat>(mDataAccess, record, fields);  
        }
    }
}
