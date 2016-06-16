using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any2Any
{
    public class FileSystemService : IEntityService
    {
        public Result TryRead(Entity e)
        {
            var file = new FileInfo(e.Key);
            var folder = new DirectoryInfo(e.Key);

            if (file.Exists)
            {
                e.Data = file;
                return Result.Success();
            }
            else if(folder.Exists)
            {
                e.Data = folder;
                return Result.Success();
            }
            else
            {
                return new Result { ResultType = ResultType.Error };
            }
            
        }

        public Result TryWrite(Entity e)
        {
            return new Result { ResultType = ResultType.NotSupported };
        }

        public Result FillChildren(Entity e)
        {
            var file = e.GetData<FileInfo>();
            if (file != null)
                return Result.NotSupported();

            var folder = e.GetData<DirectoryInfo>();
            if (folder == null)
                return Result.InsufficientData("Folder data not loaded");

            var entities = new List<Entity>();
            entities.AddRange(folder.GetFiles().Select(f =>
                new Entity { Key = f.FullName, Data = f, Parents = new Entity[] { e } }));

            entities.AddRange(folder.GetDirectories().Select(f =>
                new Entity { Key = f.FullName, Data = f, Parents = new Entity[] { e } }));

            e.Children = entities.ToArray();

            return Result.Success();
                
        }

        public Result FillParents(Entity e)
        {
            var file = e.GetData<FileInfo>();
            if (file == null)
                return Result.InsufficientData("File data not loaded");

            var parent = file.Directory;
            e.Parents = new Entity[] { 
                new Entity { Key = parent.FullName, Data = parent } 
            };

            return Result.Success();
        }
    }

}
