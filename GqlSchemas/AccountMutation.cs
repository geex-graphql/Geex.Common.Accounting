using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geex.Common.Abstraction.Gql.Types;
using Geex.Common.Accounting.Aggregates.Accounts.Inputs;
using Geex.Common.Identity.Api.GqlSchemas.Users.Inputs;

using HotChocolate;

using MediatR;

namespace Geex.Common.Accounting.GqlSchemas
{
    public class AccountMutation : Mutation<AccountMutation>
    {
        /// <summary>
        /// 更新设置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> ChangePassword(
            [Service] IMediator Mediator,
            ChangePasswordRequest input)
        {
            await Mediator.Send(input);
            return true;
        }

        public async Task<bool> Register(
            [Service] IMediator mediator,
            RegisterUserRequest input)
        {
            var result = await mediator.Send(input);
            return true;
        }
    }
}
