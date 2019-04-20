using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq; 

namespace fmanager.test.fmanagerdb.DriverTest
{
    using db.Driver;

    public class SQLiteFactoryTest
    {
        public SQLiteFactoryTest()
        {
            var sqliteFactoryMock = new Mock<SQLiteFactory>();

        }

        [Fact]
        public void InitializationTest()
        {
            
        }

    }
}
