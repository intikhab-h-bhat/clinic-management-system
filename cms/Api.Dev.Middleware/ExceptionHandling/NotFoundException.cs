namespace Api.Dev.Middleware.Ui.ExceptionHandling
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

    }
}
