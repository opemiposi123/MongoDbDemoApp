using MongoDB.Driver;
using MongoDbDemo; 

string connectionString = "mongodb://localhost:27017";
string databaseName = "simple_db";
string collectionName = "person";
var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<PersonModel>(collectionName);
var person = new PersonModel
{
	FirstName = "DevMahmood",
	LastName = "AbdulWaheed"
};
await collection.InsertOneAsync(person);
var results = await collection.FindAsync(_ => true);
foreach (var result in results.ToList())
{
	Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName}");
}