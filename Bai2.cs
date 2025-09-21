using System;

namespace EX61
{
    internal class Program
    {
        // Khởi tạo dữ liệu mẫu
        static object[][][] InitializeData()
        {
            object[][][] groups = new object[3][][];

            groups[0] = new object[5][];
            groups[1] = new object[3][];
            groups[2] = new object[6][];

            groups[0][0] = new object[] { 101, "Nguyen Van A", 10 };
            groups[0][1] = new object[] { 102, "Tran Van B", 12 };
            groups[0][2] = new object[] { 103, "Le Thi C", 8 };
            groups[0][3] = new object[] { 104, "Pham Van D", 15 };
            groups[0][4] = new object[] { 105, "Do Van E", 9 };

            groups[1][0] = new object[] { 201, "Nguyen Van F", 7 };
            groups[1][1] = new object[] { 202, "Tran Thi G", 13 };
            groups[1][2] = new object[] { 203, "Pham Van H", 5 };

            groups[2][0] = new object[] { 301, "Le Van I", 11 };
            groups[2][1] = new object[] { 302, "Nguyen Van J", 14 };
            groups[2][2] = new object[] { 303, "Tran Van K", 6 };
            groups[2][3] = new object[] { 304, "Pham Thi L", 18 };
            groups[2][4] = new object[] { 305, "Do Van M", 10 };
            groups[2][5] = new object[] { 306, "Nguyen Thi N", 16 };

            return groups;
        }

        // In tất cả thành viên
        static void PrintAllMembers(object[][][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"\nGroup {i + 1}:");
                for (int j = 0; j < groups[i].Length; j++)
                {
                    Console.WriteLine($"ID: {groups[i][j][0]}, Name: {groups[i][j][1]}, Tasks: {groups[i][j][2]}");
                }
            }
        }

        // In thông tin theo ID
        static void PrintMemberById(object[][][] groups, int id)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups[i].Length; j++)
                {
                    if ((int)groups[i][j][0] == id)
                    {
                        Console.WriteLine($"\nTìm thấy thành viên ID {id}: Name: {groups[i][j][1]}, Tasks: {groups[i][j][2]}");
                        return;
                    }
                }
            }
            Console.WriteLine($"\nKhông tìm thấy thành viên có ID {id}.");
        }

        // Thành viên làm nhiều task nhất
        static void PrintTopMember(object[][][] groups)
        {
            object[] best = groups[0][0];
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups[i].Length; j++)
                {
                    if ((int)groups[i][j][2] > (int)best[2])
                    {
                        best = groups[i][j];
                    }
                }
            }
            Console.WriteLine($"\nThành viên nhiều task nhất: ID: {best[0]}, Name: {best[1]}, Tasks: {best[2]}");
        }

        static void Main(string[] args)
        {
            object[][][] groups = InitializeData();

            // 1. In tất cả
            PrintAllMembers(groups);

            // 2. In theo ID (ví dụ ID=104)
            PrintMemberById(groups, 104);

            // 3. In người nhiều task nhất
            PrintTopMember(groups);

            Console.ReadLine();
        }
    }
}
