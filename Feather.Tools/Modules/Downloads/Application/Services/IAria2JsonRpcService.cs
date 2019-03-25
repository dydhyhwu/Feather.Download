using System;
using System.Collections.Generic;
using Feather.Tools.Domains;
using Newtonsoft.Json;

namespace Feather.Tools.Modules.Downloads.Application.Services
{
    public interface IAria2JsonRpcService
    {
        object AddUri(string url);
        object tellStatus(string gid);
    }

    public class Aria2JsonRpcService : IAria2JsonRpcService
    {
        public object AddUri(string url)
        {
            return WebRequestHelper.Post("http://localhost:6800/jsonrpc", new Aria2RpcDto()
            {
                Method = "aria2.addUri",
                Params = new List<List<string>>() { new List<string>() { url } }
            });
        }

        public object tellStatus(string gid)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Aria2RpcDto
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";

        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object Params { get; set; }
    }
}
