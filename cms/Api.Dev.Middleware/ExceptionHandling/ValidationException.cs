namespace Api.Dev.Middleware.Ui.ExceptionHandling
{
    public class ValidationException:Exception
    {

        public ValidationException(string message) : base(message) 
        {
        }
    }
}
