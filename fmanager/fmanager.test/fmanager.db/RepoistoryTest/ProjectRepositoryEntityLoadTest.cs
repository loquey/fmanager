using Dapper;
using FizzWare.NBuilder;
using Moq;
using System.Linq;
using Xunit;
using System;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{
    using db.Entitties;
    using db.Repositories;
    using System.Data;

    public class ProjectRepositoryEntityLoadTest
    {
        private Mock<IDbConnection> _dbconn;
        private IRepository<ProjectEntity> _repo; 
        public ProjectRepositoryEntityLoadTest()
        {
            var result = Builder<ProjectEntity>.CreateListOfSize(3).Build();
            _dbconn = new Mock<IDbConnection>();
            _dbconn.Setup(moq => moq.Query<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null)).Returns(result);
            _dbconn.Setup(moq => moq.QueryFirst<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).Returns(result.FirstOrDefault());
            _repo = new ProjectRepository(_dbconn.Object);
        }

        [Fact]
        public void LoadAllProductEntityTest()
        {
            _repo.LoadAll();
            _dbconn.Verify(moq => moq.Query<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null));
        }

        [Fact]
        public void LoadProductEntityTest()
        {
            _repo.Load(Guid.NewGuid());
            _dbconn.Verify(moq => moq.QueryFirst<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null));
        }
    }
}
