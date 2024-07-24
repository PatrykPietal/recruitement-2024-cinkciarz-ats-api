using Ats.Core.Interfaces.Data;
using MediatR;
using System.Transactions;

namespace Ats.Infrastructure.Behaviors
{
	public sealed class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
		: IPipelineBehavior<TRequest, TResponse>
		where TRequest : notnull
	{
		public async Task<TResponse> Handle(
			TRequest request,
			RequestHandlerDelegate<TResponse> next,
			CancellationToken cancellationToken)
		{
			if (IsNotCommand())
			{
				return await next();
			}

			using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

			var response = await next();

			await unitOfWork.SaveChangesAsync(cancellationToken);

			transactionScope.Complete();

			return response;
		}

		private static bool IsNotCommand()
		{
			return !typeof(TRequest).Name.EndsWith("Command");
		}
	}

}
