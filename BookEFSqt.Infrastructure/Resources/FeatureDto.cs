using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class FeatureDto
    {
        /// <summary>
        /// 可借阅册数
        /// </summary>
        public int BorrowNumbers { get; set; }
        /// <summary>
        /// 借期天数
        /// </summary>

        public int BorrowDays { get; set; }
        /// <summary>
        /// 可续借天数
        /// </summary>
        public int RenewDays { get; set; }
    }
}
