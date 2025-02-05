using MVC_Stok_Takip_Sistemi.Models.Entity;
using System.Collections.Generic;

namespace MVC_Stok_Takip_Sistemi.Models
{
    public class CategoryLinkedList
    {
        private CategoryNode head;
        private CategoryNode tail; 

        public void Add(Category category)
        {
            CategoryNode newNode = new CategoryNode(category);
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

        public List<Category> ToList()
        {
            List<Category> categories = new List<Category>();
            CategoryNode current = head;
            while (current != null)
            {
                categories.Add(current.Data);
                current = current.Next;
            }
            return categories;
        }

        public void Update(Category category)
        {
            CategoryNode current = head;
            while (current != null)
            {
                if (current.Data.ID == category.ID)
                {
                    // ID aynı kaldığından sadece ilgili alanları güncelle
                    current.Data.CategoryName = category.CategoryName;
                    current.Data.Description = category.Description;

                    //break;
                }
                current = current.Next;
            }
        }

        //public void Remove(int id)
        //{
        //    if (head == null) return;

        //    if (head.Data.ID == id)
        //    {
        //        head = head.Next;
        //        if (head == null) tail = null; // Liste tamamen boşaldıysa tail'i de sıfırla
        //        return;
        //    }

        //    CategoryNode current = head;
        //    while (current.Next != null)
        //    {
        //        if (current.Next.Data.ID == id)
        //        {
        //            current.Next = current.Next.Next;
        //            if (current.Next == null) tail = current; // Son eleman silindiyse tail'i güncelle
        //            break;
        //        }
        //        current = current.Next;
        //    }
        }
    }
