using System;

namespace Pgsql_GUI.Models
{
    public class ClientModel
    {

        public ClientModel(string[] values)
        {
            if (values.Length != 5)
                throw new Exception("неверное количество элементов");
            Id_client = values[0];
            Name = values[1];
            Phone_number = values[2];
            Email = values[3];
            INN = values[4];
            Console.WriteLine(string.Join(' ', values));

        }

        public string Id_client { get; set; }
        public string Name { get; set; }

        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string INN { get; set; }
    }
}