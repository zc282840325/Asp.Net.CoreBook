using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
  public  class sysUserInfoDto
    {
        public int uID { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>

        public string uLoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string uLoginPWD { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string uRealName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int uStatus { get; set; }
        /// <summary>
        public string uRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime uCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime uUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///最后登录时间 
        /// </summary>
        public DateTime uLastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///错误次数 
        /// </summary>
        public int uErrorCount { get; set; }
        /// <summary>
        ///逻辑删除 
        /// </summary>
        public bool tdIsDelete { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证编号
        /// </summary>
        public string IDNumber { get; set; }
        /// <summary>
        /// 图书借阅次数
        /// </summary>
        public int Borrows { get; set; }
        /// <summary>
        /// 是否挂失
        /// </summary>
        public int IsReportLoss { get; set; }
        /// <summary>
        /// 已借册数
        /// </summary>
        public int Borroweds { get; set; }
        /// <summary>
        /// 未交罚款金额
        /// </summary>
        public double UnpaidFine { get; set; }
    }
}
