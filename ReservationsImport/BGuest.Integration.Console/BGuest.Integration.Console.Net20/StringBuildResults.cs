using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGuest.Integration.Console.Net20.Model;

namespace BGuest.Integration.Console.Net20
{
    internal class ResultItems
    {
        public ResultItems(string item1, string item2, string item3, string item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
    }
    public class StringBuildResults : ResultLogger
    {
        Dictionary<bool, List<ResultItems>> _report = new Dictionary<bool, List<ResultItems>>();
        public override void AddResponse(StayImportResultDto response)
        {
            if (!_report.ContainsKey(response.Success))
                _report.Add(response.Success,
                    new List<ResultItems>());
            _report[response.Success].Add(new ResultItems(response.ExternalKey, response.Id, response.GuestEmail, response.Message));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var items = from pair in _report
                orderby pair.Key ascending
                select pair;
            foreach (var item in items)
            {
                builder.AppendLine();
                builder.AppendFormat("Success: {0} Count({1})", item.Key, item.Value.Count);
                builder.AppendLine();
                builder.AppendLine("\tExternalKey\tId\tGuest mail\tMessage");
                foreach(var values in item.Value) {
                    builder.AppendFormat("\t{0}\t{1}|\t{2}|\t{3}", values.Item1, values.Item2, values.Item3, values.Item4);
                }
            }
            return builder.ToString();
        }
    }
}