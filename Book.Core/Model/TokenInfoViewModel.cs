﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Model
{
   public class TokenInfoViewModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public double expires_in { get; set; }
        public string token_type { get; set; }
    }
}
