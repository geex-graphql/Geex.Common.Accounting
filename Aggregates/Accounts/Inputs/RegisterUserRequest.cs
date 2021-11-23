using MediatR;

namespace Geex.Common.Accounting.Aggregates.Accounts.Inputs
{
    public record RegisterUserRequest : IRequest<Unit>
    {
        public string Password { get; set; }
        public string PhoneOrEmail { get; set; }
    }
}