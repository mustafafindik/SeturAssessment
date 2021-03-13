namespace SeturAssessment.ContactService.Utilities.Results
{

    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
