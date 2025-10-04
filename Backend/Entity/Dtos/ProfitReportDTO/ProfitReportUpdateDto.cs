using Entity.Dtos.Base;

namespace Gym;

public class ProfitReportUpdateDto : BaseDto
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalIncome { get; set; }
}
