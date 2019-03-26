using Dapper;
using Moq;
using System;
using System.Data;
using Xunit;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{
    using db.Entitties;
    using db.Repositories;

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
        public void AddNullEntityToRepositoryTest()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.Add(null));
        }

        [Fact]
        public void DeleteEntityFromRepositoryTest(Action<ProjectEntity> method)
        {
            _repo.Delete(new ProjectEntity);
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public void DeleteEntityFromRepositoryWithNullEntityTest()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.Delete(null));
        }

        [Fact]
        public void UpdateEntityInRepository()
        {
            _repo.Update(new ProjectEntity());
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public void UpdateEntityWithNullEntityTest()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.Update(null));
        }
    }
}
