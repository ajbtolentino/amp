namespace AMP.Infrastructure.Filters;

public class Filter
{
    public string Field { get; set; }
    public object Value { get; set; }
    public string MatchMode { get; set; }
    public string Operator { get; set; }
}