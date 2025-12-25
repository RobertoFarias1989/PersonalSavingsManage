using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllGoalsQuery : IRequest<ResultViewModel<List<GoalViewModel>>>
{
}
