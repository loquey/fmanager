using Dapper;
using fmanager.db.Entitties;
using fmanager.db.Repositories;
using Moq;
using System;
using System.Data;
using Xunit;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{

    public class ProjectLinkRepositoryTest
    {
        private Mock<IDbConnection> _dbconnMock;
        private IRepository<ProjectLinkEntity> _repo;

        public ProjectLinkRepositoryTest()
        {
            _dbconnMock = new Mock<IDbConnection>();
            _dbconnMock.Setup(moq => moq.Execute(It.IsAny<string>(), It.IsAny<ProjectLinkEntity>(), null, null, null)).Returns(1);
            _repo = new ProjectLinkRepository(_dbconnMock.Object);
        }

        [Fact]
        public void AddEntityToRepositoryTest()
        {
            _repo.Add(new ProjectLinkEntity());
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
            _repo.Delete(new ProjectLinkEntity());
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
            _repo.Update(new ProjectLinkEntity());
            _dbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public void UpdateEntityWithNullEntityTest()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.Update(null));
        }
        

        [Fact]
        public void LoadEntityWithGuidTest()
        {
            //loads data from database
            //returns a single instance 
        }

        [Fact]
        public void loadAllEntityTest()
        {
            //load data from databsae 
            //returns list of entity
        }
    }
}
