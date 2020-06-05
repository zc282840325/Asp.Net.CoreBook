using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 出版表
    /// </summary>
   public class PublishingHouse
    {
        /// <summary>
        /// 出版编号
        /// </summary>
        [Key]
        public int Pid { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        public string PName { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        public string PAddress { get; set; }
    }
}
