﻿using Asp.Versioning;
using CsharpKT.ApiModels;
using CsharpKTApi.Models.v2;
using CsharpKTApi.Persistence;
using CsharpKTApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CsharpKTApi.Controllers.v2
{
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly CsharpDbContext _context;
        private readonly IDeveloperRepository _developerRepository;

        public DevelopersController(
            CsharpDbContext context,
            IDeveloperRepository developerRepository)
        {
            _context = context;
            _developerRepository = developerRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostDeveloper(DeveloperRequestModel request)
        {
            var developer = Developer.Create(Guid.NewGuid().ToString(), request.Name);

            await _developerRepository.Add(developer);

            //await _context.Developers.AddAsync(developer);

            //await _context.SaveChangesAsync();

            return Accepted();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Developer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDeveloper(string id)
        {
            var developer = _context.Developers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return Ok(developer);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutDeveloper(string id, string name)
        {
            var developer = _context.Developers.FirstOrDefault(x => x.Id == id);

            developer.UpdateName(name);

            await _context.SaveChangesAsync();

            return Accepted();
        }
    }
}
