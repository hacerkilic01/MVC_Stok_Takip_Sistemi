using MVC_Stok_Takip_Sistemi.Models.Entity;
using System;
using System.Collections.Generic;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class UnitLinkedList
    {
        private UnitNode head;
        private UnitNode tail;

       
        public void Add(Unit unit)
        {
            UnitNode newNode = new UnitNode(unit);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        
        public List<Unit> ToList()
        {
            List<Unit> units = new List<Unit>(); 
            UnitNode current = head;  

            while (current != null)
            {
                units.Add(current.Data);
                current = current.Next;
            }

            return units;
        }

        public void Update(Unit unit)
        {
            UnitNode current = head;  

            while (current != null)
            {
                if (current.Data.ID == unit.ID)
                {
                    current.Data.Unit1 = unit.Unit1;  
                    current.Data.Description = unit.Description;

                    break;
                }
                current = current.Next;
            }
        }
    }
}
