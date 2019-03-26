using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Moq;
using Xunit;
using FizzWare.NBuilder; 

namespace fmanager.test.fmanagerdb.RepoistoryTest
{
    using db.Entitties;
    using db.Repositories; 

    public class ProjectLinkRepositoryEntityLoadTest
    {
        private Mock<IDbConnection> _dbconn;
        private IRepository<ProjectLinkEntity> _repo;

        public ProjectLinkRepositoryEntityLoadTest()
        {
            var result = Builder<ProjectLinkEntity>.CreateListOfSize(3).Build();
            _dbconn = new Mock<IDbConnection>();
            _dbconn.Setup(moq => moq.Query<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null)).Returns(result);
            _dbconn.Setup(moq => moq.QueryFirst<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).Returns(result.FirstOrDefault());
            _repo = new ProjectLinkRepository(_dbconn.Object);

        }
        [Fact]
        public void LoadAllProductEntityTest()
        {
            _repo.LoadAll();
            _dbconn.Verify(moq => moq.Query<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null));
        }

        [Fact]
        public void LoadProductEntityTest()
        {
            _repo.Load(Guid.NewGuid());
            _dbconn.Verify(moq => moq.QueryFirst<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null));
        }
    }
}
