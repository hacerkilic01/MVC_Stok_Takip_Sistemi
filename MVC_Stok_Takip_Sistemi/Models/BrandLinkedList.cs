using MVC_Stok_Takip_Sistemi.Models.Entity;
using System.Collections.Generic;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class BrandLinkedList
    {
        private BrandNode head;
        private BrandNode tail;

        public void Add(Brand brand)
        {
            BrandNode newNode = new BrandNode(brand);
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

        public List<Brand> ToList()
        {
            List<Brand> brands = new List<Brand>();
            BrandNode current = head;
            while (current != null)
            {
                brands.Add(current.Data);
                current = current.Next;
            }
            return brands;
        }
        public void Update(Brand updatedBrand)
        {
            BrandNode current = head;
            while (current != null)
            {
                if (current.Data.ID == updatedBrand.ID)
                {
                    current.Data.Brand1 = updatedBrand.Brand1;
                    current.Data.CategoryID = updatedBrand.CategoryID;
                    break; 
                }
                current = current.Next;
            }

        }
        public void Remove(int id)
        {
            if (head == null) return;

            if (head.Data.ID == id)
            {
                head = head.Next;
                if (head == null) tail = null; 
                return;
            }

            BrandNode current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.ID == id)
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null) tail = current; 
                    break;
                }
                current = current.Next;
            }
        }
    }
}
