using Dapper;
using FizzWare.NBuilder;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace fmanager.db.Driver
{
    using Entitties;
    using Repositories;
    using System.Collections.Generic;

    /// <summary>
    /// Factory for sqlite setup
    /// </summary>
    public class SQLiteFactory
    {
        public static bool CreateDbIfNotExist(string filePath)
        {
            var dbFilePath = filePath;
            if (!File.Exists(dbFilePath)) {
                SQLiteConnection.CreateFile(dbFilePath);
                return true;
            }
            return false;
        }

        public static void InitTables(IDbConnection conn)
        {
            //execute sql statements to create tables. 
            string sql = @"
                CREATE TABLE Projects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectName TEXT    NOT NULL,
                    ProjectType INTEGER NOT NULL,
                    FilePath    TEXT    NOT NULL
                );

                CREATE TABLE ProjectLinks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId   INTEGER NOT NULL,
                    Description TEXT,
                    Content     TEXT    NOT NULL,
                    CONSTRAINT ProjectFK FOREIGN KEY (
                        ProjectId
                    )
                    REFERENCES Projects (rowid) 
                );
                ";

            conn.Execute(sql);
        }

        static public void SeedTables(IRepository<ProjectEntity> projectRepo, IRepository<ProjectLinkEntity> projectLinkRepo)
        {
            var projects = Builder<ProjectEntity>.CreateListOfSize(4)
                            .All()
                                .With(c => c.ProjectName = Faker.Company.Name())
                                .With(c => c.ProjectType = Faker.Enum.Random<ProjectEntity.ProjectTypeEnum>())
                                .With(c => c.FilePath = Path.GetTempPath())
                            .Build();

            BuilderSetup.SetCreatePersistenceMethod<IList<ProjectLinkEntity>>((pl) => projectLinkRepo.Add(pl));
            var projectLinks = Builder<ProjectLinkEntity>.CreateListOfSize(15)
                                .All()
                                    .With(p => p.Content = Faker.Lorem.Sentence(3))
                                    .With(p => p.Description = Faker.Lorem.Sentence(4))
                                    .With(p => p.ProjectID = Pick<ProjectEntity>.RandomItemFrom(projects).Id)
                                 .Persist();
        }

    }
}
