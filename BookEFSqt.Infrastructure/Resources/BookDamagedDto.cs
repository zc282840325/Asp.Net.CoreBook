using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class BookDamagedDto
    {
        /// <summary>
        /// 报损单编号
        /// </summary>
        public int DNumber { get; set; }
        /// <summary>
        /// 报损日期
        /// </summary>
        public DateTime DDateTime { get; set; }
        /// <summary>
        /// 经手人编号
        /// </summary>
        public int Sid { get; set; }
    }
}
