namespace SeturAssessment.ReportService.Utilities.Results
{

    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
