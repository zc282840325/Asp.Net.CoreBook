using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("图书类型编号")]
        public int Tid { get; set; }
        /// <summary>
        /// 图书类型名
        /// </summary>
        [DisplayName("图书类型名")]
        public string TName { get; set; }
        /// <summary>
        /// 书库号
        /// </summary>
        [DisplayName("书库号")]
        public int LibraryNumber { get; set; }
    }
}
