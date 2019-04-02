using Krummert.DLL.Models;
using System;
using System.Collections.Generic;

namespace Krummert.DLL.Bases
{
    public class _BaseRepository<T> where T : _BaseModel
    {
        protected static Dictionary<Guid, T> _PrivateRepo;
        private static object _Locker;

        static _BaseRepository()
        {
            _PrivateRepo = new Dictionary<Guid, T>();
            _Locker = new object();
        }

        public virtual void Delete(Guid id)
        {
            lock (_Locker)
            {
                if (_PrivateRepo.ContainsKey(id))
                {
                    _PrivateRepo.Remove(id);
                }
            }
        }
        public virtual T Save(T t)
        {
            lock (_Locker)
            {
                if(t.ID == Guid.Empty)
                {
                    t.ID = Guid.NewGuid();
                }

                if (_PrivateRepo.ContainsKey(t.ID))
                {
                    _PrivateRepo[t.ID] = t;
                }
                else
                {
                    _PrivateRepo.Add(t.ID, t);
                }
            }

            return t;
        }
        public T Read(Guid id)
        {
            if (_PrivateRepo.ContainsKey(id))
            {
                return _PrivateRepo[id];
            }

            return null;
        }
        public List<T> Read()
        {
            var returnCollection = new List<T>();

            foreach(var key in _PrivateRepo.Keys)
            {
                returnCollection.Add(_PrivateRepo[key]);
            }

            return returnCollection;
        }
        public List<T> Read(string propertyName, Guid foreignKey)
        {
            var pi = typeof(T).GetProperty(propertyName);

            var returnCollection = new List<T>();
            foreach (var key in _PrivateRepo.Keys)
            {
                if((Guid)pi.GetValue(_PrivateRepo[key]) == foreignKey)
                {
                    returnCollection.Add(_PrivateRepo[key]);
                }
            }

            return returnCollection;
        }
    }
}
