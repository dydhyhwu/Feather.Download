using System;
using System.Collections.Generic;

namespace Feather.Tools.Modules.Downloads.Application.Domains
{
    public class Aria2TellStatusDto
    {
        public Int64 completedLength { get; set; }
        public Int64 connections { get; set; }
        public string dir { get; set; }
        public Int64 downloadSpeed { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }

        /// <summary>
        /// 唯一标识，用作更新
        /// </summary>
        public string gid { get; set; }
        public int numPieces { get; set; }
        public Int64 pieceLength { get; set; }
        public string status { get; set; }
        public Int64 totalLength { get; set; }
        public Int64 uploadLength { get; set; }
        public Int64 uploadSpeed { get; set; }

        public List<Aria2FileDto> files { get; set; }
    }

    public class Aria2FileDto
    {
        public Int64 completedLength { get; set; }
        public int index { get; set; }
        public Int64 length { get; set; }
        public string path { get; set; }
        public bool selected { get; set; }
    }

    public class Aria2ResultDto<ResultType>
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public IList<ResultType> result { get; set; }
    }
}
