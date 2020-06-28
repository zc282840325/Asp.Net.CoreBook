using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Model
{
   public class Feature: RootEntity
    {
        /// <summary>
        /// 可借阅册数
        /// </summary>
        [DisplayName("可借阅册数")]
        [Required]
        [Range(20, 60, ErrorMessage = "可借阅册数的范围是20-60")]
        public int BorrowNumbers { get; set; }
        /// <summary>
        /// 借期天数
        /// </summary>
        [Required]
        [DisplayName("借期天数")]
        [Range(90, 120, ErrorMessage = "借期天数的范围是90-120")]
        public int BorrowDays { get; set; }
        /// <summary>
        /// 可续借天数
        /// </summary>
        [Required]
        [DisplayName("可续借天数")]
        [Range(10, 60, ErrorMessage = "可续借天数的范围是10-60")]
        public int RenewDays { get; set; }
    }
}
