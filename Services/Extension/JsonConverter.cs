using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models.Auth;

public class GrantConnectionConverter : JsonConverter<IGrantConnection>
{
    public override IGrantConnection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            var rootElement = jsonDoc.RootElement;

            if (rootElement.TryGetProperty("Password", out _))
            {
                return JsonSerializer.Deserialize<UserSignInWithPassword>(rootElement.GetRawText(), options);
            }
            else if (rootElement.TryGetProperty("RefreshToken", out _))
            {
                return JsonSerializer.Deserialize<UserSignInWithRefreshToken>(rootElement.GetRawText(), options);
            }
            else
            {
                throw new JsonException("Unknown grant connection type");
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, IGrantConnection value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
