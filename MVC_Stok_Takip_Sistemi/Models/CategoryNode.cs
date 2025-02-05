using MVC_Stok_Takip_Sistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class CategoryNode
    {
        public Category Data { get; set; }
        public CategoryNode Next { get; set; }

        public CategoryNode(Category data)
        {
            Data = data;
            Next = null;
        }
    }
}