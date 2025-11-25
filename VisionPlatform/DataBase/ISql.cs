using System.Collections.Generic;

namespace VisionPlatform.Auxiliary
{
    public interface ISql
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        string IPaddress { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        string UserID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        string DataBase { get; set; }
        /// <summary>
        /// 数据表名称
        /// </summary>
        string DataTable { get; set; }
        /// <summary>
        /// 通用执行数据库命令方法
        /// </summary>
        /// <param name="cmdText">数据库命令</param>
        /// <returns></returns>
        object ExecuteScalar(string cmdText);
        string GetInqureCommand(string tbName, params object[] conditions);
        bool Connected();
        object IsDBNull(object es);
        object IsNull(object es);
        /// <summary>
        /// 检测数据库是否存在
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns>如果存在返回ture,否则 false</returns>
        bool IsExistsDatabase(string dbName);
        /// <summary>
        /// 检测指定数据库中是否存在指定的数据表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>如果存在返回ture,否则 false</returns>
        bool IsExistsDataTable(string dbName, string tbName);
        bool CreateDatabase(string dbName);
    }


    public interface ISqlServer : ISql
    {
        bool CreateRubberTable(string dbName);
       
        bool InsertRubberTable(RubberTable contentTable);
        bool InsertRubberTable(List<RubberTable> contentTables);
        List<RubberTable> GetRubberTables(params object[] conditions);
        List<ExportData> GetExportData(params object[] conditions);
        bool DeleteContentData(string guid);
        bool DeleteRubberData(params object[] conditions);
    }
}
