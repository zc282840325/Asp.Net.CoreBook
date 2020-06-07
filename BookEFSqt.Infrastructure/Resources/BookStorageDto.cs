using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class BookStorageDto
    {
        /// <summary>
        /// 入库编号
        /// </summary>
        public int SNumber { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>

        public DateTime SDate { get; set; }
        /// <summary>
        /// 经手职工编号
        /// </summary>
        public int Sid { get; set; }
        /// <summary>
        /// 是否入库
        /// </summary>
        public int IsWarehousing { get; set; }
    }
}
