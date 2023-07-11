using Entity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entity.Model;
using Service;
using Repository;
using Contract.IService;
using Contract.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Api;
using Api.Controller;
using Microsoft.Extensions.DependencyInjection;
using Entity;

namespace ApiTest
{
    public class BaseTesting
    {
        public readonly Api.Controller.Controller controller;
        public readonly IConfiguration _config;
        public readonly ApiDbContext _context;
        private readonly DbContextOptionsBuilder<ApiDbContext> optionsBuilder;
        public readonly IMapper _mapper;

        public BaseTesting()
        {

            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new ApiDbContext(optionsBuilder.Options);
            _context.SaveChanges();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            _mapper = mapperConfiguration.CreateMapper();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();





            String name = "Name";
            Guid userId = Guid.NewGuid();

            List<Claim> claims = new List<Claim>
            {
                new Claim("NameIdentifier", name),
                new Claim("NameId",userId.ToString()),
                new Claim(ClaimTypes.Role, "User" ),
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "TestAuthType");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.User = principal;
            ControllerContext controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            controller!.ControllerContext = controllerContext;

        }
    }
}