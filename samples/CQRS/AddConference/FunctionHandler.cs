﻿using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input)
        {
            Console.WriteLine("Hi there - your input was: "+ input);
            // try Mongo-Client
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");

            var dl = new Data.DataLayer();
            dl.SaveEventData(input);
        }
    }
}
