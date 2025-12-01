using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisionPlatform.Auxiliary
{
    public abstract class SqlServerBase : ISqlServer
    {
        /// <summary>
        /// 服务器名称 默认 (local)
        /// </summary>
        protected virtual string IPaddress { get; set; } = "(local)";
        /// <summary>
        /// <para>测试账号: sa</para>
        /// <para>生产账号：TODO:待定</para> 
        /// <para>默认设置为测试账号   </para>
        /// </summary>
        protected virtual string UserID { get; set; } = "sa";
        /// <summary>
        /// <para>测试密码：qiu0427huai</para>
        /// <para>生产密码：TODO:待定</para> 
        /// <para>默认设置为测试密码   </para>
        /// </summary>
        protected virtual string Password { get; set; } = "hlzn@2025";
        /// <summary>
        /// 数据库名称
        /// <para>默认测试数据库为:VisionPlatform</para>
        /// <para>生产数据库:TODO:待定</para>
        /// </summary>
        protected virtual string DataBase { get; set; } = "VisionPlatform";
        /// <summary>
        /// 表名称
        /// <para>默认测试数据表为:ContentTable</para>
        /// <para>生产数据表:TODO:待定</para>
        /// </summary>
        protected virtual string DataTable { get; set; } = "PCBBoardInspectionDataDome";

        string ISql.IPaddress { get => IPaddress; set => IPaddress = value; }
        string ISql.UserID { get => UserID; set => UserID = value; }
        string ISql.Password { get => Password; set => Password = value; }
        string ISql.DataBase { get => DataBase; set => DataBase = value; }
        string ISql.DataTable { get => DataTable; set => DataTable = value; }
        /// <summary>
        /// 用于不带数据库名称的连接。
        /// </summary>
        protected virtual string ConnectionString { get; set; }
        /// <summary>
        /// 带数据库名称的连接字符串
        /// </summary>
        protected virtual string DbConnectDataBaseString { get; set; }
        /// <summary>
        /// 是否连接成功
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual bool Connected()
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return false;
            }
        }
        /// <summary>
        /// 执行查询，并返回由查询返回的结果集中的第一行的第一列。 其他列或行将被忽略。
        /// </summary>
        /// <param name="cmdText">执行Sql语句</param>
        /// <returns>为结果集中的第一行的第一列，或者，如果结果集为空，则为 null 引用（在 Visual Basic 中为 Nothing）。 返回的最大字符数为 2033 个字符。</returns>
        protected virtual object ExecuteScalar(string cmdText)
        {
            object results = null;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = sqlCmd.ExecuteScalar();
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }
        protected virtual SqlDataReader ExecuteReader(string cmdText)
        {
            SqlDataReader results = null;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }
        protected virtual int ExecuteNonQuery(string cmdText)
        {
            int results = -1;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }

        protected virtual async Task<int> ExecuteNonQueryAsync(string cmdText)
        {
            int results = -1;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = await sqlCmd.ExecuteNonQueryAsync();
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }
        protected virtual async Task<SqlDataReader> ExecuteReaderAsync(string cmdText)
        {
            SqlDataReader results = null;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = await sqlCmd.ExecuteReaderAsync();
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }
        protected virtual async Task<object> ExecuteScalarAsync(string cmdText)
        {
            object results = null;
            try
            {
                using var sqlConn = new SqlConnection(ConnectionString);
                //执行打开，成功则进行下一步，否则直接抛出异常
                sqlConn.Open();
                using var sqlCmd = new SqlCommand(cmdText, sqlConn);
                results = await sqlCmd.ExecuteScalarAsync();
            }
            catch (SqlException se)
            {
                se.Log(MethodBase.GetCurrentMethod());
            }
            return results;
        }

        protected abstract string GetInqureCommand(string tbName, params object[] conditions);
        /// <summary>
        /// 检测数据库是否存在
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns>如果存在返回ture,否则 false</returns>
        protected virtual bool IsExistsDatabase(string dbName)
        {
            var result = ExecuteScalar(string.Format("SELECT COUNT(*) FROM sys.databases WHERE name = '{0}'", dbName));
            return result != null && Convert.ToInt32(result) == 1;
        }
        /// <summary>
        /// 检测指定数据库中是否存在指定的数据表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>如果存在返回ture,否则 false</returns>
        protected virtual bool IsExistsDataTable(string dbName, string tbName)
        {
            var result = ExecuteScalar(string.Format("SELECT COUNT(*) FROM [{0}].sys.tables WHERE name = '{1}';", dbName, tbName));
            return result != null && Convert.ToInt32(result) == 1;
        }
        /// <summary>
        /// 创建指定数据库
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns>如果创建成功返回ture,否则 false</returns>
        protected virtual bool CreateDatabase(string dbName)
        {
            var result = ExecuteNonQuery(string.Format("CREATE DATABASE [{0}];", dbName));
            return result != -1;
        }
        protected virtual object IsDBNull(object es)
        {
            return es is DBNull ? "0" : es;
        }

        protected virtual object IsNull(object es)
        {
            return es is null ? DBNull.Value : es;
        }

        bool ISql.Connected()
        {
            return Connected();
        }

        object ISql.ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText);
        }

        string ISql.GetInqureCommand(string tbName, params object[] conditions)
        {
            return GetInqureCommand(tbName, conditions);
        }

        object ISql.IsDBNull(object es)
        {
            return IsDBNull(es);
        }

        object ISql.IsNull(object es)
        {
            return IsNull(es);
        }

        bool ISql.IsExistsDatabase(string dbName)
        {
            return IsExistsDatabase(dbName);
        }

        bool ISql.IsExistsDataTable(string dbName, string tbName)
        {
            return IsExistsDataTable(dbName, tbName);
        }

        bool ISql.CreateDatabase(string dbName)
        {
            return CreateDatabase(dbName);
        }


        protected virtual bool CreateRubberTable(string tbName)
        {
            var result = ExecuteNonQuery(string.Format("USE VisionPlatform;" +
                "CREATE TABLE [{0}]( " +
                " [Id] INT PRIMARY KEY IDENTITY(1,1)," +
                 " [WorkOrderNumber] NVARCHAR(500) NOT NULL," +
                 " [ComponentCode] NVARCHAR(500) NOT NULL," +
                " [ContentId] NVARCHAR(500) NOT NULL," +
                 " [ModelName] NVARCHAR(500) NOT NULL," +
                " [DateTime][datetime] NOT NULL," +
                 " [Distance][float]  NOT NULL," +
                 " [DistanceUp][float]  NOT NULL," +
                 " [DistanceDown][float]  NOT NULL," +
                  " [DistanceResult] NVARCHAR(500) NOT NULL," +
                   " [GapDistance][float]  NOT NULL," +
                 " [GapDistanceUp][float]  NOT NULL," +
                 " [GapDistanceDown][float]  NOT NULL," +
                  " [GapResult] NVARCHAR(500) NOT NULL," +
                " [Result] BIT NOT NULL," +
                " [ResultParticulars] NVARCHAR(500) NOT NULL);", tbName));
            return result != -1;
        }
        protected virtual bool InsertRubberTable(List<RubberTable> contentTables)
        {
            if (contentTables == null || contentTables.Count <= 0) return false;
            var dt = new DataTable();
            dt.Columns.Add("WorkOrderNumber", typeof(string));
            dt.Columns.Add("ComponentCode", typeof(string));
            dt.Columns.Add("ContentId", typeof(string));
            dt.Columns.Add("ModelName", typeof(string));
            dt.Columns.Add("DateTime", typeof(DateTime));
            dt.Columns.Add("Distance", typeof(float));
            dt.Columns.Add("DistanceUp", typeof(float));
            dt.Columns.Add("DistanceDown", typeof(float));
            dt.Columns.Add("DistanceResult", typeof(string));
            dt.Columns.Add("GapDistance", typeof(float));
            dt.Columns.Add("GapDistanceUp", typeof(float));
            dt.Columns.Add("GapDistanceDown", typeof(float));
            dt.Columns.Add("GapResult", typeof(string));
            dt.Columns.Add("Result", typeof(bool));
            dt.Columns.Add("ResultParticulars", typeof(string));
            foreach (var content in contentTables)
            {
                dt.Rows.Add(content.WorkOrderNumber, content.ComponentCode, content.ContentId, content.ModelName, content.DateTime, content.Distance, content.DistanceUp, content.DistanceDown, content.DistanceResult, content.GapDistance, content.GapDistanceUp, content.GapDistanceDown, content.GapResult, content.Result, content.ResultParticulars);
            }
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var bulkCopy = new SqlBulkCopy(connection);
                bulkCopy.DestinationTableName = "Test_HL_RubberDome";
                bulkCopy.WriteToServer(dt);
                return true;
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return false;
            }
        }

        protected virtual bool InsertRubberTable(RubberTable contentTable)
        {
            if (contentTable == null) return false;

            var result = ExecuteNonQuery(string.Format("USE [{0}]" +
                "INSERT INTO [{1}](" +
                " [WorkOrderNumber]," +
                " [ComponentCode]," +
                " [ContentId]," +
                " [ModelName]," +
                " [DateTime]," +
                 " [Distance]," +
                 " [DistanceUp]," +
                 " [DistanceDown]," +
                 " [DistanceResult]," +
                 " [GapDistance]," +
                 " [GapDistanceUp]," +
                 " [GapDistanceDown]," +
                 " [GapResult]," +
                " [Result]," +
                "[ResultParticulars])VALUES(" +
                " '{2}'," +
                " '{3}'," +
                " '{4}'," +
                " '{5}'," +
                " '{6}'," +
                " '{7}'," +
                " '{8}'," +
                " '{9}'," +
                " '{10}'," +
                " '{11}'," +
                " '{12}'," +
                " '{13}'," +
                " '{14}'," +
                " '{15}'," +
                " '{16}'" +
                ");", DataBase, DataTable, contentTable.WorkOrderNumber , contentTable.ComponentCode , contentTable.ContentId, contentTable.ModelName , contentTable.DateTime, contentTable.Distance, contentTable.DistanceUp, contentTable.DistanceDown, contentTable.DistanceResult, contentTable.GapDistance, contentTable.GapDistanceUp, contentTable.GapDistanceDown, contentTable.GapResult, contentTable.Result, contentTable.ResultParticulars));
            return result != -1;
        }

        protected virtual bool DeleteRubberData(params object[] conditions)
        {
            if (conditions == null || conditions.Length == 0) return false;
            var stringBuilder = new StringBuilder();
            //判断并生成Transaction-SQL语句
            stringBuilder.Append($"USE[VisionPlatform] DELETE FROM [ColorDome] WHERE ");
            //定义用来存储起始编号 ，如果条件中没有编号则默认为 -1 
            var startId = -1;
            //定义用来存储结束编号 ，如果条件中没有编号则默认为 -1 
            var endId = -1;
            //定义用来存储起始日期 ，如果条件中没有日期则默认为 default
            DateTime startDateTime = default;
            //定义用来存储结束日期 ，如果条件中没有日期则默认为 default
            DateTime endDateTime = default;
            //定义用来存储扫码信息 ，如果条件中没有字符串则默认为 string.Empty
            var ContentId = string.Empty;
            //从候选条件列表中筛选出符合对象
            foreach (var condition in conditions)
            {
                switch (condition)
                {
                    case int id:
                        if (id >= 0)
                        {
                            if (startId == -1)
                            {
                                startId = id;
                            }
                            else if (startId > 0 && endId == -1)
                            {
                                if (startId > id)
                                {
                                    endId = startId;
                                    startId = id;
                                }
                                else
                                {
                                    endId = id;
                                }
                            }
                        }
                        break;
                    case string _code:
                        if (string.IsNullOrEmpty(ContentId) && !string.IsNullOrEmpty(_code))
                        {
                            ContentId = _code;
                        }
                        break;
                    case DateTime dateTime:
                        if (dateTime != default)
                        {
                            if (startDateTime == default)
                            {
                                startDateTime = dateTime;
                            }
                            else if (endDateTime == default)
                            {
                                if (startDateTime > dateTime)
                                {
                                    endDateTime = startDateTime;
                                    startDateTime = dateTime;
                                }
                                else
                                {
                                    endDateTime = dateTime;
                                }
                            }
                        }
                        break;
                }
            }
            //根据起始编号来判断是否需要在Transaction-SQL语句中加入对编号的限定
            if (startId > 0)
            {
                if (endId > 0)
                {
                    stringBuilder.Append($"[Id]>={startId} AND [Id]<={endId} ");
                }
                else
                {
                    stringBuilder.Append($"[Id]={startId} ");
                }
            }
            //根据起始日期来判断是否需要在Transaction-SQL语句中加入对日期的限定
            if (startDateTime != default)
            {
                if (endDateTime != default)
                {
                    if (startId > 0)
                    {
                        stringBuilder.Append($" AND [DateTime]>='{startDateTime}' AND [DateTime]<='{endDateTime}' ");

                    }
                    else
                    {
                        stringBuilder.Append($"[DateTime]>='{startDateTime}' AND [DateTime]<='{endDateTime}' ");
                    }
                }
                else
                {
                    if (startId > 0)
                    {
                        stringBuilder.Append($" AND CAST([DateTime] AS DATE) ='{startDateTime.Date}' ");

                    }
                    else
                    {
                        stringBuilder.Append($"CAST([DateTime] AS DATE) ='{startDateTime.Date}'");
                    }
                }
            }
            //根据扫码信息来判断是否需要在Transaction-SQL语句中加入对扫码的限定
            //if (!string.IsNullOrEmpty(code))
            //{
            //    if (startId > 0 || startDateTime != default)
            //    {
            //        stringBuilder.Append($" AND [Code] LIKE '%{code}%'");
            //    }
            //    else
            //    {
            //        stringBuilder.Append($"[Code] LIKE '%{code}%'");
            //    }
            //}
            //执行Transaction-SQL语句
            var result = ExecuteNonQuery(stringBuilder.ToString());
            //返回是否成功执行
            return result != -1;
        }

        protected virtual bool DeleteContentData(string guid)
        {
            var cmdText = $"USE [VisionPlatform] DELETE FROM Content WHERE ContentId='{guid}';";
            //执行Transaction-SQL语句
            var result = ExecuteNonQuery(cmdText);
            //返回是否成功执行
            return result != -1;
        }

        protected virtual List<RubberTable> GetRubberTables(params object[] conditions)
        {
            var result = new List<RubberTable>();
            try
            {

                var cmd = GetInqureCommand("Test_HL_RubberDome", conditions);
                if (!string.IsNullOrEmpty(cmd))
                {
                    using var sqlConn = new SqlConnection(ConnectionString);
                    //执行打开，成功则进行下一步，否则直接抛出异常
                    sqlConn.Open();
                    using var sqlCmd = new SqlCommand(cmd, sqlConn);
                    using SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            //var cache = new RubberTable()
                            //{
                            //    ContentId = sqlReader.GetString(0),
                            //    DateTime = sqlReader.GetDateTime(1),
                            //    Distance = sqlReader.GetFloat(2),
                            //    DistanceUp = sqlReader.GetFloat(3),
                            //    DistanceDown = sqlReader.GetFloat(4),
                            //    DistanceResult = sqlReader.GetString(5),
                            //    GapDistance = sqlReader.GetFloat(6),
                            //    GapDistanceUp = sqlReader.GetFloat(7),
                            //    GapDistanceDown = sqlReader.GetFloat(8),
                            //    GapResult = sqlReader.GetString(9),
                            //    Result = sqlReader.GetBoolean(10),
                            //    ResultParticulars = sqlReader.GetString(11),
                            //};
                            var cache = new RubberTable();
                            cache .WorkOrderNumber = sqlReader.GetString(0);
                            cache.ComponentCode = sqlReader.GetString(1);
                            cache.ContentId = sqlReader.GetString(2);
                            cache.ModelName = sqlReader.GetString(3);
                            cache.DateTime = sqlReader.GetDateTime(4);
                            cache.Distance = sqlReader.GetDouble(5);
                            cache.DistanceUp = sqlReader.GetDouble(6);
                            cache.DistanceDown = sqlReader.GetDouble(7);
                            cache.DistanceResult = sqlReader.GetString(8);
                            cache.GapDistance = sqlReader.GetDouble(9);
                            cache.GapDistanceUp = sqlReader.GetDouble(10);
                            cache.GapDistanceDown = sqlReader.GetDouble(11);
                            cache.GapResult = sqlReader.GetString(12);
                            cache.Result = sqlReader.GetBoolean(13);
                            cache.ResultParticulars = sqlReader.GetString(14);
                            result.Add(cache);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                ex.ToString().Log();
                return result;
            }
        }

        protected abstract List<ExportData> GetExportData(params object[] conditions);

        bool ISqlServer.InsertRubberTable(RubberTable contentTable)
        {
            return InsertRubberTable(contentTable);
        }

        bool ISqlServer.InsertRubberTable(List<RubberTable> contentTables)
        {
            return InsertRubberTable(contentTables);
        }

        List<RubberTable> ISqlServer.GetRubberTables(params object[] conditions)
        {
            return GetRubberTables(conditions);
        }

        //bool ISqlServer.CreateContentTable(string dbName)
        //{
        //    return CreateContentTable(dbName);
        //}

        bool ISqlServer.CreateRubberTable(string dbName)
        {
            return CreateRubberTable(dbName);
        }

        List<ExportData> ISqlServer.GetExportData(params object[] conditions)
        {
            return GetExportData(conditions);
        }

        bool ISqlServer.DeleteContentData(string guid)
        {
            return DeleteContentData(guid);
        }

        bool ISqlServer.DeleteRubberData(params object[] conditions)
        {
            return DeleteRubberData(conditions);
        }
    }
}
