using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace AMS.DAL
{
    public sealed class DataAccess : IDataAccess
    {
        /// <summary>
        ///     Provate Constructor
        /// </summary>
        /// W
        private DataAccess()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="isTransaction"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public DbCommand GetCommand(bool isTransaction, IsolationLevel isolationLevel)
        {
            var connectionString = string.Empty;
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAMS"].ConnectionString;
                //Connection string name change by Md. Hasan sharif
            return GetMyCommand(isTransaction, isolationLevel, connectionString);
        }

        /// <summary>
        /// </summary>
        /// <param name="isTransaction"></param>
        /// <param name="isolationLevel"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DbCommand GetCommand(bool isTransaction, IsolationLevel isolationLevel, string textOrSpName,
            CommandType commandType)
        {
            var connectionString = string.Empty;
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAMS"].ConnectionString;
                //Connection string name change by Md. Hasan sharif
            var objDbCommand = GetMyCommand(isTransaction, isolationLevel, connectionString);
            objDbCommand.CommandType = commandType;
            objDbCommand.CommandText = textOrSpName;
            return objDbCommand;
        }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="isTransaction"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public DbCommand GetCommand(string connectionString, bool isTransaction, IsolationLevel isolationLevel)
        {
            return GetMyCommand(isTransaction, isolationLevel, connectionString);
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand objDbCommand, string textOrSpName, CommandType commandType)
        {
            try
            {
                objDbCommand.CommandType = commandType;
                objDbCommand.CommandText = textOrSpName;
                return objDbCommand.ExecuteNonQuery();
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteNonQuery " + textOrSpName, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand objDbCommand)
        {
            try
            {
                return objDbCommand.ExecuteNonQuery();
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteNonQuery " + objDbCommand.CommandText, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(DbCommand objDbCommand, string textOrSpName, CommandType commandType)
        {
            try
            {
                objDbCommand.CommandType = commandType;
                objDbCommand.CommandText = textOrSpName;
                return objDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteReader " + textOrSpName, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(DbCommand objDbCommand)
        {
            try
            {
                return objDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteReader " + objDbCommand.CommandText, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable ExecuteTable(DbCommand objDbCommand, string textOrSpName, CommandType commandType)
        {
            try
            {
                objDbCommand.CommandType = commandType;
                objDbCommand.CommandText = textOrSpName;
                var objDataTable = new DataTable();
                var objDbDataReader = objDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                objDataTable.Load(objDbDataReader);
                return objDataTable;
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteTable " + textOrSpName, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <returns></returns>
        public DataTable ExecuteTable(DbCommand objDbCommand)
        {
            try
            {
                var objDataTable = new DataTable();
                var objDbDataReader = objDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                objDataTable.Load(objDbDataReader);
                return objDataTable;
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteTable " + objDbCommand.CommandText, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand objDbCommand, string textOrSpName, CommandType commandType)
        {
            try
            {
                DbProviderFactory objDbProviderFactory;
                // retrieve provider invariant name from web.config
                var providerInvariantName = ConfigurationManager.AppSettings["ProviderType"];
                if (string.IsNullOrEmpty(providerInvariantName))
                {
                    providerInvariantName = "System.Data.SqlClient";
                }
                // create the specific invariant provider
                objDbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
                var objDbDataAdapter = objDbProviderFactory.CreateDataAdapter();
                objDbCommand.CommandType = commandType;
                objDbCommand.CommandText = textOrSpName;
                var objDataSet = new DataSet();
                objDbDataAdapter.SelectCommand = objDbCommand;
                objDbDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteTable " + textOrSpName, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <param name="textOrSpName"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand objDbCommand, string textOrSpName, CommandType commandType)
        {
            try
            {
                objDbCommand.CommandType = commandType;
                objDbCommand.CommandText = textOrSpName;
                return objDbCommand.ExecuteScalar();
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteScalar " + textOrSpName, sqlEx);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand objDbCommand)
        {
            try
            {
                return objDbCommand.ExecuteScalar();
            }
            catch (DbException sqlEx)
            {
                throw new Exception("ExecuteScalar " + objDbCommand.CommandText, sqlEx);
            }
        }


        /// <summary>
        /// </summary>
        public void Dispose()
        {
        }


        /// <summary>
        /// </summary>
        /// <param name="objDbCommand"></param>
        public void Dispose(DbCommand objDbCommand)
        {
            if (objDbCommand.Connection != null)
            {
                objDbCommand.Connection.Dispose();
                objDbCommand.Connection = null;
            }
            if (objDbCommand.Transaction != null)
            {
                objDbCommand.Transaction.Dispose();
                objDbCommand.Transaction = null;
            }
            if (objDbCommand != null)
            {
                objDbCommand.Dispose();
                objDbCommand = null;
            }
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static IDataAccess NewDataAccess()
        {
            return new DataAccess();
        }


        /// <summary>
        /// </summary>
        /// <param name="bIsTransaction"></param>
        /// <param name="isolationLevel"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private DbCommand GetMyCommand(bool bIsTransaction, IsolationLevel isolationLevel, string connectionString)
        {
            DbProviderFactory objDbProviderFactory;
            // retrieve provider invariant name from web.config
            var providerInvariantName = ConfigurationManager.AppSettings["ProviderType"];
            if (string.IsNullOrEmpty(providerInvariantName))
            {
                providerInvariantName = "System.Data.SqlClient";
            }
            // create the specific invariant provider
            objDbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
            var objDbConnection = objDbProviderFactory.CreateConnection();
            objDbConnection.ConnectionString = connectionString;
            var objDbCommand = objDbProviderFactory.CreateCommand();
            objDbCommand.Connection = objDbConnection;
            objDbConnection.Open();
            if (bIsTransaction)
            {
                var objDbTransaction = objDbConnection.BeginTransaction(isolationLevel);
                objDbCommand.Transaction = objDbTransaction;
                return objDbCommand;
            }
            return objDbCommand;
        }
    }
}