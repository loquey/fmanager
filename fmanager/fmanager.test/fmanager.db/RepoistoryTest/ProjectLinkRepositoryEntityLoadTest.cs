using Dapper;
using Dapper.Contrib.Extensions;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Data;
using System.Linq;
using Xunit;

namespace fmanager.test.fmanagerdb.RepoistoryTest
{
    using db.Entitties;
    using db.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectLinkRepositoryEntityLoadTest
    {
        private Mock<IDbConnection> _Dbconn;
        private IRepository<ProjectLinkEntity> _Repo;

        public ProjectLinkRepositoryEntityLoadTest()
        {
            _Dbconn = new Mock<IDbConnection>();
            _Repo = new ProjectLinkRepository(_Dbconn.Object);

        }
        [Fact]
        public void LoadAllProjectLinkEntityTest()
        {
            var result = Builder<ProjectLinkEntity>.CreateListOfSize(3).Build();
            var getAllTask = new TaskCompletionSource<IEnumerable<ProjectLinkEntity>>();
            getAllTask.SetResult(result);

            _Dbconn.Setup(moq => moq.GetAllAsync<ProjectLinkEntity>(null, null)).Returns(getAllTask.Task);

            _Repo.LoadAll();
            _Dbconn.Verify(moq => moq.GetAllAsync<ProjectLinkEntity>(null, null));
        }

        [Fact]
        public void LoadProjectLinkEntityTest()
        {
            //Arrange
            var result = Builder<ProjectLinkEntity>.CreateNew().Build();33
            var getTask = new TaskCompletionSource<ProjectLinkEntity>();
            getTask.SetResult(result);
            _Dbconn.Setup(moq => moq.GetAsync<ProjectLinkEntity>(It.IsAny<int>(), null, null)).Returns(getTask.Task);

            _Repo.Load(1);

            _Dbconn.Verify(moq => moq.GetAsync<ProjectLinkEntity>(It.IsAny<int>(), null, null));


            
        }
    }
}
