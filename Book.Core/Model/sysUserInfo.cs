using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Model
{
  
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table("sysUserInfo")]
    public class sysUserInfo
    {
        public sysUserInfo() { }

        public sysUserInfo(string loginName, string loginPWD)
        {
            uLoginName = loginName;
            uLoginPWD = loginPWD;
            uRealName = uLoginName;
            uStatus = 0;
            uCreateTime = DateTime.Now;
            uUpdateTime = DateTime.Now;
            uLastErrTime = DateTime.Now;
            uErrorCount = 0;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
       [Key]
       [DisplayName("用户ID")]
        public int uID { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        public string uLoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("登录密码")]
        public string uLoginPWD { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("真实姓名")]
        public string uRealName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
        public int uStatus { get; set; }
        /// <summary>
        [DisplayName("介绍")]
        public string uRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public System.DateTime uCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public System.DateTime uUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///最后登录时间 
        /// </summary>
        [DisplayName("最后登录时间")]
        public DateTime uLastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///错误次数 
        /// </summary>
        [DisplayName("错误次数")]
        public int uErrorCount { get; set; }


        /// <summary>
        ///逻辑删除 
        /// </summary>
        [DisplayName("逻辑删除")]
        public bool tdIsDelete { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [DisplayName("出生日期")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证编号
        /// </summary>
        [DisplayName("身份证编号")]
        public string IDNumber { get; set; }
        /// <summary>
        /// 图书借阅次数
        /// </summary>
        [DisplayName("图书借阅次数")]
        public int Borrows { get; set; }
        /// <summary>
        /// 是否挂失
        /// </summary>
        [DisplayName("是否挂失")]
        public int IsReportLoss { get; set; }
        /// <summary>
        /// 已借册数
        /// </summary>
        [DisplayName("已借册数")]
        public int Borroweds { get; set; }
        /// <summary>
        /// 未交罚款金额
        /// </summary>
        [DisplayName("未交罚款金额")]
        public double UnpaidFine { get; set; }

    }
}
