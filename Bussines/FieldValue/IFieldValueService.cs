using System.Collections.Generic;
using Data.Entity;

namespace Bussines
{
    public interface IFieldValueService : IBaseService<FieldValue>
    {       
        
        void InsertValue(string appKey, List<FieldValue> values);
    }
}