using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("出版编号")]
        public int Pid { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        [DisplayName("出版社名称")]
        public string PName { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        [DisplayName("出版社地址")]
        public string PAddress { get; set; }
    }
}
