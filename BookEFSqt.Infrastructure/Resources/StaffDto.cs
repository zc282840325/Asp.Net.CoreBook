using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class StaffDto
    {
        public int Sid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string Education { get; set; }
    }
}
