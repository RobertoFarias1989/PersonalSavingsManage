using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllGoalsQuery : IRequest<List<GoalViewModel>>
{
}
