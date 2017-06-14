using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bussines
{
    public class FieldValueService : BaseService<FieldValue>, IFieldValueService
    {
        IRepository<Unit> _unit;
        public FieldValueService(
            IRepository<FieldValue> repo,
            IRepository<Unit> unit) : base(repo)
        {
            _unit = unit;
        }
        public void InsertValue(string appKey, List<FieldValue> values)
        {
            var unit = _unit.GetById(appKey);
            Field field;
            foreach (var item in values)
            {
                field = unit.Fields.Where(x => x.Id == item.FieldId).FirstOrDefault();
                field.FieldValue.Add(item);
                checkFieldRegulation(field, item);
            }
            _unit.Update(unit);
        }

        private void checkFieldRegulation(Field field, FieldValue item)
        {

            //switch (rule.ConditionType)
            //{
            //case CONDITION_TYPE.BUYUK:
            //    if(item.Value>rule.Condition)
            //    break;
            //case CONDITION_TYPE.KUCUK:
            //    break;
            //case CONDITION_TYPE.ESIT:
            //    break;
            //case CONDITION_TYPE.FARKLI:
            //    break;
            //default:
            //    break;
            // }

        }
    }
}
