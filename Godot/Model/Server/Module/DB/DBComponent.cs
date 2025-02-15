using MongoDB.Driver;
using Npgsql;
using SqlSugar;
using Npgsql.Json.NET;
namespace ET.Server
{
    /// <summary>
    /// 用来缓存数据
    /// </summary>
    [ChildOf(typeof(DBManagerComponent))]
    public class DBComponent: Entity, IAwake<string, string, int>, IDestroy
    {
        public const int TaskCount = 32;

        public MongoClient mongoClient;
        public IMongoDatabase database;
        public SqlSugarClient sqlsugarClient;
    }
}