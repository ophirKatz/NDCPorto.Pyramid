namespace Pyramid.Domain;

public interface IAdminEmail
{
    void Send(string subject, string content);
}