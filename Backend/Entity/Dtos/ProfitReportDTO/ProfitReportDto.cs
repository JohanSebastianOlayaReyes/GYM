using Entity.Dtos.Base;

namespace Gym;

public class ProfitReportDto : BaseDto
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalIncome { get; set; }
}
