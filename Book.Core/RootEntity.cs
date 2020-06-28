using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core
{
    public class RootEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }


    }
}
