namespace Application.Repository;

public interface ISessionLogRepository
{
    Task Save(Guid sessionId, string message);
    Task<IEnumerable<string>> GetBySessionId(Guid sessionId);
}
