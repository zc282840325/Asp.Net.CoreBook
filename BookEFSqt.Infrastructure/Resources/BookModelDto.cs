using Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
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
        public int Tid { get; set; }
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
        public Decimal Price { get; set; }
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
        public DateTime StorageTime { get; set; }
        /// <summary>
        /// 借出次数
        /// </summary>
        public int OutNumbers { get; set; }

        /// <summary>
        /// 出版社名称
        /// </summary>
        public string PName { get; set; }
        /// <summary>
        /// 图书类型名称
        /// </summary>
        public string TName { get; set; }

    }
}
