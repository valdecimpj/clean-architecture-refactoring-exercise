using Application.Repository;

namespace Infrastructure.Repository;

public class SessionLogRepository : ISessionLogRepository
{
    private readonly List<string> _sessionLogs = new();

    public Task<IEnumerable<string>> GetForSession() =>
        Task.FromResult(_sessionLogs.AsEnumerable());

    public Task Save(string message)
    {
        _sessionLogs.Add(message);
        return Task.CompletedTask;
    }
}
