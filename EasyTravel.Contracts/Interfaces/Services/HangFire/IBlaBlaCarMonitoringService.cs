﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces.Core;

namespace EasyTravel.Contracts.Interfaces.Services.HangFire
{
    public interface IBlaBlaCarMonitoringService
    {
        Task StartMonitoring(string from, string to, DateTime departureDate, int minPlaces, string userId);

        Task StopMonitoring(string id);

        Task<IEnumerable<IMonitoring>> GetAllMonitoringForUser(string userId);
    }
}