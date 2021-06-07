using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor;


namespace AspNetCoreWebApplication.Controllers
{

    
    public class HomeController : Controller
    {
        
        private ApplicationDbContext _context;
        alumno objAlumno2 = new alumno();

        public IActionResult Index()
        {
            var alumno=_context.newtable.ToList();
            return View(alumno);
    
        }

        public HomeController(

            ApplicationDbContext c
            
        ) {
            _context = c;
         
        }
        

        public async Task<IActionResult> Buscador()
        {
            List<String> lectura = new List<string>();
            List<int> listadni = new List<int>();
            int i =0;
            int j =0;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://206pu2l98g.execute-api.us-east-1.amazonaws.com/Test1/recurso-api-medical");
            Console.WriteLine(json);
            
            do{
                string valor = "";
                int dni = 0;
                if(i==0){
                    j=33;
                    i++;
                }
                dni= int.Parse(json.Substring(j,8));
                j=j+25;
                valor=json.Substring(j,2);
                j=j+12;
                lectura.Add(valor);
                listadni.Add(dni);
            }while(j<= (json.Length-52));
            
            foreach(string val in lectura){
                Console.WriteLine(val);
                objAlumno2.temp = val;
            }
            foreach(int val in listadni){
                Console.WriteLine(val);
                objAlumno2.id = val;
            }
            
            alumno objalumno = new alumno();
            objalumno = _context.newtable.FirstOrDefault(i => i.id == objAlumno2.id);
            objalumno.temp = objAlumno2.temp;
            _context.Update(objalumno);
            _context.SaveChanges();

            var alumno=_context.newtable.ToList();
            return View(alumno);
        }

         public IActionResult exTemperatura()
        {
                 
            return View();
        }

        // [HttpPost]
        // public async Task<ActionResult> Buscador(int x)
        // {
        //     List<String> lectura = new List<string>();
        //     int i =0;
        //     int j =0;
        //     var httpClient = new HttpClient();
        //     var json = await httpClient.GetStringAsync("https://lrsnm3o3c2.execute-api.us-east-2.amazonaws.com/testread/lectura");
        //     Console.WriteLine(json);

            // do{
            //     string valor = "";
            //     if(i==0){
            //         j=89;
                    
            //         i++;
                
            //     }
            //     valor=json.Substring(j,2);
            //     j=j+67;
            //     lectura.Add(valor);

            // }while(j<= (json.Length-51));
            
            // foreach(string val in lectura){
            //     Console.WriteLine(val);
            //     objAlumno2.temperatura = val;
            // }    

            // alumno objalumno = new alumno();
            // objalumno = _context.newtable.FirstOrDefault(i => i.dni == x);
            // objalumno.temperatura = objAlumno2.temperatura;
            // _context.Update(objalumno);
            // _context.SaveChanges();

        //     return View(objalumno);
        // }



        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }
    }
}