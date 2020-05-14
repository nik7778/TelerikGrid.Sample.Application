using Sample.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.Services
{
    public interface IRecordService
    {
        IEnumerable<Record> GetAll();
    }
}
