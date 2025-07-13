using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllFinacialGoalsQuery : IRequest<ResultViewModel<List<FinancialGoalViewModel>>>
{
}
