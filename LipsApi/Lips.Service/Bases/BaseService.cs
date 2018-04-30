using AutoMapper;
using Lips.Domain.Bases;
using Lips.Dto.Bases;
using Lips.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Bases
{
    public class BaseService<Dto, Domain> : IBaseService<Dto>
        where Dto : BaseDto
        where Domain : Base
    {
        public virtual IBaseRepository<Domain> Repository { get; set; }

        public BaseService(IBaseRepository<Domain> repository ){
            this.Repository = repository;
        }
        protected virtual T GetRepository<T>()
        {
            return (T)Repository;
        }


        public Dto Create(Dto item)
        {
            var domain = Mapper.Map<Dto, Domain>(item);
            Repository.Add(domain);
            Repository.SaveChanges();
            return Mapper.Map<Domain, Dto>(domain);
        }

        public Dto CreateOrUpdate(Dto item)
        {
            var domain = Mapper.Map<Dto, Domain>(item);
            Repository.AddOrUpdate(domain);
            Repository.SaveChanges();
            return Mapper.Map<Domain, Dto>(domain);
        }

        public Dto Get(long id)
        {
            var domain = Repository.SingleOrDefault(p => p.Id == id);
            return Mapper.Map<Domain, Dto>(domain);
        }

        public List<Dto> GetAll()
        {
            return Mapper.Map<IEnumerable<Domain>, IEnumerable<Dto>>(Repository.GetAll()).ToList();
        }

        public Dto Update(Dto item)
        {
            var domain = Mapper.Map<Dto, Domain>(item);
            Repository.Update(domain);
            Repository.SaveChanges();
            return Mapper.Map<Domain, Dto>(domain);
        }
    }
}
