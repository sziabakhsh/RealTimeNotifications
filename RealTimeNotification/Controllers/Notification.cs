using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hub;

    public NotificationController(IHubContext<NotificationHub> hub)
    {
        _hub = hub;
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send(NotificationDto dto)
    {
        await _hub.Clients.All.SendAsync("ReceiveNotification", dto.Message);
        return Ok(new { status = "sent" });
    }
}

public class NotificationDto
{
    public string Message { get; set; } = "sample text";
}