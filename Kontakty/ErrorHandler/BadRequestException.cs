namespace Kontakty.ErrorHandler
{
    public class BadRequestException :Exception

    {
        public BadRequestException(string message) : base(message) { }
    }
}
