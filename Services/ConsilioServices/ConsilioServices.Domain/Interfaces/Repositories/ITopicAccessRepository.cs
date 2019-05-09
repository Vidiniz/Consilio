using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface ITopicAccessRepository : IRepositoryBase<TopicAccess>
    {
        IEnumerable<TopicAccess> GetAllWithMenuAccess();
    }
}
