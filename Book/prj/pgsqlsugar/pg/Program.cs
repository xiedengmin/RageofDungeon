using SqlSugar;
using System;
using System.Collections.Generic;

public class Program
{
    // 定义装备类，映射到 equipment 表
    [SugarTable("equipment")]
    public class Equipment
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; } // JSONB 字段
    }

    public static void Main()
    {
        // 初始化 SqlSugarClient
        var db = new SqlSugarScope(new ConnectionConfig
        {
            ConnectionString = "Host=localhost;Port=5432;Database=godot;Username=your_username;Password=your_password",
            DbType = DbType.PostgreSQL,
            IsAutoCloseConnection = true
        });

        // 初始化表（若不存在则创建）
        db.DbMaintenance.CreateTable<Equipment>();

        // 添加装备示例
        db.Insertable(new Equipment
        {
            Name = "Excalibur",
            Attributes = "{\"attack_power\": 150, \"defense\": 50}"
        }).ExecuteCommand();

        // 查询攻击力大于 100 的装备
        var highAttackEquipment = db.Queryable<Equipment>()
            .Where(e => SqlFunc.json.JsonValue(e.Attributes, "$.attack_power") > 100)
            .ToList();

        Console.WriteLine("攻击力大于 100 的装备:");
        foreach (var eq in highAttackEquipment)
        {
            Console.WriteLine($"ID: {eq.Id}, Name: {eq.Name}, Attributes: {eq.Attributes}");
        }

        // 更新装备攻击力
        db.Updateable<Equipment>()
            .SetColumns(e => e.Attributes == "{\"attack_power\": 200, \"defense\": 60}")
            .Where(e => e.Name == "Excalibur")
            .ExecuteCommand();

        // 删除某件装备
        db.Deleteable<Equipment>()
            .Where(e => e.Name == "Excalibur")
            .ExecuteCommand();
    }
}