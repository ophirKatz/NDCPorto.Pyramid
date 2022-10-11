using MediatR;
using Pyramid.Domain;
using Pyramid.Domain.Events;

namespace Pyramid.Application;

public class PostEventHandlers : INotificationHandler<CommentBlocked>
{
    private readonly IAdminEmail _adminEmail;

    public PostEventHandlers(IAdminEmail adminEmail)
    {
        _adminEmail = adminEmail;
    }

    public Task Handle(CommentBlocked notification, CancellationToken cancellationToken)
    {
        const string subject = "Comment Blocked";
        var emailContent = $@"
            A comment for post {notification.PostId} has been blocked.
            Author id: {notification.AuthorId}
            Comment Content: {notification.Content}
        ";
        _adminEmail.Send(subject, emailContent);

        return Task.CompletedTask;
    }
}