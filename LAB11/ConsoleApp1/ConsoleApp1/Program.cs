

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Firebase.Database;
using Firebase.Database.Query;

namespace Lab11RichVip
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int Coins { get; set; }
        public bool IsActive { get; set; }
        public int VipLevel { get; set; }
        public string Region { get; set; }
        public DateTime LastLogin { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Player> players = await LoadPlayersFromUrl();

            while (true)
            {
                Console.WriteLine("\n===== MENU CHINH =====");
                Console.WriteLine("1. Bai 1: Nguoi choi giau nhat");
                Console.WriteLine("2. Bài 2: Thong ke & tim kiem nguoi choi VIP");
                Console.WriteLine("3. Thoat");
                Console.Write("Chon (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await Bai1Menu(players);
                        break;
                    case "2":
                        await Bai2Menu(players);
                        break;
                    case "3":
                        Console.WriteLine("Tam biet");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }

        static async Task<List<Player>> LoadPlayersFromUrl()
        {
            string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
            using var http = new HttpClient();
            string json = await http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        // bai 1: 
        static async Task Bai1Menu(List<Player> players)
        {
            while (true)
            {
                Console.WriteLine("\n----- Menu -----");
                Console.WriteLine("1.Nguoi choi giau nhat");
                Console.WriteLine("2. Tai ket qua len Firebase");
                Console.WriteLine("3. Quay lai");
                Console.Write("Chon (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var result = from p in players
                                     where p.Gold > 1000 && p.Coins > 100
                                     orderby p.Gold descending
                                     select new { p.Name, p.Gold, p.Coins };

                        Console.WriteLine("Nguoi choi giau:");
                        foreach (var p in result)
                        {
                            Console.WriteLine($"- {p.Name}, Gold: {p.Gold}, Coins: {p.Coins}");
                        }
                        break;

                    case "2":
                        await PushRichPlayersToFirebase(players);
                        break;

                    case "3":
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }

        static async Task PushRichPlayersToFirebase(List<Player> players)
        {
            var rich = players
                .Where(p => p.Gold > 1000 && p.Coins > 100)
                .OrderByDescending(p => p.Gold)
                .Select(p => new { p.Name, p.Gold, p.Coins });

            var client = new FirebaseClient("https://demo01-c9b5a-default-rtdb.asia-southeast1.firebasedatabase.app/");
            await client.Child("quiz_bai1_richPlayers").PutAsync(rich);
            Console.WriteLine("da tai ket qua len Firebase!");
        }

        // bai 2: 
        static async Task Bai2Menu(List<Player> players)
        {
            while (true)
            {
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("1. Tong so nguoi choi VIP");
                Console.WriteLine("2. So luong nguoi choi vip theo khu vuc");
                Console.WriteLine("3. Tim nguoi choi VIP gan day");
                Console.WriteLine("4.Tai danh sach len Firebase");
                Console.WriteLine("5. Quay lai");
                Console.Write("Chon (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int vipCount = players.Count(p => p.VipLevel > 0);
                        Console.WriteLine($"Tong so nguoi choi VIP: {vipCount}");
                        break;

                    case "2":
                        var vipByRegion = from p in players
                                          where p.VipLevel > 0
                                          group p by p.Region into g
                                          select new { Region = g.Key, Count = g.Count() };

                        Console.WriteLine("Vip theo khu vuc:");
                        foreach (var group in vipByRegion)
                        {
                            Console.WriteLine($"- {group.Region}: {group.Count}");
                        }
                        break;

                    case "3":
                        DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
                        var recent = from p in players
                                     where p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2
                                     select new { p.Name, p.VipLevel, p.LastLogin };

                        Console.WriteLine("Nguoi choi VIP dang nhap gan day:");
                        foreach (var p in recent)
                        {
                            Console.WriteLine($"- {p.Name}, VIP {p.VipLevel}, Login: {p.LastLogin}");
                        }
                        break;

                    case "4":
                        await PushRecentVipToFirebase(players);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }

        static async Task PushRecentVipToFirebase(List<Player> players)
        {
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);

            var recent = players
                .Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                .Select(p => new { p.Name, p.VipLevel, p.LastLogin });

            var client = new FirebaseClient("https://demo01-c9b5a-default-rtdb.asia-southeast1.firebasedatabase.app/");
            await client.Child("quiz_bai2_recentVipPlayers").PutAsync(recent);
            Console.WriteLine("Da tai danh sach VIP moi dang nhap");
        }
    }
}