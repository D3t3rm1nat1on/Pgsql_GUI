using System;

namespace Pgsql_GUI.Models
{
    public class ReportModel
    {
        public ReportModel(string[] values)
        {
            if (values.Length != 7)
                throw new Exception("неверное количество элементов");
            ID_Staff = values[0];
            Name = values[1];
            Task_number = values[2];
            Type = values[3];
            Contract = values[4];
            Start_date = values[5];
            FInish_date = values[6];
            Console.WriteLine(string.Join(' ', values));
        }

        public string ID_Staff { get; set; }
        public string Name { get; set; }
        public string Task_number { get; set; }
        public string Type { get; set; }
        public string Contract { get; set; }
        public string Start_date { get; set; }
        public string FInish_date { get; set; }
    }
}