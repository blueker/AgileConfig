﻿using AgileConfig.Server.Data.Entity;
using AgileConfig.Server.IService;
using AgileConfig.Server.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileConfig.Server.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgileConfig.Server.Service
{
    public class ModifyLogService : IModifyLogService
    {
        private AgileConfigDbContext _dbContext;
        public ModifyLogService(ISqlContext context)
        {
            _dbContext = context as AgileConfigDbContext;
        }

        public async Task<bool> AddAsync(ModifyLog log)
        {
            _dbContext.ModifyLogs.Add(log);
            int x = await _dbContext.SaveChangesAsync();
            return x > 0;
        }

        public async Task<bool> AddRangAsync(List<ModifyLog> Logs)
        {
            _dbContext.ModifyLogs.AddRange(Logs);
            int x = await _dbContext.SaveChangesAsync();
            return x > 0;
        }

        public async Task<ModifyLog> GetAsync(string logId)
        {
            return await _dbContext.ModifyLogs.FindAsync(logId);
        }

        public async Task<List<ModifyLog>> Search(string configId)
        {
            var logs = await _dbContext.ModifyLogs.Where(m => m.ConfigId == configId).ToListAsync();

            return logs;
        }
    }
}
