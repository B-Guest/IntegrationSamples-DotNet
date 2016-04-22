using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGuest.Integration.Console.Model;

namespace BGuest.Integration.Console
{
    public class StringBuildResults : ResultLogger
    {
        Dictionary<bool, List<Tuple<string, string, string, string>>> _report = new Dictionary<bool, List<Tuple<string, string, string, string>>>();
        public override void AddResponse(StayImportResultDto response)
        {
            if (!_report.ContainsKey(response.Success))
                _report.Add(response.Success,
                    new List<Tuple<string, string, string, string>>());
            _report[response.Success].Add(new Tuple<string, string, string, string>(response.ExternalKey, response.Id, response.GuestEmail, response.Message));
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