using Microsoft.Extensions.Configuration;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork(IConfiguration config)
        {
            Configuration = config;


        }
        public SignService SignService { get; set; }


        private IConfiguration Configuration { get; }
    }
}
