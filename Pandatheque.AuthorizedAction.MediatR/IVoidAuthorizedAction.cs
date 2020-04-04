namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for neither parameter nor response action.
    /// </summary>
    public interface IVoidAuthorizedAction : IAuthorizedAction<Void, Void>
    {
    }
}
