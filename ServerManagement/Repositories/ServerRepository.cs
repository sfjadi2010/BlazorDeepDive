using System.Collections.Generic;
using System.Linq;
using ServerManagement.Models;

namespace ServerManagement.Repositories;

public static class ServerRepository
{
    private static readonly List<Server> _servers;
    private static int _nextId = 16;

    static ServerRepository()
    {
        _servers = new List<Server>
        {
            new Server { Id = 1, Name = "WebServer01", IPAddress = "192.168.1.1", Status = ServerStatus.Online },
            new Server { Id = 2, Name = "DBServer01", IPAddress = "192.168.1.2", Status = ServerStatus.Offline },
            new Server { Id = 3, Name = "AppServer01", IPAddress = "192.168.1.3", Status = ServerStatus.Offline },
            new Server { Id = 4, Name = "CacheServer01", IPAddress = "192.168.1.4", Status = ServerStatus.Online },
            new Server { Id = 5, Name = "WebServer02", IPAddress = "192.168.1.5", Status = ServerStatus.Online },
            new Server { Id = 6, Name = "DBServer02", IPAddress = "192.168.1.6", Status = ServerStatus.Offline },
            new Server { Id = 7, Name = "AppServer02", IPAddress = "192.168.1.7", Status = ServerStatus.Online },
            new Server { Id = 8, Name = "CacheServer02", IPAddress = "192.168.1.8", Status = ServerStatus.Offline },
            new Server { Id = 9, Name = "WebServer03", IPAddress = "192.168.1.9", Status = ServerStatus.Online },
            new Server { Id = 10, Name = "DBServer03", IPAddress = "192.168.1.10", Status = ServerStatus.Offline },
            new Server { Id = 11, Name = "AppServer03", IPAddress = "192.168.1.11", Status = ServerStatus.Online },
            new Server { Id = 12, Name = "CacheServer03", IPAddress = "192.168.1.12", Status = ServerStatus.Online },
            new Server { Id = 13, Name = "WebServer04", IPAddress = "192.168.1.13", Status = ServerStatus.Offline },
            new Server { Id = 14, Name = "DBServer04", IPAddress = "192.168.1.14", Status = ServerStatus.Online },
            new Server { Id = 15, Name = "AppServer04", IPAddress = "192.168.1.15", Status = ServerStatus.Offline }
        };
    }

    public static IEnumerable<Server> GetAll() => _servers;

    public static Server? GetById(int id) => _servers.FirstOrDefault(s => s.Id == id);

    public static void Add(Server server)
    {
        server.Id = _nextId++;
        _servers.Add(server);
    }

    public static void Update(Server server)
    {
        var existing = GetById(server.Id);

        if (existing == null) return;
        
        existing.Name = server.Name;
        existing.IPAddress = server.IPAddress;
        existing.Status = server.Status;        
    }

    public static bool Delete(int id)
    {
        var server = GetById(id);
        if (server == null) return false;
        _servers.Remove(server);
        return true;
    }

    public static IEnumerable<Server> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return _servers;

        query = query.ToLower();
        return _servers.Where(s =>
            s.Name.ToLower().Contains(query) ||
            s.IPAddress.ToLower().Contains(query));
    }
}
