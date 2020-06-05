using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 图书类型
    /// </summary>
   public class BookType
    {
        /// <summary>
        /// 图书类型编号
        /// </summary>
        [Key]
        public int Tid { get; set; }
        /// <summary>
        /// 图书类型名
        /// </summary>
        public string TName { get; set; }
        /// <summary>
        /// 书库号
        /// </summary>
        public int LibraryNumber { get; set; }
    }
}
