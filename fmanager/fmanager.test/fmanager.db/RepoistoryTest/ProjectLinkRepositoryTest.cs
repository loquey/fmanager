using Dapper;
using fmanager.db.Entitties;
using fmanager.db.Repositories;
using Moq;
using System;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{

    public class ProjectLinkRepositoryTest
    {
        private Mock<IDbConnection> _DbconnMock;
        private IRepository<ProjectLinkEntity> _Repo;

        public ProjectLinkRepositoryTest()
        {
            _DbconnMock = new Mock<IDbConnection>();
            _DbconnMock.Setup(moq => moq.Execute(It.IsAny<string>(), It.IsAny<ProjectLinkEntity>(), null, null, null)).Returns(1);
            _Repo = new ProjectLinkRepository(_DbconnMock.Object);
        }

        [Fact]

        public void AddEntityToRepositoryTest()
        {
            _Repo.Add(new ProjectLinkEntity());
            _DbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<ProjectEntity>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task AddNullEntityToRepositoryTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _Repo.Add((ProjectLinkEntity)null));
        }

        [Fact]
        public void DeleteEntityFromRepositoryTest(Action<ProjectEntity> method)
        {
            _Repo.Delete(new ProjectLinkEntity());
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
            _Repo.Update(new ProjectLinkEntity());
            _DbconnMock.Verify(pe => pe.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null), Times.Once());
        }

        [Fact]
        public async Task UpdateEntityWithNullEntityTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _Repo.Update(null));
        }
        

        [Fact]
        public void LoadEntityWithGuidTest()
        {
            //loads data from database
            //returns a single instance 
        }

        [Fact]
        public void LoadAllEntityTest()
        {
            //load data from databsae 
            //returns list of entity
        }
    }
}
