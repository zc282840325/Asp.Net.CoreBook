using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class BorrowDto
    {
        /// <summary>
        /// 借书证编号
        /// </summary>
        public int BNumber { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public string Bid { get; set; }
        /// <summary>
        /// 借书日期
        /// </summary>
        public DateTime BorrowingDate { get; set; }
        /// <summary>
        /// 还书日期
        /// </summary>
        public DateTime ReturnDate { get; set; }
        /// <summary>
        /// 罚款金额
        /// </summary>
        public double Moneys { get; set; }
        /// <summary>
        /// 是否续借
        /// </summary>
        public int IsRenew { get; set; }
    }
}
