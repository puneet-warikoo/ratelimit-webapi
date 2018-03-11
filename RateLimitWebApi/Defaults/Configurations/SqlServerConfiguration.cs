using System.Collections.Generic;
namespace WebApi.RateLimits.Defaults.Configuration
{
    class SqlServerConfiguration
    {
        string ServerName{get;set;}
        string DatabaseName {get;set;}
        string UserName{get;set;}
        string Password{get;set;}
        bool IntegratedSecurity{get;set;}
        Dictionary<string,string> ConnectionProperties{get;set;}
    }
}