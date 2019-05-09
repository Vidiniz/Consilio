using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Services
{
    public class TopicAccessService : ServiceBase<TopicAccess>, ITopicAccessService
    {
        private readonly ITopicAccessRepository _topicAccessRepository;

        public TopicAccessService(ITopicAccessRepository topicAccessRepository) : base(topicAccessRepository)
        {
            _topicAccessRepository = topicAccessRepository;
        }

        public IEnumerable<TopicAccess> GetAllWithMenuAccess()
        {
            return _topicAccessRepository.GetAllWithMenuAccess();
        }
    }
}
