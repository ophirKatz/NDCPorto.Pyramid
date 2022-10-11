using Pyramid.Domain;

namespace Pyramid.Infrastructure;

public class AdminEmail : IAdminEmail
{
    public void Send(string subject, string content)
    {
        // TODO : Use http to talk with the <b>External</b> SMTP server to send an email to the admin account
    }
}