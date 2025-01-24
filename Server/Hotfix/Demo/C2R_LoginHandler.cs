using System;
using System.Net;


namespace ET
{
	[MessageHandler]
	public class C2R_LoginHandler : AMRpcHandler<C2R_Login, R2C_Login>
	{
		protected override async ETTask Run(Session session, C2R_Login request, R2C_Login response, Action reply)
		{
			// 随机分配一个Gate
			StartSceneConfig config = RealmGateAddressHelper.GetGate(session.DomainZone());
			Log.Debug($"gate address: {MongoHelper.ToJson(config)}");

			//查询数据库 使用DBManagerComponent
			//DBManagerComponent挂载在Game.Scene全局下
			//这里的GetZoneDB里面的2代表的是2服 这里就写死了  代表ET2数据库的那个id 配表里可以找到
            var users = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                    .Query<Account>(d => d.AccountName.Equals(request.Account.Trim()));
            Account account = null;
            //如果获取到的数据为空则证明没有该用户
            if (users == null || users.Count == 0)
            {
                //没有用户的话就注册。
                account = session.AddChild<Account>(false);
                //赋值
                account.AccountName = request.Account.Trim();
                account.Password = request.Password.Trim();
                account.CreateTime = TimeHelper.ServerNow();
                account.AccountType = (int)AccountType.General;

                //存到数据库
                await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
            }
            else
            {
                //如果存在账号走这里
                account = users[0];
                session.AddChild(account);

                //判断账号处于冻结还是正常
                if (account.AccountType == (int)AccountType.Black)
                {
                    response.Error = ErrorCode.ERR_AccountIsBlack;
                    reply();
                    session?.Dispose();
                    account?.Dispose();
                    return;
                }
                //判断账号密码是否一致
                if (!account.Password.Equals(request.Password))
                {
                    response.Error = ErrorCode.ERR_PasswordError;
                    reply();
                    session?.Dispose();
                    account.Dispose();
                    return;
                }
            }
            //如果可以走到这里就代表成功了
            account.Dispose();

            // 向gate请求一个key,客户端可以拿着这个key连接gate
            G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey) await ActorMessageSenderComponent.Instance.Call(
				config.InstanceId, new R2G_GetLoginKey() {Account = request.Account});

			response.Address = config.OuterIPPort.ToString();
			response.Key = g2RGetLoginKey.Key;
			response.GateId = g2RGetLoginKey.GateId;
			reply();
		}
	}
}