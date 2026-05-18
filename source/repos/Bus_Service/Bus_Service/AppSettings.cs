namespace Bus_Service
{
    /// <summary>
    /// Application configuration settings
    /// Connection string for Database1.mdf (Service-Based Database)
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// SQL Server connection string for Database1.mdf
        /// Uses LocalDB with integrated security (Windows Authentication)
        /// Looks for database in project root directory
        /// </summary>
        public static string SqlConnectionString 
        { 
            get 
            { 
                // Use direct LocalDB database connection by name
                // This is more reliable than file attachment since the database is already created
                return $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Database1;Integrated Security=True;MultipleActiveResultSets=True;";
            } 
        }
    }
}
