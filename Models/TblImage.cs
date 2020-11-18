using System;
using System.Collections.Generic;

#nullable disable

namespace BinaryImage.Models
{
    public partial class TblImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
    }
}
