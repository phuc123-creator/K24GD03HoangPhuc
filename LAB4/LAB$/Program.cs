using System;
using System.Collections.Generic;

class MatHang
{
    public int MaMH { get; set; }
    public string TenMH { get; set; }
    public int SoLuong { get; set; }
    public double DonGia { get; set; }

    public MatHang(int ma, string ten, int sl, double dg)
    {
        MaMH = ma;
        TenMH = ten;
        SoLuong = sl;
        DonGia = dg;
    }
    public double ThanhTien()
    {
        return SoLuong * DonGia;
    }
}

class Program
{
    static List<MatHang> danhSachMatHang = new List<MatHang>();

    static void ThemMatHang()
    {
        try
        {
            Console.Write("Nhap ma mat hang: ");
            int ma = int.Parse(Console.ReadLine());

            Console.Write("Nhap ma mat hang: ");
            string ten = Console.ReadLine();

            Console.Write("Nhap so luong: ");
            int sl = int.Parse(Console.ReadLine());

            Console.Write("Nhap don gia: ");
            double dg = double.Parse(Console.ReadLine());

            danhSachMatHang.Add(new MatHang(ma, ten, sl, dg));
            Console.WriteLine("Đa them mat hang thanh cong!\n");
        }
        catch (FormatException)
        {
            Console.WriteLine("Loi: Vui long nhap dung dinh dang so!\n");
        }
    }
    static void XuatDanhSach()
    {
        if (danhSachMatHang.Count == 0)
        {
            Console.WriteLine("Danh sach mat hang dang trong.\n");
            return;
        }

        Console.WriteLine("\nDanh sach mat hang:");
        foreach (var mh in danhSachMatHang)
        {
            Console.WriteLine($"MaMH: {mh.MaMH}, TenMH: {mh.TenMH}, SoLuong: {mh.SoLuong}, DonGia: {mh.DonGia}, ThanhTien: {mh.ThanhTien()}");
        }
    }
    static MatHang TimMatHang(int ma)
    {
        return danhSachMatHang.Find(mh => mh.MaMH == ma);
    }
    static void XoaMatHang()
    {
        if (danhSachMatHang.Count == 0)
        {
            Console.WriteLine("Danh sach mat hang rong, khong the xoa.\n");
            return;
        }

        Console.Write("Nhap ma mat hang can tim: ");
        int maXoa;
        if (!int.TryParse(Console.ReadLine(), out maXoa))
        {
            Console.WriteLine("Loi: Ma mat hang phai la so nguyen!\n");
            return;
        }

        MatHang matHang = TimMatHang(maXoa);
        if (matHang != null)
        {
            danhSachMatHang.Remove(matHang);
            Console.WriteLine($"Đa xoa mat hang {matHang.TenMH} (Ma: {matHang.MaMH}) thanh cong!\n");
            XuatDanhSach();
        }
        else
        {
            Console.WriteLine("Mat hang khong ton tai.\n");
        }
    }

    static void Main()
    {
        char tiepTuc;
        do
        {
            ThemMatHang();
            Console.Write("Ban co muon tiep tuc nhan(y/n)? ");
            tiepTuc = Console.ReadLine().ToLower()[0];
        } while (tiepTuc == 'y');

        XuatDanhSach();
        XoaMatHang();
    }
}

//static void ListExample()
//{
//    List<string> fruits = new List<string>();
//    fruits.Add("Apple");
//    fruits.Add("Banana");
//    fruits.Add("Cherry");
//    fruits.Insert(1, "BlueBerry");
//    Console.WriteLine("Contains Banana? " + fruits.Contains("Banana"));
//    fruits[0] = "Avocado";
//    fruits.Remove("Banana");
//    fruits.RemoveAt(0);
//}

//Dictionary<string, int> ages = new Dictionary<string, int>();
//ages.Add("Alice", 25);
//ages.Add("Bob", 30);

//if (ages.ContainsKey("Key"))
//    Console.WriteLine("Alice is" + ages["Alice"] + "years old");

//ages["Alice"] = 26;
//ages.Remove("Bob");

//foreach (var kvp in ages)
//    Console.WriteLine($"{kvp.Key}: {kvp.Value}");

//static void QueueExample()
//{
//    Queue<string> tasks = new Queue<string>();
//    tasks.Enqueue("Dowload file");
//    tasks.Enqueue("Scan file");
//    Console.WriteLine("Next task: " + tasks.Peek());
//    Console.WriteLine("Processing: " + tasks.Dequeue());

//    foreach (var task in tasks)
//        Console.WriteLine(tasks);
//}

//static void StackExample()
//{
//    Stack<string> history = new Stack<string>();
//    history.Push("Page 1");
//    history.Push("Page 2");
//    Console.WriteLine("Current page: " + history.Peek());
//    Console.WriteLine("Go back: " + history.Pop());

//    foreach (var item in history)
//        Console.WriteLine(page);
//}


//static void SortedListExample()
//{
//    SortedList<int, string> students = new SortedList<int, string>();
//    students.Add(102, "Lam");
//    students.Add(101, "Nam");
//    students.Add(105, "Hòa");
//    students[102] = "Linh";

//    if (students.ContainsKey(105))
//        Console.WriteLine("Student 105: " + students[105]);

//    students.Remove(101);

//    foreach (var s in students)
//        Console.WriteLine($"{s.Key}: {s.Value}");
//}