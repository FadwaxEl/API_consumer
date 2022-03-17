using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivacyDb.Data;
using PrivacyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace PrivacyDb.Controller
{
    [ApiController]
    [Route("/CRUDAPI")]
    public class Livre2 : ControllerBase
    {
        public IList<Livre> Livre { get; set; }
        DataContext _context;
        public Livre2(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async  Task<IList<Livre>> Get()
        {

            Livre = await _context.Livres.ToListAsync();
            System.IO.File.WriteAllText("mon.json", JsonConvert.SerializeObject(Livre));
            return Livre;
        }

        //insertion 
        [HttpPost]
        public async Task<string> Post(Livre monLivre)
        {
            _context.Livres.Add(monLivre);
            await _context.SaveChangesAsync();

             
           /* string Filename = "Mon.json";
           
            string jsonString = JsonSerializer.Serialize(monLivre);

            Console.WriteLine(jsonString);
           
            File.WriteAllText(Filename, jsonString);
            
            Console.WriteLine(File.ReadAllText(Filename));*/

            return "Inserted succesfuly";
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            Livre l = await _context.Livres.FindAsync(id);
            if(l!= null)
            {
                _context.Livres.Remove(l);
                await _context.SaveChangesAsync();
                return "deleted succesfully";
            }
            else
            {
                return "error while deleting ";
            }


        }

        


    }
}
