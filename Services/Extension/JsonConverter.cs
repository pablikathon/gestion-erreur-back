using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models.Auth;
using exception;
public class GrantConnectionConverter : JsonConverter<IGrantConnection>
{
    public override IGrantConnection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            var rootElement = jsonDoc.RootElement;

            if (rootElement.TryGetProperty(nameof(UserSignInWithPassword.Password), out _))
            {
                var userSignInWithPassword = JsonSerializer.Deserialize<UserSignInWithPassword>(rootElement.GetRawText(), options);
                return userSignInWithPassword ?? throw new DeserializationException(SerializationMessage.DeserializationSignPasswordNull);
            }
            else if (rootElement.TryGetProperty(nameof(UserSignInWithRefreshToken.RefreshToken), out _))
            {
                var UserSignInWithRefreshToken = JsonSerializer.Deserialize<UserSignInWithRefreshToken>(rootElement.GetRawText(), options);
                return UserSignInWithRefreshToken ?? throw new DeserializationException(SerializationMessage.DeserializationSignRefreshTokenNull);
            }
            else
            {
                throw new FieldNotFoundException(NotFoundMessage.FieldNotFound);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, IGrantConnection value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
