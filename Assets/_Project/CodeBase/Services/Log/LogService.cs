﻿using CodeBase.Services.LogService;
using UnityEngine;

namespace _Project.CodeBase.Services.Log
{
    public class LogService : ILogService
    {
        public void Log(string msg) => 
            Debug.Log(msg);
        
        public void LogError(string msg) => 
            Debug.LogError(msg);

        public void LogWarning(string msg) => 
            Debug.LogWarning(msg);
    }
}