namespace Sitetree.Core.DataAccess.Services.Interfaces
{
    /// <summary>
    ///     Interface for a service that handles database migrations.
    /// </summary>
    public interface IDatabaseMigrationService
    {
        /// <summary>
        ///     Perform un-executed database migrations.
        /// </summary>
        void PerformMigrations();
    }
}