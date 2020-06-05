using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class BookTypeDto
    {
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
