using System;
using System.Collections.Generic;
using Feather.Tools.Domains;
using Feather.Tools.Modules.Downloads.Application.Domains;
using Newtonsoft.Json;

namespace Feather.Tools.Modules.Downloads.Application.Services
{
    public interface IAria2JsonRpcService
    {
        object AddUri(string url);
        object tellStatus(string gid);
        IList<Aria2TellStatusDto> TellActive();
        IList<Aria2TellStatusDto> TellWaiting();
        IList<Aria2TellStatusDto> TellStopped();
    }

    public class Aria2JsonRpcService : IAria2JsonRpcService
    {
        private static string _host = "http://localhost:6800/jsonrpc";
        public object AddUri(string url)
        {
            return WebRequestHelper.Post(_host, new Aria2RpcDto()
            {
                Method = "aria2.addUri",
                Params = new List<List<string>>() { new List<string>() { url } }
            });
        }

        public object tellStatus(string gid)
        {
            return WebRequestHelper.Post<Aria2ResultDto<Aria2TellStatusDto>>(_host, new Aria2RpcDto()
            {
                Method = "aria2.tellStopped",
                Params = new List<int>() { 0, 10 }
            });
        }

        public IList<Aria2TellStatusDto> TellActive()
        {
            var d = WebRequestHelper.Post<Aria2ResultDto<Aria2TellStatusDto>>(_host, new Aria2RpcDto()
            {
                Method = "aria2.tellActive",
                Params = new List<int>()
            });
            return d.result ?? new List<Aria2TellStatusDto>();
        }

        public IList<Aria2TellStatusDto> TellWaiting()
        {
            return WebRequestHelper.Post<Aria2ResultDto<Aria2TellStatusDto>>(_host, new Aria2RpcDto()
            {
                Method = "aria2.tellWaiting",
                Params = new List<int>() { 0, 10 }
            }).result;
        }

        public IList<Aria2TellStatusDto> TellStopped()
        {
            return WebRequestHelper.Post<Aria2ResultDto<Aria2TellStatusDto>>(_host, new Aria2RpcDto()
            {
                Method = "aria2.tellStopped",
                Params = new List<int>() { 0, 10 }
            }).result;
        }
    }

    public class Aria2RpcDto
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";

        [JsonProperty("id")]
        public string Id { get; set; } = "Feather.Downloader";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object Params { get; set; }
    }
}
