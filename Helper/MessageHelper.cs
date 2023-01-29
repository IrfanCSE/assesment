using Newtonsoft.Json;

public class MessageHelper
{
    public MessageHelper(string message)
    {
        Message = message;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    public MessageHelper(string message, string error) : this(message)
    {
        this.Error = error;
    }

    public string Message { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
}


public class LoginResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
}