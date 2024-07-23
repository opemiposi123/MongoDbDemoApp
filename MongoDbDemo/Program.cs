using MongoDB.Driver;
using MongoDbDemo;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

//string connectionString = "mongodb://localhost:27017";
//string databaseName = "simple_db";
//string collectionName = "person";
//var client = new MongoClient(connectionString);
//var db = client.GetDatabase(databaseName);
//var collection = db.GetCollection<PersonModel>(collectionName);
//var person = new PersonModel
//{
//	FirstName = "DevMahmood",
//	LastName = "AbdulWaheed"
//};
//await collection.InsertOneAsync(person);
//var results = await collection.FindAsync(_ => true);
//foreach (var result in results.ToList())
//{
//	Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName}");
//}


ChoreDataAccess db = new ChoreDataAccess();
await db.CreateUser(new UserModel()
{
	FirstName = "DevMahmood",
	LastName = "AbdulWaheed"
});
var users = await db.GetAllUsers();

var chore = new ChoreModel()
{
	AssignedTo = users.First(),
	ChoreText = "Learn New Things About C#",
	FrequencyInDays = 1
};
await db.CreateChore(chore);

var chores = await db.GetAllChores();

var newChore = chores.First();

newChore.LastCompleted = DateTime.UtcNow;

await db.CompleChore(newChore);
