using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Geex.Common.Abstraction.Gql.Inputs;
using Geex.Common.Abstractions;
using Geex.Common.Accounting.Aggregates.Accounts.Inputs;
using Geex.Common.Identity.Api.Aggregates.Users;
using Geex.Common.Identity.Api.GqlSchemas.Users.Inputs;

using HotChocolate;

using MediatR;

using Volo.Abp;

namespace Geex.Common.Accounting.Handlers
{
    public class AccountHandler : IRequestHandler<ChangePasswordRequest>,
        IRequestHandler<RegisterUserRequest>

    {
        private IMediator _mediator;

        public AccountHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Handles a request</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var query = await this._mediator.Send(new QueryInput<IUser>(x => x.Id == ClaimPrinciple.Value.FindUserId()), cancellationToken);
            var user = query.First();
            user.ChangePassword(request.OriginPassword, request.NewPassword);
            return Unit.Value;
        }



        /// <summary>Handles a request</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<Unit> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            await this._mediator.Send(new CreateUserRequest(), cancellationToken);
            return Unit.Value;
        }

        public LazyFactory<ClaimsPrincipal> ClaimPrinciple { get; }
    }

}
