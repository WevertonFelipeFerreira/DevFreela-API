

namespace WFL.Errors.Interfaces
{
    public interface IError
    {
        string Title { get; }
        int Status { get; }
        string Detail { get; }
        string Instance { get; }
        string TraceId { get; }
    }
}
