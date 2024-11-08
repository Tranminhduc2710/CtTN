using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtTracNghiem
{
    public class ThaoTacFile
    {
        public static List<T> ReadJsonFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static void WriteJsonToFile<T>(List<T> data, string filePath)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        internal static void WriteJsonToConstantFile(Class_DeThi deThi, string v)
        {
            throw new NotImplementedException();
        }
        public static List<Class_DeThi> ReadJsonFromFile(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var danhSachDeThi = JsonConvert.DeserializeObject<List<Class_DeThi>>(jsonString);
                return danhSachDeThi;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Lỗi khi deserialization: {ex.Message}");
                return null;
            }
        }
        public static void WriteJsonToConstantFile(List<Class_DeThi> danhSachDeThi, string fileName)
        {
            string json = JsonConvert.SerializeObject(danhSachDeThi, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public static void SaveToJson<T>(T data, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
        public static void UpdateDeThiJson(Class_DeThi newDeThi)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DeThi.json");
            List<Class_DeThi> danhSachDeThi;

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                danhSachDeThi = JsonConvert.DeserializeObject<List<Class_DeThi>>(jsonContent) ?? new List<Class_DeThi>();
            }
            else
            {
                danhSachDeThi = new List<Class_DeThi>();
            }

            // Kiểm tra xem đề thi đã tồn tại chưa
            var existingDeThi = danhSachDeThi.FirstOrDefault(d => d.MaDT == newDeThi.MaDT);
            if (existingDeThi != null)
            {
                // Nếu đã tồn tại, cập nhật thông tin
                int index = danhSachDeThi.IndexOf(existingDeThi);
                danhSachDeThi[index] = newDeThi;
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới
                danhSachDeThi.Add(newDeThi);
            }

            string updatedJsonString = JsonConvert.SerializeObject(danhSachDeThi, Formatting.Indented);
            File.WriteAllText(filePath, updatedJsonString);
        }

    }

}
