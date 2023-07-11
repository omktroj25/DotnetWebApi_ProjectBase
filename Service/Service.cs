using Microsoft.Extensions.Configuration;
using Entity.Data;
using AutoMapper;
using Repository;
using Microsoft.Extensions.Logging;
using Contract.IRepository;
using Contract.IService;
using Microsoft.AspNetCore.Http;
using Entity.Dto;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Entity.Model;
using NLog;
using Exception;

namespace Service;
public class Service : IService
{
    private readonly IMapper _mapper;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public Service()
    {

    }

}
