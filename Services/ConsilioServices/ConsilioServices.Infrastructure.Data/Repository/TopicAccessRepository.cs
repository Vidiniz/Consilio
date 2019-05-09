using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class TopicAccessRepository : RepositoryBase<TopicAccess>, ITopicAccessRepository
    {
        public IEnumerable<TopicAccess> GetAllWithMenuAccess()
        {
            return _dataBase.Set<TopicAccess>().Include(topicAccess => topicAccess.MenuAccesses).ToList();
        }
    }
}
