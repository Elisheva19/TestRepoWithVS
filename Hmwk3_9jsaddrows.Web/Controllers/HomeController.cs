using Hmwk3_9jsaddrows.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hmwk3_9jsaddrows.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Hmwk3_9jsaddrows.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=12_27MyFirstDatabase;Integrated Security=true;";


        public IActionResult Index()
        {
            var mgr = new Manager(_connectionString);
            string message = (string)TempData["Message"];
            var vm = new IndexViewModel();
            

                if (!String.IsNullOrEmpty(message))
            {
                vm.Message = message;
            }
            vm.People = mgr.GetPpl();
                
                
            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {

            var mgr = new Manager(_connectionString);
            mgr.Add(people);
            TempData["Message"] = $"{people.Count} People added!!";
            return Redirect("/");
        }
       
    }
}
public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T Get<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        return value == null ? default(T) :
            JsonConvert.DeserializeObject<T>(value);
    }
}