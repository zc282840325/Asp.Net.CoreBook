using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class BookDamagedDetailsDto
    {
        /// <summary>
        /// 图书报损单编号
        /// </summary>
        public int DNumber { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public string Bid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Counts { get; set; }
        /// <summary>
        /// 报损原因
        /// </summary>
        public string Result { get; set; }
    }
}
