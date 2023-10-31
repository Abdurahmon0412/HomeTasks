namespace Identity.Application.Common.Settings;

public class EmailSenderSettings 
{
    public string Host { get; set; } = default!;

    public int Port { get; set; }

    public string CredintialEmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string SenderEmailAddress { get; set; } = default!;
}