using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enitities.Concrete
{
   public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; } // kriptoloyacaz yani çözülemez hale getirecez.

        // 1234 1234 1234 6547 6523 bunlar byte her biri ama tamamı bir array oluyor yani liste 


    }
}
