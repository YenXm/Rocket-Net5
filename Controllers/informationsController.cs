using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using RocketApi.Models;


namespace RocketApi.Controllers
{


    
    [Route("api/[controller]")]
    [ApiController]
    public class informationController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public informationController(ApplicationContext context, ILogger<informationController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<int>> GetAllCount()
        {


            int notInUseElevatorCount = await DirectCount();
            int elevatorCount = await _context.elevators.CountAsync();
            int buildingCount = await _context.buildings.CountAsync();
            int customerCount = await _context.customers.CountAsync();
            int batteryCount = await _context.batteries.CountAsync();
            int cityCount = SqlCount();
            int quoteCount = await _context.quotes.CountAsync();
            int leadCount = await _context.leads.CountAsync();
            return new List<int> { elevatorCount, buildingCount, customerCount, notInUseElevatorCount, cityCount, quoteCount, leadCount, batteryCount };
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        // This part tries multiple way of finding the number of distinct city
        [HttpGet("HashSetCount")]
        public async Task<int> HashSetCount()
        {
            // Count the amount of Distinct City in our address collection using 
            // a HashSet.
            HashSet<string> city = new HashSet<string>();
            await _context.addresses.ForEachAsync(c => city.Add(c.city));
            int cityCount = city.Count();
            return cityCount;
        }
        [HttpGet("DistinctCount")]
        public async Task<int> DistinctCount()
        {
            // Count the amount of Distinct City in our address collection using 
            // a list and the distinct method on it.
            List<string> city = new List<string>();
            await _context.addresses.ForEachAsync(c => city.Add(c.city));
            int cityCount = city.Distinct().Count();
            return cityCount;
        }

        [HttpGet("SqlAndDistinctCount")]
        public int SqlAndDistinctCount()
        {
            return _context.city.FromSqlRaw("SELECT city FROM addresses").Distinct().Count();
        }
        [HttpGet("SqlCount")]
        public int SqlCount()
        {   
            return _context.city.FromSqlRaw("SELECT DISTINCT city FROM addresses").Count();
        }

        //-----------------------------------------------------------------------------------------------------------

        //This part tries multiple way to get the number of elevator that are not running.

        [HttpGet("WhereCount")]
        public async Task<int> WhereCount()
        {
            return await _context.elevators.CountAsync(b => ((b.status == "Offline") || (b.status == "Intervention")));
        }
        [HttpGet("DirectCount")]
        public async Task<int> DirectCount()
        {
            return await _context.elevators.Where(b => ((b.status == "Offline") || (b.status == "Intervention"))).CountAsync();
        }

        [HttpGet("SqlWhereCount")]
        public int SqlWhereCount()
        {
            return _context.elevators.FromSqlRaw("SELECT * FROM elevators WHERE status = 'Offline' OR status = 'Intervention'").Count();
        }
    }
}