﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Areas.Admin.Models
{
    [Serializable]
    public class AvatarImageUrlModel
    {
        public string Original { get; set; }
        public string Medium { get; set; }
        public string Thumb { get; set; }
    }
}