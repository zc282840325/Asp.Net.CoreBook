using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 借阅表
    /// </summary>
    public class Borrow
    {
        /// <summary>
        /// 借书证编号
        /// </summary>
        [Key]
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
