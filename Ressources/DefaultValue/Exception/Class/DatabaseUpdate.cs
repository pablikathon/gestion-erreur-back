namespace exception;

    public class UpdateEntityException : Exception{
        public UpdateEntityException(string message) : base(message) { }
        public UpdateEntityException() : base() { }
        public UpdateEntityException(string message, Exception innerException) : base(message, innerException)  { }
    }



