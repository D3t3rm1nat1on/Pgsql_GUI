using System;

namespace Pgsql_GUI.Models
{
    public class Staff
    {
        public Staff(string[] values)
        {
            if (values.Length != 6)
                throw new Exception("неверное количество элементов");
            ID_Staff = values[0];
            Name = values[1];
            Email = values[2];
            Phone = values[3];
            Position_ID = values[4];
            INN = values[5];
            Console.WriteLine(string.Join(' ', values));
        }

        public string ID_Staff { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position_ID { get; set; }

        public string INN { get; set; }
        
    }
}