using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;


namespace Bussines
{
    public class RegulationService : BaseService<Regulation>, IRegulationService
    {
        IRepository<Regulation> _repo;


        public RegulationService(IRepository<Regulation> repo) : base(repo)
        {
            _repo = repo;

        }

    }
}
