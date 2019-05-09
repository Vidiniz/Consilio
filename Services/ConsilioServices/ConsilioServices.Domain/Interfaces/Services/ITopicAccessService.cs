using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface ITopicAccessService: IServiceBase<TopicAccess>
    {
        IEnumerable<TopicAccess> GetAllWithMenuAccess();
    }
}
