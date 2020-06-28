using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 读者类
    /// </summary>
   public class Reader
    {
        /// <summary>
        /// 证书编号
        /// </summary>
        [Key]
        [DisplayName("证书编号")]
        public int CertificateNumber { get; set; }
        /// <summary>
        /// 读者类型编号
        /// </summary>
        [DisplayName("读者类型编号")]
        public int  Rid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }
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
