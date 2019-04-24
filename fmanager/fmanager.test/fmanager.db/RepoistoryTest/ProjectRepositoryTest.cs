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

        private Mock<IDbConnection> _DbconnMock;
        private IRepository<ProjectEntity> _Repo;

        public ProjectRepositoryExecuteTest()
        {
            _DbconnMock = new Mock<IDbConnection>();
            _DbconnMock.Setup(moq => moq.Execute(It.IsAny<string>(), It.IsAny<ProjectEntity>(), null, null, null)).Returns(1);
            _Repo = new ProjectRepository(_DbconnMock.Object);
        }

        [Fact]
        public void AddEntityToRepositoryTest()
        {
            _Repo.Add(new ProjectEntity());
            _DbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<ProjectEntity>(), null, null, null), Times.Once());
        }

        //[Fact]
        //public void AddListOfEntitiesTest()
        //{
        //    _Repo(A)
        //}

        [Fact]
        public async Task AddNullEntityToRepositoryTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _Repo.Add((ProjectEntity)null));
        }

        [Fact]
        public void DeleteEntityFromRepositoryTest(Action<ProjectEntity> method)
        {
            _Repo.Delete(new ProjectEntity());
            _DbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task DeleteEntityFromRepositoryWithNullEntityTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _Repo.Delete(null));
        }

        [Fact]
        public void UpdateEntityInRepository()
        {
            _Repo.Update(new ProjectEntity());
            _DbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task UpdateEntityWithNullEntityTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _Repo.Update(null));
        }
    }
}
