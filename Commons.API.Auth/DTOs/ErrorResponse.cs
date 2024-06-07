namespace Commons.API.Auth.DTOs;
public class ErrorResponse
{
    public string ErrorCode { get; set; } = "";
    public string Message { get; set; } = string.Empty;
    public DateTime At { get; set; } = DateTime.UtcNow;
}
