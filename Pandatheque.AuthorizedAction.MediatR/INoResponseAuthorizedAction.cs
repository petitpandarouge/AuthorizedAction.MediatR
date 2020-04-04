namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for no response action.
    /// </summary>
    /// <typeparam name="TParameters">The type of the action parameters.</typeparam>
    public interface INoResponseAuthorizedAction<TParameters> : IAuthorizedAction<TParameters, Void>
        where TParameters : class
    {
    }
}
