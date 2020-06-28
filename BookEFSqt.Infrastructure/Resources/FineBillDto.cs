using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class FineBillDto
    {
        /// <summary>
        /// 交费单号
        /// </summary>
        public int Fid { get; set; }
        /// <summary>
        /// 借书证编号
        /// </summary>
        public int CertificateNumber { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DateTimes { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Moneys { get; set; }
    }
}
