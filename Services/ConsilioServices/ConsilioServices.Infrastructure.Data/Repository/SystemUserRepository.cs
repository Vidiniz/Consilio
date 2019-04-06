using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemUserRepository : RepositoryBase<SystemUser>, ISystemUserRepository
    {
        public override SystemUser GetById(int id)
        {
            return (from user in _dataBase.Set<SystemUser>()
                    join profile in _dataBase.Set<SystemProfile>() on user.SystemProfileId equals profile.Id
                    where user.Id.Equals(id)
                    select user).FirstOrDefault(); 
        }

        public SystemUser GetExactEmail(string email)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Email.Equals(email))
                                                                   .FirstOrDefault();
        }

        public IEnumerable<SystemUser> GetByEmail(string email)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Email.Contains(email))
                                                                   .ToList();
        }

       
        public IEnumerable<SystemUser> GetByName(string name)
        {
            return (from result in _dataBase.Set<SystemUser>()
                    where result.Name.Contains(name)
                    || result.LastName.Contains(name)
                    select result).ToList();
        }

        public SystemUser Login(string user, string password)
        {
            return (from dataUser in _dataBase.Set<SystemUser>()
                    join profile in _dataBase.Set<SystemProfile>() on dataUser.SystemProfileId equals profile.Id
                    where dataUser.Email.Equals(user) 
                       && dataUser.Password.Equals(password)
                    select new SystemUser
                    {
                        Id              = dataUser.Id,
                        Email           = dataUser.Email,
                        LastName        = dataUser.LastName,
                        Name            = dataUser.Name,
                        Password        = dataUser.Password,
                        RegisterDate    = dataUser.RegisterDate,
                        Status          = dataUser.Status,
                        SystemProfile   = profile,
                        SystemProfileId = dataUser.SystemProfileId
                    }).FirstOrDefault();            
        }
    }
}
