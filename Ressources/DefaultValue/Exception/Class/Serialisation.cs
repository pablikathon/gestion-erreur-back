namespace exception;

public class SerializationException : Exception
{
    public SerializationException(string message) : base(message) { }
    public SerializationException() : base() { }
    public SerializationException(string message, Exception innerException) : base(message, innerException) { }
}

public class DeserializationException : Exception
{
    public DeserializationException(string message) : base(message) { }
    public DeserializationException() : base() { }
    public DeserializationException(string message, Exception innerException) : base(message, innerException) { }
}
