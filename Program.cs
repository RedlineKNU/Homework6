using System.Text.Json;
using System.Text.Json.Serialization;

public class Book
{
    [JsonIgnore]
    public int PublishingHouseId { get; set; }
   
    [JsonPropertyName("Title")]
    public string Name { get; set; }

    public PublishingHouse PublishingHouse { get; set; }
}

public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string path = @"data.json";

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);

            foreach (var book in books)
            {
                Console.WriteLine($"Назва: {book.Name}, Видавництво: {book.PublishingHouse.Name}, Адреса: {book.PublishingHouse.Adress}");
            }
        }
    }
}
