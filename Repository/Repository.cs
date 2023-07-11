using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Entity.Data;
using Entity.Model;
using Contract.IRepository;
using NLog;

namespace Repository;
public class Repository : IRepository
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public Repository()
    {

    }

}
