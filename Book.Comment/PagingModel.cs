using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Comment
{
   public class PagingModel
    {
        public int page { get; set; } = 1;
        public int limit { get; set; } = 10;
    }
}
