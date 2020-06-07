using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class BookStorageDetailsDto
    {
        /// <summary>
        /// 图书入库单编号
        /// </summary>
        public int Did { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public string SNumber { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Counts { get; set; }
    }
}
