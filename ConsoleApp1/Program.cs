using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //дистанционка, от 26.10
            //Задание 1
            string[] rows = File.ReadAllLines("spells.2da");
            char[] splitter = new char[] { ' ' };
            for (int i = 3; i < rows.Length - 1; i++)
                string[] cols = rows[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            if (cols.Length > 13 && cols[13] != "****")
                Console.WriteLine($"{cols[1]} {cols[9]}");

            //Задание 2

            var header = rows.Take(3);
            string file = "Acid.2da";
            if (File.Exists(file))
                File.Delete(file);
            File.AppendAllLines(file, header);
            var headerCols = header.Last().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();
            int immunityTypeIndex = headerCols.IndexOf("ImmunityType") + 1;
            for (int i = 3; i < rows.Length; i++)
                string[] cols = rows[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            if (cols.Length > immunityTypeIndex && cols[immunityTypeIndex] == "Acid")
                File.AppendAllText(file, rows[i] + "\n");
            //Задание 3

            CreateFileFilterByColumn(rows, 10, "Bard.2da");
            CreateFileFilterByColumn(rows, 11, "Cleric.2da");
            CreateFileFilterByColumn(rows, 12, "Druid.2da");
            CreateFileFilterByColumn(rows, 13, "Paladin.2da");
            CreateFileFilterByColumn(rows, 14, "Ranger.2da");
            CreateFileFilterByColumn(rows, 15, "Wiz_Sorc.2da"); 
            static void CreateFileFilterByColumn(string[] rowsFile, int indexClass, string fileName)
                List<string> newFileData = new List<string>();
            var header = rowsFile.Take(3);
            newFileData.AddRange(header);
            char[] splitter = new char[] { ' ' };
            for (int i = 3; i < rowsFile.Length; i++)
            {
                var cols = rowsFile[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length > indexClass && cols[indexClass] != "****")
                    newFileData.Add(rowsFile[i]);
            }

            File.WriteAllLines(fileName, newFileData);







        }
    }
}
