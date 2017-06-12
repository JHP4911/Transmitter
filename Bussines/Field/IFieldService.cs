using Data.Entity;
using System.Collections.Generic;

namespace Bussines
{
    public interface IFieldService : IBaseService<Field>
    {
        IList<FieldType> getFeildTypes();
    }
}