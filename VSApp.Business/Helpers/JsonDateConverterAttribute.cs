using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VSApp.Business.Helpers
{

    public class YearMonthDate : JsonConverter<DateTime>
    {

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
       => DateTime.ParseExact(reader.GetString(),
                    "yyyy-MM-dd", CultureInfo.InvariantCulture);
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
       => writer.WriteStringValue(value.ToString(
                    "yyyy-MM-dd", CultureInfo.InvariantCulture));
    }

    public class YearMonthDateHourMinuteSecond : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
       => DateTime.ParseExact(reader.GetString(),
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
       => writer.WriteStringValue(value.ToString(
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
    }
}
