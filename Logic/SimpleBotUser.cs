using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            var cliente = new MongoClient("mongodb://localhost:27017");            var db = cliente.GetDatabase("chatbot");            var col = db.GetCollection<BsonDocument>("log");            col.InsertOne(new BsonDocument() {
                { "user", message.User },
                { "message", message.Text }
            });
            return $"{message.User} disse '{message.Text}";
        }

    }
}