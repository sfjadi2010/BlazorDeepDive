using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models;

public class Server
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string IPAddress { get; set; } = string.Empty;
    
    public ServerStatus Status { get; set; } = ServerStatus.Offline;
}
