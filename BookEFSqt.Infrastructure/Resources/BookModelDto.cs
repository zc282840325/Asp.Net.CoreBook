using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class BookModelDto
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public string Bid { get; set; }
        /// <summary>
        /// 出版社编号
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 图书类型编号
        /// </summary>
        public string Tid { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        public string BName { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 库存总量
        /// </summary>
        public int TotalInventory { get; set; }
        /// <summary>
        /// 现存量
        /// </summary>
        public int ExistingStock { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public string StorageTime { get; set; }
        /// <summary>
        /// 借出次数
        /// </summary>
        public string OutNumbers { get; set; }
    }
}
