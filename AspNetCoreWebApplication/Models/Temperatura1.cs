using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;

namespace AspNetCoreWebApplication.Models
{
    public partial class Temperatura1 
    {
        public int Ts {get;set;}
        public string Mac_Id {get;set;}
        public int Temperatura {get;set;}


    }
     
}