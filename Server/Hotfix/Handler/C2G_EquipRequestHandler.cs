using System;


namespace ET
{


    // 定义消息处理器
    [MessageHandler]
    public class C2G_EquipRequestHandler : AMRpcHandler<C2G_EquipRequest, G2C_EquipResponse>
    {
        protected override async ETTask Run(Session session, C2G_EquipRequest request, G2C_EquipResponse response, Action reply)
        {
            try
            {
                // 获取玩家和装备信息
                int playerId = request.PlayerId;
                Equipment equipment = request.Equip;

                // 处理装备逻辑（例如保存到数据库或更新玩家属性）
                // 这里可以添加具体的业务逻辑

                // 设置响应消息
                response.RpcId = 90;
                response.Message = "装备成功1";
                response.Equip = equipment;

                // 发送响应
                reply();
            }
            catch (Exception e)
            {
                response.RpcId = 90;
                response.Message = $"装备失败: {e.Message}";
                reply();
            }
            await ETTask.CompletedTask;
        }
    
    }
}