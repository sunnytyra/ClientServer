using System.Collections.Generic;

namespace API.Entities
{
    public class MasterInfo
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public IEnumerable<SystemInfo> SystemInfos{get;set;}
        public long LastSuccessTime{get;set;}
        public bool  LastCallFailed{get;set;}
    }
}