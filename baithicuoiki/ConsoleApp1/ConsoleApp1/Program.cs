using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

class Program
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public bool IsActive { get; set; }
        public int VipLevel { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    static async Task Main(string[] args)
    {
        var firebaseClient = new FirebaseClient("https://demo01-c9b5a-default-rtdb.asia-southeast1.firebasedatabase.app/");
        int id = 1;
        string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
        string json = await new HttpClient().GetStringAsync(url);
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

        for (int i = 0; i < players.Count; i++)
        {
            players[i].Id = $"P{i + 1:D3}";
        }

        while (true)
        {
            Console.WriteLine("\n==================== MENU ====================");
            Console.WriteLine("1. Nhung nguoi choi khong hoat đong");
            Console.WriteLine("2. Nhung nguoi choi cap thap");
            Console.WriteLine("3. Trao thuong cho top 3 VIP");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon nao cung duoc: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await HandleInactivePlayers(players, firebaseClient);
                    break;
                case "2":
                    await HandleLowLevelPlayers(players, firebaseClient);
                    break;
                case "3":
                    await HandleTop3Vip(players, firebaseClient);
                    break;
                case "4":
                    Console.WriteLine("Tam biet");
                    return;
                default:
                    Console.WriteLine("Lua chon sai bet");
                    break;
            }
        }
    }

    static async Task HandleInactivePlayers(List<Player> players, FirebaseClient firebase)
    {
        DateTime now = new DateTime(2025, 06, 30, 0, 0, 0, DateTimeKind.Utc);
        var result = players
            .Where(p => !p.IsActive || (p.LastLogin.HasValue && (now - p.LastLogin.Value).TotalDays > 5))
            .Select(p => new { p.Id, p.Name, p.IsActive, p.LastLogin })
            .ToList();

        Console.WriteLine("\nNguoi choi khong hoat dong:");
        result.ForEach(p =>
            Console.WriteLine($"ID: {p.Id}, Tên: {p.Name}, IsActive: {p.IsActive}, LastLogin: {p.LastLogin}")
        );

        await firebase.Child("final_exam_bai1_inactive_players").PutAsync(result);
    }

    static async Task HandleLowLevelPlayers(List<Player> players, FirebaseClient firebase)
    {
        var result = players
            .Where(p => p.Level < 10)
            .Select(p => new { p.Id, p.Name, p.Level, p.Gold })
            .ToList();

        Console.WriteLine("\n Nguoi choi cap thap:");
        result.ForEach(p =>
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Level: {p.Level}, Gold: {p.Gold}")
        );

        await firebase.Child("final_exam_bai1_low_level_players").PutAsync(result);
    }

    static async Task HandleTop3Vip(List<Player> players, FirebaseClient firebase)
    {
        var result = players
            .Where(p => p.VipLevel > 0)
            .OrderByDescending(p => p.Level)
            .ThenByDescending(p => p.Gold)
            .Take(3)
            .Select((p, i) => new {
                p.Id,
                p.Name,
                p.VipLevel,
                p.Level,
                CurrentGold = p.Gold,
                BonusGold = i == 0 ? 2000 : i == 1 ? 1500 : 1000
            })
            .ToList();

        Console.WriteLine("\n Top 3 VIP nhan thuong:");
        result.ForEach(p =>
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, VIP: {p.VipLevel}, Level: {p.Level}, Gold: {p.CurrentGold}, Thuong: {p.BonusGold}")
        );

        await firebase.Child("final_exam_bai2_top3_vip_awards").PutAsync(result);
    }
}