using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public enum AccountType
    {
        General = 1, //默认状态
        Black = 2 //账号处在黑名单状态
    }
  
    public class Account : Entity, IAwake
    {
        public string AccountName { get; set; }//账号
        public string Password { get; set; }//密码
        public int AccountType { get; set; }//状态
        public long CreateTime { get; set; }//创建日期
    }

}
