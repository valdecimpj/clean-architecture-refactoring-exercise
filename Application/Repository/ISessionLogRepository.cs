namespace Application.Repository;

public interface ISessionLogRepository
{
    Task Save(string message);
    Task<IEnumerable<string>> GetForSession();
}
