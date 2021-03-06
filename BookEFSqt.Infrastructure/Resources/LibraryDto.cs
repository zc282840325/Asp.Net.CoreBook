﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class LibraryDto
    {
        /// <summary>
        /// 书库号
        /// </summary>
        public int Lid { get; set; }
        /// <summary>
        /// 书库名
        /// </summary>
        public string LName { get; set; }
    }
}
