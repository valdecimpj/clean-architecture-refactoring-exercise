using Application.Repository;

namespace Infrastructure.Repository;

public class SessionLogRepository : ISessionLogRepository
{
    private readonly Dictionary<Guid, List<string>> _sessionLogs = new();

    public Task<IEnumerable<string>> GetBySessionId(Guid sessionId)
    {
        if (_sessionLogs.TryGetValue(sessionId, out var logs))
            return Task.FromResult(logs.AsEnumerable());

        return Task.FromResult(Enumerable.Empty<string>());
    }

    public Task Save(Guid sessionId, string message)
    {
        if (!_sessionLogs.ContainsKey(sessionId))
            _sessionLogs[sessionId] = new List<string>();

        _sessionLogs[sessionId].Add(message);
        return Task.CompletedTask;
    }
}
