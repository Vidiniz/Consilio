using ConsilioServices.Domain.Entities;
using ConsilioServices.Infrastructure.Data.Repository;
using NUnit.Framework;
using System.Linq;

namespace ConsilioServices.Tests.Infrastructure.Data
{
    public class SystemProfileRepositoryTest
    {
        private SystemProfileRepository _systemProfileRepository;

        [SetUp]
        public void Setup()
        {
            _systemProfileRepository = new SystemProfileRepository();
        }

        [Test]
        public void TestSetItem()
        {         
            Assert.AreEqual(true, InsertItem() > 0 ? true : false);
            RemoveItem();
        }

        [Test]
        public void TestUpdateItem()
        {
            int result = 0;
            InsertItem();

            var getItem = GetByName();

            if (getItem != null)
                result = _systemProfileRepository.Update(getItem);

            Assert.AreEqual(true, result > 0 ? true : false);

            RemoveItem();
        }

        [Test]
        public void TestGetById()
        {
            InsertItem();

            Assert.AreEqual("Teste", GetById().Name);

            RemoveItem();
        }

        [Test]
        public void TestGetByName()
        {
            InsertItem();

            Assert.AreEqual("Teste", GetByName().Name);

            RemoveItem();
        }

        [Test]
        public void TestGetByNameStringNull()
        {
            var result = _systemProfileRepository.GetByName(string.Empty);

            Assert.AreEqual(true, result.Count() == 0 ? true : false);
        }

        [Test]
        public void TestRemove()
        {
            InsertItem();

            Assert.AreEqual(true, RemoveItem() > 0 ? true : false);
        }

        private int InsertItem()
        {
            var systemProfile = new SystemProfile
            {
                Name = "Teste",
                HasAdmin = true,
                SystemUsers = null
            };

            return _systemProfileRepository.Add(systemProfile);
        }

        private SystemProfile GetByName()
        {
            var result = _systemProfileRepository.GetByName("Teste");

            if (result.Count() == 0)
                return null;

            return result.ToList().FirstOrDefault();
        }

        private SystemProfile GetById()
        {
            var resultSystemProfile = GetByName();

            if (resultSystemProfile != null)
                return _systemProfileRepository.GetById(resultSystemProfile.Id);

            return null;
        }

        private int RemoveItem()
        {
            var resultSystemProfile = GetByName();

            if (resultSystemProfile != null)
                return _systemProfileRepository.Remove(resultSystemProfile);

            return 0;
        }
    }
}
