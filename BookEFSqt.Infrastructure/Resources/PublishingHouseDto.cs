using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class PublishingHouseDto
    {
        /// <summary>
        /// 出版编号
        /// </summary>
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
