﻿using System;
using System.Threading.Tasks;
using CalorieContent.Core.Repositories;
using CalorieContent.Domain.Entities;
using CalorieContent.lib.KeyValueStorage;

namespace CalorieContent.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();
            
            var repo = new IngredientRepo(storage);
            
         //   var t = repo.GetAll();GetAll

 //           storage.TryGetString(0,"database", out string result);
//            Console.WriteLine(result);
            
            storage.SetString(0, "database", "lol");
            storage.SetString(0, "dat1base", "lol");
            storage.SetString(0, "datab1se", "lol");
            
            storage.SetString(0, "dat1base", "lol1");

            var map = storage.GetAllStrings(0);
            foreach (var m in map)
            {
                Console.WriteLine(m.Key + ":" + m.Value);
            }

            //Console.WriteLine(result);
        }
    }
}