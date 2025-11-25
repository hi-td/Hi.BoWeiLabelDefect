using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace VisionPlatform.Auxiliary
{
    public class SqlServerHelper : SqlServerBase
    {
        public static ISqlServer Create = new SqlServerHelper();

        private SqlServerHelper()
        {
            //如果配置了App.config文件,可以直接使用默认的
            if (ConfigurationManager.ConnectionStrings["DbConnectString"] != null)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectString"].ConnectionString;
            }

            //如果配置了App.config文件,可以直接使用默认的
            if (ConfigurationManager.ConnectionStrings["DbConnectDataBaseString"] != null)
            {
                DbConnectDataBaseString = ConfigurationManager.ConnectionStrings["DbConnectDataBaseString"].ConnectionString;
            }
        }

        private SqlServerHelper(string ipaddress, string database, string userId, string passwd)
        {
            IPaddress = ipaddress;
            DataBase = database;
            UserID = userId;
            Password = passwd;
            ConnectionString = $"Data Source ={ipaddress}; Initial Catalog = {database}; User ID = {userId}; Password ={passwd};";
        }
        public static ISqlServer Instance(string ipaddress, string database, string userId, string passwd)
        {
            return new SqlServerHelper(ipaddress, database, userId, passwd);
        }
        public void InitConnectionString()
        {
            ConnectionString = string.Format("Data Source ={0}; Initial Catalog = {1}; User ID = {2}; Password ={3}; ", IPaddress, DataBase, UserID, Password);
        }

        //protected string GetContentTableCommand(params object[] conditions)
        //{
        //    if (conditions == null || conditions.Length == 0)
        //    {
        //        return $"USE[{DataBase}] SELECT TOP 100 [ContentId],[DistanceLeft],[DistanceRight] FROM [Content] ORDER BY [Id] DESC";
        //    }
        //    var stringBuilder = new StringBuilder();
        //    //判断并生成Transaction-SQL语句
        //    stringBuilder.Append($"USE[{DataBase}] SELECT [ContentId],[DistanceLeft],[DistanceRight] FROM [Content] WHERE ");
        //    //定义用来存储起始编号 ，如果条件中没有编号则默认为 -1 
        //    var startId = -1;
        //    //定义用来存储结束编号 ，如果条件中没有编号则默认为 -1 
        //    var endId = -1;
        //    //定义用来存储Guid信息 ，如果条件中没有字符串则默认为 string.Empty
        //    var contentId = string.Empty;
        //    //从候选条件列表中筛选出符合对象
        //    foreach (var condition in conditions)
        //    {
        //        switch (condition)
        //        {
        //            case int id:
        //                if (id >= 0)
        //                {
        //                    if (startId == -1)
        //                    {
        //                        startId = id;
        //                    }
        //                    else if (startId > 0 && endId == -1)
        //                    {
        //                        if (startId > id)
        //                        {
        //                            endId = startId;
        //                            startId = id;
        //                        }
        //                        else
        //                        {
        //                            endId = id;
        //                        }
        //                    }
        //                }
        //                break;
        //            case string _code:
        //                if (string.IsNullOrEmpty(contentId) && !string.IsNullOrEmpty(_code))
        //                {
        //                    contentId = _code;
        //                }
        //                break;
        //        }
        //    }
        //    //根据起始编号来判断是否需要在Transaction-SQL语句中加入对编号的限定
        //    if (startId > 0)
        //    {
        //        if (endId > 0)
        //        {
        //            stringBuilder.Append($"[Id]>={startId} AND [Id]<={endId} ");
        //        }
        //        else
        //        {
        //            stringBuilder.Append($"[Id]={startId} ");
        //        }
        //    }
        //    //根据扫码信息来判断是否需要在Transaction-SQL语句中加入对扫码的限定
        //    if (!string.IsNullOrEmpty(contentId))
        //    {
        //        if (startId > 0)
        //        {
        //            stringBuilder.Append($" AND [ContentId] LIKE '%{contentId}%'");
        //        }
        //        else
        //        {
        //            stringBuilder.Append($"[ContentId] LIKE '%{contentId}%'");
        //        }
        //    }
        //    return stringBuilder.ToString();
        //}

        protected string GetRubberTableCommand(params object[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return $"USE[{DataBase}] SELECT TOP 100 [WorkOrderNumber], [ComponentCode], [ContentId],[ModelName], [DateTime],[Distance], [DistanceUp], [DistanceDown], [DistanceResult],[GapDistance],[GapDistanceUp],[GapDistanceDown],[GapResult],[Result] ,[ResultParticulars]FROM [Test_HL_RubberDome] ORDER BY[Id] DESC";
            }
            var stringBuilder = new StringBuilder();
            //判断并生成Transaction-SQL语句
            stringBuilder.Append($"USE[{DataBase}] SELECT [WorkOrderNumber], [ComponentCode], [ContentId],[ModelName], [DateTime],[Distance], [DistanceUp], [DistanceDown], [DistanceResult],[GapDistance],[GapDistanceUp],[GapDistanceDown],[GapResult],[Result] ,[ResultParticulars]FROM [Test_HL_RubberDome] WHERE ");
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
                                    if (startDateTime == dateTime)
                                    {
                                        endDateTime = dateTime.AddDays(1);
                                    }
                                    else
                                    {
                                        endDateTime = dateTime;
                                    }
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
            if (!string.IsNullOrEmpty(ContentId))
            {
                if (startId > 0 || startDateTime != default)
                {
                    stringBuilder.Append($" AND [ContentId] LIKE '%{ContentId}%'");
                }
                else
                {
                    stringBuilder.Append($"[ContentId] LIKE '%{ContentId}%'");
                }
            }
            return stringBuilder.ToString();
        }

        protected string GetExportCommand(params object[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return $"USE[{DataBase}] SELECT TOP 1000 [Id],[WorkOrderNumber], [ComponentCode], [ContentId],[ModelName], [DateTime],[Distance], [DistanceUp], [DistanceDown], [DistanceResult],[GapDistance],[GapDistanceUp],[GapDistanceDown],[GapResult],[Result] ,[ResultParticulars]FROM [Test_HL_RubberDome] ORDER BY [Id] DESC";
            }
            var stringBuilder = new StringBuilder();
            //判断并生成Transaction-SQL语句
            stringBuilder.Append($"USE[{DataBase}] SELECT [Id],[WorkOrderNumber], [ComponentCode], [ContentId],[ModelName], [DateTime],[Distance], [DistanceUp], [DistanceDown], [DistanceResult],[GapDistance],[GapDistanceUp],[GapDistanceDown],[GapResult],[Result],[ResultParticulars] FROM [Test_HL_RubberDome] WHERE ");
            //定义用来存储起始编号 ，如果条件中没有编号则默认为 -1 
            var startId = -1;
            //定义用来存储结束编号 ，如果条件中没有编号则默认为 -1 
            var endId = -1;
            //定义用来存储起始日期 ，如果条件中没有日期则默认为 default
            DateTime startDateTime = default;
            //定义用来存储结束日期 ，如果条件中没有日期则默认为 default
            DateTime endDateTime = default;
            //定义用来存储扫码信息 ，如果条件中没有字符串则默认为 string.Empty
            var code = string.Empty;
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
                        if (string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(_code))
                        {
                            code = _code;
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
                                    if (startDateTime == dateTime)
                                    {
                                        endDateTime = dateTime.AddDays(1);
                                    }
                                    else
                                    {
                                        endDateTime = dateTime;
                                    }
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
            if (!string.IsNullOrEmpty(code))
            {
                if (startId > 0 || startDateTime != default)
                {
                    stringBuilder.Append($" AND [Code] LIKE '%{code}%'");
                }
                else
                {
                    stringBuilder.Append($"[Code] LIKE '%{code}%'");
                }
            }
            return stringBuilder.ToString();
        }

        protected override string GetInqureCommand(string tbName = "ColorDome", params object[] conditions)
        {
            if (tbName.Equals("Test_HL_RubberDome"))
            {
                return GetRubberTableCommand(conditions);
            }
            return string.Empty;
        }

        protected override List<ExportData> GetExportData(params object[] conditions)
        {
            var result = new List<ExportData>();
            var cmd = GetExportCommand(conditions);
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
                        var cache = new ExportData()
                        {
                            Id = sqlReader.GetInt32(0),
                            WorkOrderNumber = sqlReader.GetString(1),
                            ComponentCode = sqlReader.GetString(2),
                            ContentId = sqlReader.GetString(3),
                            ModelName = sqlReader.GetString(4),
                            DateTime = sqlReader.GetDateTime(5),
                            Distance = sqlReader.GetDouble (6),
                            DistanceUp =sqlReader.GetDouble(7),
                            DistanceDown = sqlReader.GetDouble(8),
                            DistanceResult = sqlReader.GetString (9),
                            GapDistance = sqlReader.GetDouble(10),
                            GapDistanceUp = sqlReader.GetDouble(11),
                            GapDistanceDown = sqlReader.GetDouble(12),
                            GapResult = sqlReader.GetString (13),
                            Result = sqlReader.GetBoolean(14),
                            ResultParticulars = sqlReader.GetString(15),
                        };
                        result.Add(cache);
                    }
                }
            }
            return result;
        }
    }
}
