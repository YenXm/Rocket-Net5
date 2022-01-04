using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class informationController : ControllerBase
    {        
        private readonly ApplicationContext _context;

        public informationController( ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<int>> GetAllCount()
        {
            int notInUseElevatorCount = await _context.elevators.Where(b => ((b.status == "Offline") || (b.status == "Intervention"))).CountAsync();
            int elevatorCount = await _context.elevators.CountAsync();
            int buildingCount = await _context.buildings.CountAsync();
            int customerCount = await _context.customers.CountAsync();
            int batteryCount = await _context.batteries.CountAsync();

            List<string> city = new List<string>();
            await _context.addresses.ForEachAsync(c => city.Add(c.city));
            int cityCount = city.Distinct().Count();

            int quoteCount = await _context.quotes.CountAsync();
            int leadCount = await _context.leads.CountAsync();

            return new List<int>{elevatorCount, buildingCount, customerCount, notInUseElevatorCount, cityCount, quoteCount, leadCount, batteryCount};
        }
    }
}