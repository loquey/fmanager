using Dapper;
using Moq;
using System;
using System.Data;
using Xunit;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{
    using db.Entitties;
    using db.Repositories;
    using System.Threading.Tasks;

    public class ProjectRepositoryExecuteTest
    {

        private Mock<IDbConnection> _dbconnMock;
        private IRepository<ProjectEntity> _repo;

        public ProjectRepositoryExecuteTest()
        {
            _dbconnMock = new Mock<IDbConnection>();
            _dbconnMock.Setup(moq => moq.Execute(It.IsAny<string>(), It.IsAny<ProjectEntity>(), null, null, null)).Returns(1);
            _repo = new ProjectRepository(_dbconnMock.Object);
        }

        [Fact]
        public void AddEntityToRepositoryTest()
        {
            _repo.Add(new ProjectEntity());
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<ProjectEntity>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task AddNullEntityToRepositoryTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repo.Add(null));
        }

        [Fact]
        public void DeleteEntityFromRepositoryTest(Action<ProjectEntity> method)
        {
            _repo.Delete(new ProjectEntity());
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task DeleteEntityFromRepositoryWithNullEntityTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repo.Delete(null));
        }

        [Fact]
        public void UpdateEntityInRepository()
        {
            _repo.Update(new ProjectEntity());
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task UpdateEntityWithNullEntityTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repo.Update(null));
        }
    }
}
