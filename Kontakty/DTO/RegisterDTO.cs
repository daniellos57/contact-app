namespace Kontakty.DTO
{
    public class RegisterDTO
    {
        
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Nazwisko { get; set; } = default!;
        
    
}
}
