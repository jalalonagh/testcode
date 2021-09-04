using Entities.User;
using ManaBaseData.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DataTest
{
    public class InitializeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ResponseTest()
        {
            var mockRepo = new Mock<IRepository<User>>();
            var result = await mockRepo.Object.FetchByIdAsync(1);
            Assert.Null(result);
        }

        [Test]
        public async Task ResponseTestTrue()
        {
            var mockRepo = new Mock<IRepository<User>>();
            var result = await mockRepo.Object.FetchByIdAsync(1163);
            Assert.NotNull(result);
        }
    }
}