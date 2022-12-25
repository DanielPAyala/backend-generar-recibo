using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.DTO
{
    public class ReciboDTO
    {
        public string recibo{ get; set; }
        public IFormFile archivo { get; set; }
    }
}
