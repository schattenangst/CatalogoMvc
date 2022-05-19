namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;

    public class EnvironmentSettings
    {
        /// <summary>
        /// Regresa la cadena de conexión al contexto.
        /// </summary>
        /// <value>
        /// La cadena de conexión al contexto.
        /// </value>
        public static string ConnectionString
        {
            get
            {
                string connectionString = new SqlConnectionStringBuilder
                {
                    ApplicationName = "Escuela",
                    InitialCatalog = "escuela",
                    DataSource = @"EX2260-L30773\WORKSHOP",
                    IntegratedSecurity = true,
                    //UserID = info.UserId,
                    //Password = info.Password,
                    MultipleActiveResultSets = true,
                }.ConnectionString;

                return connectionString;
            }
        }
    }
}