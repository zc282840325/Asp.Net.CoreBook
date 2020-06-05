using System;
using System.Collections.Generic;
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
        public int CertificateNumber { get; set; }
        /// <summary>
        /// 读者类型编号
        /// </summary>
        [ForeignKey("Rid")]
        public virtual ReaderType Rid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
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
