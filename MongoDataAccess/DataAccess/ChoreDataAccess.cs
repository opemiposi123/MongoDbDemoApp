using MongoDataAccess.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace MongoDataAccess.DataAccess;

public  class ChoreDataAccess
{
	private const string ConnectionString = "mongodb://localhost:27017";
	private const string DatabaseName = "chore_db";
	private const string ChoreCollection = "chore_chart";
	private const string UserCollection = "users";
	private const string ChoreHistoryCollection = "chore_history";

	private IMongoCollection<T> ConnectToMongo<T>(in string collection)
	{
		var client = new MongoClient(ConnectionString);
		var db = client.GetDatabase(DatabaseName);
		return db.GetCollection<T>(collection);
	}
}
