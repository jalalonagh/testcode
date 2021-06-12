namespace Data.Repositories.Models
{
    public abstract class RangeModel
    {
        public int Total { get; set; } = 0;
        public int More { get; set; } = int.MaxValue;
    }
}
