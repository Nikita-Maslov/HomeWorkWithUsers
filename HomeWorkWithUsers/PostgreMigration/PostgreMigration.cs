using DbUp;

namespace HomeWorkWithUsers.PostgreMigration
{
	public class PostgreMigration
	{
        public static void Migrate(string connectionString) {
            AppContext.SetSwitch("Npqsql.EnableLegacyTimestampBehavor", true);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .JournalToPostgresqlTable("protection", "__SchemaVersion")
                .WithScriptsFromFileSystem(Path.Combine("PostgreMigration/Scripts"))
                .WithVariable("BODY", "$BODY$")
                .WithExecutionTimeout(TimeSpan.FromSeconds(60 * 5))//5минут
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful) {
                throw new Exception("Migration error ", result.Error);
            }
        }
    }
}

