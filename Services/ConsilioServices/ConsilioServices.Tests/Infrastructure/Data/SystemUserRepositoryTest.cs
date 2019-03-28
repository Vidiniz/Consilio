using ConsilioServices.Domain.Entities;
using ConsilioServices.Infrastructure.Data.Repository;
using NUnit.Framework;
using System;

namespace ConsilioServices.Tests.Infrastructure.Data
{
    public class SystemUserRepositoryTest
    {
        private SystemUserRepository _systemUserRepository;

        [SetUp]
        public void Setup()
        {
            _systemUserRepository = new SystemUserRepository();
        }

        [Test]
        public void TestReturnGetByName()
        {
            _systemUserRepository.GetByName(""); 
            Assert.Pass();
        }


        public void TestSetItem()
        {
            var systemUser = new SystemUser
            {
                Id              = 1,
                Name            = "Teste",
                LastName        = "Teste",
                Email           = "teste@teste.com.br",
                Password        = "1234",
                RegisterDate    = DateTime.Now,
                Status          = true,
                SystemProfile   = null,
                SystemProfileId = 1
            };

            _systemUserRepository.Add(systemUser);


        }
    }
}
