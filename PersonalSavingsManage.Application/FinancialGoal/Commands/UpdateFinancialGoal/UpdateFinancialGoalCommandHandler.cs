using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateFinancialGoalCommandHandler : IRequestHandler<UpdateFinancialGoalCommand, ResultViewModel<Unit>>
{
    private readonly IFinancialGoalRepository _repository;

    public UpdateFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);

        if (financialGoal != null && financialGoal.IsDeleted != true)
        {

            if(request.ImageGoal != null)
            {
                var olderImagePath = financialGoal.ImageGoal;
                var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

                if (string.IsNullOrEmpty(olderImagePath) && File.Exists(olderImagePath))
                {
                    File.Delete(olderImagePath);
                }

                using Stream fileStream = new FileStream(imagePath, FileMode.Create);
                request.ImageGoal.CopyTo(fileStream);
                financialGoal.UpdateImageGoal(imagePath);
            }

            financialGoal.Update(request.Title, request.TargetAmount, request.Deadline);

            financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

            await _repository.UpdateAsync(financialGoal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The FinancialGoal was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
