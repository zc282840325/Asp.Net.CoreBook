using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 书库
    /// </summary>
   public class Library
    {
        /// <summary>
        /// 书库号
        /// </summary>
        [Key]
        public int Lid { get; set; }
        /// <summary>
        /// 书库名
        /// </summary>
        public string LName { get; set; }
    }
}
