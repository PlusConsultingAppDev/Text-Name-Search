using Krummert.DLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Krummert.BLL.Bases
{
    public class _BaseCrud<BllModel, DllRepo, DllModel>
        where BllModel : BLL.Bases._BaseModel<DllModel>
        where DllRepo : DLL.Bases._BaseRepository<DllModel>
        where DllModel : DLL.Bases._BaseModel
    {
        protected static BllModel _Instance = Activator.CreateInstance<BllModel>();
        protected DllRepo _Repo;

        public _BaseCrud()
        {
            _Repo = Activator.CreateInstance<DllRepo>();
        }

        public BllModel Save(BllModel t)
        {
            return (BllModel)_Instance.Adapt(_Repo.Save(t.Adapt()));
        }
        public void Delete(Guid id)
        {
            _Repo.Delete(id);
        }
        public BllModel Read(Guid id)
        {
            return (BllModel)_Instance.Adapt(_Repo.Read(id));
        }
        public List<BllModel> Read()
        {
            return _Repo.Read().Select(m => (BllModel)_Instance.Adapt(m)).ToList();
        }
        public List<BllModel> Read(string propertyName, Guid foreignKey)
        {
            return _Repo.Read(propertyName, foreignKey).Select(m => (BllModel)_Instance.Adapt(m)).ToList();
        }
    }
}
