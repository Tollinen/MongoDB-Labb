using MongoDB.Bson;
using MongoDB.Driver;

namespace TEST_MongoDB
{
    public class MongoDAO : DAO
    {
        MongoClient client;
        IMongoDatabase database;
        NumberCheck input = new NumberCheck();

        public MongoDAO(string db, string MongoURI)
        {
            this.client = new MongoClient(MongoURI);
            this.database = this.client.GetDatabase(db);
        }
        public void Create()
        {
            var collection = database.GetCollection<BsonDocument>("Movies");
            int movieid = (ReadAll().Count + 1);
            Console.WriteLine("Type in your movie title:");
            string title = Console.ReadLine();
            Console.WriteLine("Type in its score:");
            double score = input.CheckDouble(0, false);
            Console.WriteLine("It's genre:");
            string genre1 = Console.ReadLine();
            Console.WriteLine("Second genre:");
            string genre2 = Console.ReadLine();

            var document = new BsonDocument
            {
                {"movieid", movieid},
                {"title", title },
                {"genre", new BsonArray{ genre1, genre2 } },
                {"score", score }
            };
            collection.InsertOne(document);
            Console.WriteLine("Added.");
        }

        public void Read(int id)
        {
            var collection = database.GetCollection<BsonDocument>("Movies");
            var filter = Builders<BsonDocument>.Filter.Eq("movieid", id);
            var Document = collection.Find(filter).FirstOrDefault();
            if (Document != null)
            {
                Console.Write(Document.ToString());
            }
            else
            {
                Console.WriteLine("There is no movie with that movieid.");
            }
        }

        public List<string> ReadAll()
        {
            List<string> list = new List<string>();
            var collection = database.GetCollection<BsonDocument>("Movies");
            var firstDocument = collection.Find(new BsonDocument()).ToList();
            foreach (var item in firstDocument)
            {
                list.Add(item.ToString());
            }
            return list;

        }

        public void Update(int id)
        {
            var collection = database.GetCollection<BsonDocument>("Movies");
            var filter = Builders<BsonDocument>.Filter.Eq("movieid", id);
            var Document = collection.Find(filter).FirstOrDefault();
            if (Document != null)
            {
                Console.WriteLine($"What do you want to update?\n" +
               $"[1] Title\n" +
               $"[2] Score\n" +
               $"[3] First genre\n" +
               $"[4] Second genre\n" +
               $"[5] Exit"
               );
                switch (input.CheckInt(5, true))
                {
                    case 1:         //Title
                        Console.WriteLine("Enter the new title:");
                        var updateTitle = Builders<BsonDocument>.Update.Set("title", Console.ReadLine());
                        collection.UpdateOne(filter, updateTitle);
                        Console.WriteLine("Updated!");
                        break;

                    case 2:         //Score
                        Console.WriteLine("Enter the new score:");
                        var updateScore = Builders<BsonDocument>.Update.Set("score", input.CheckDouble(10, true));
                        collection.UpdateOne(filter, updateScore);
                        Console.WriteLine("Updated!");
                        break;

                    case 3:         //Genre 1
                        Console.WriteLine("Enter the new genre:");
                        var updateGenre1 = Builders<BsonDocument>.Update.Set("genre.0", Console.ReadLine());
                        collection.UpdateOne(filter, updateGenre1);
                        Console.WriteLine("Updated!");
                        break;

                    case 4:         //Genre 2
                        Console.WriteLine("Enter the new genre:");
                        var updateGenre2 = Builders<BsonDocument>.Update.Set("genre.1", Console.ReadLine());
                        collection.UpdateOne(filter, updateGenre2);
                        Console.WriteLine("Updated!");
                        break;

                    case 5:         //Exit
                        break;

                    default:
                        Console.WriteLine("Something went wrong.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no movie with that movieid.");
            }
        }

        public void Delete(int id)
        {
            var collection = database.GetCollection<BsonDocument>("Movies");
            var deletefilter = Builders<BsonDocument>.Filter.Eq("movieid", id);
            var Document = collection.Find(deletefilter).FirstOrDefault();
            if (Document != null)
            {
                collection.DeleteOne(deletefilter);
                Console.WriteLine("Deleted.");
            }
            else
            {
                Console.WriteLine("There is no movie with that movieid.");
            }
        }
    }
}
