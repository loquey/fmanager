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
        private Mock<IDbConnection> _Dbconn;
        private IRepository<ProjectLinkEntity> _Repo;

        public ProjectLinkRepositoryEntityLoadTest()
        {
            var result = Builder<ProjectLinkEntity>.CreateListOfSize(3).Build();
            _Dbconn = new Mock<IDbConnection>();
            _Dbconn.Setup(moq => moq.Query<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null)).Returns(result);
            _Dbconn.Setup(moq => moq.QueryFirst<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).Returns(result.FirstOrDefault());
            _Repo = new ProjectLinkRepository(_Dbconn.Object);

        }
        [Fact]
        public void LoadAllProductEntityTest()
        {
            _Repo.LoadAll();
            _Dbconn.Verify(moq => moq.Query<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, true, null, null));
        }

        [Fact]
        public void LoadProductEntityTest()
        {
            _Repo.Load(Guid.NewGuid());
            _Dbconn.Verify(moq => moq.QueryFirst<ProjectLinkEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null));
        }
    }
}
