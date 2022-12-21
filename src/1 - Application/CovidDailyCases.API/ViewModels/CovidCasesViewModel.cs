namespace CovidDailyCases.API.ViewModels;

public class CovidCasesViewModel
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public DateOnly Date { get; set; }
    public string Variant { get; set; }
    public int NumSequences { get; set; }
    public double PercSequences { get; set; }
    public int NumSequencesTotal { get; set; }
}
