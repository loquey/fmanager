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
        private Mock<IDbConnection> _Dbconn;
        private IRepository<ProjectEntity> _Repo; 
        public ProjectRepositoryEntityLoadTest()
        {
            var result = Builder<ProjectEntity>.CreateListOfSize(3).Build();
            _Dbconn = new Mock<IDbConnection>();
            _Dbconn.Setup(moq => moq.Query<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null)).Returns(result);
            _Dbconn.Setup(moq => moq.QueryFirst<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).Returns(result.FirstOrDefault());
            _Repo = new ProjectRepository(_Dbconn.Object);
        }

        [Fact]
        public void LoadAllProductEntityTest()
        {
            _Repo.LoadAll();
            _Dbconn.Verify(moq => moq.Query<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null));
        }

        [Fact]
        public void LoadProductEntityTest()
        {
            _Repo.Load(Guid.NewGuid());
            _Dbconn.Verify(moq => moq.QueryFirst<ProjectEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null));
        }
    }
}
