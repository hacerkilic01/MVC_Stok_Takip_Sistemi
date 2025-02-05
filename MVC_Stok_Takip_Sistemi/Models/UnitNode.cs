using MVC_Stok_Takip_Sistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class UnitNode
    {
        public Unit Data { get; set; }
        public UnitNode Next { get; set; }

        public UnitNode(Unit data)
        {
            Data = data;
            Next = null;
        }
    }
}

