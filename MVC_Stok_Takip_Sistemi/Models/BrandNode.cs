using MVC_Stok_Takip_Sistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class BrandNode
    {
        public Brand Data { get; set; }
        public BrandNode Next { get; set; }

        public BrandNode(Brand data)
        {
            Data = data;
            Next = null;
        }
    }
}