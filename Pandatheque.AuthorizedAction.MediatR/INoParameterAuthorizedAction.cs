namespace Pandatheque.AuthorizedAction.MediatR
{
    /// <summary>
    /// Interface for no parameter action.
    /// </summary>
    /// <typeparam name="TResponse">The type of the action response.</typeparam>
    public interface INoParameterAuthorizedAction<TResponse> : IAuthorizedAction<Void, TResponse>
    {
    }
}
