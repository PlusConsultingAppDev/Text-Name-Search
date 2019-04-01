using System;

namespace Krummert.BLL.Bases
{
    public abstract class _BaseModel<T>
        where T : DLL.Bases._BaseModel
    {
        public Guid Id { get; set; }
        public abstract T Adapt();
        public abstract _BaseModel<T> Adapt(T t);
    }
}