namespace exception;

    public class EntityNotFoundException : Exception{
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException() : base() { }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)  { }
    }

    public class FieldNotFoundException : Exception{
        public FieldNotFoundException(string message) : base(message){}
        public FieldNotFoundException(): base(){}
        public FieldNotFoundException(string message, Exception innerException): base(message, innerException) { }
    }



