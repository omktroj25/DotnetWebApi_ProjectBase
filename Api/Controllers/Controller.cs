using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Entity.Dto;
using Repository;
using AutoMapper;
using Entity.Data;
using NLog;
using Service;
using Contract.IService;

namespace Api.Controller
{ 
      
    [ApiController]
    public class Controller : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public Controller()
        {
            


        }

    }
}
