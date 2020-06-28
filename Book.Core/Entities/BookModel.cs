using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 图书类
    /// </summary>
   public class BookModel
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        [Key]
        [DisplayName("图书编号")]
        public string Bid { get; set; }
        /// <summary>
        /// 出版社编号
        /// </summary>
        [DisplayName("出版社编号")]
        public int Pid { get; set; }
        /// <summary>
        /// 图书类型编号
        /// </summary>
        [DisplayName("图书类型编号")]

        public int Tid { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        [DisplayName("书名")]
        public string BName { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName("作者")]
        public string Author { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [DisplayName("价格")]
        public Decimal Price { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        [DisplayName("页码")]
        public int PageNumber { get; set; }
        /// <summary>
        /// 库存总量
        /// </summary>
        [DisplayName("库存总量")]
        public int TotalInventory { get; set; }
        /// <summary>
        /// 现存量
        /// </summary>
        [DisplayName("现存量")]
        public int ExistingStock { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        [DisplayName("入库时间")]
        public DateTime StorageTime { get; set; }
        /// <summary>
        /// 借出次数
        /// </summary>
        [DisplayName("借出次数")]
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
