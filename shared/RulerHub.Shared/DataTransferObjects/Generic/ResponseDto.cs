namespace RulerHub.Shared.DataTransferObjects.Generic;

public class ResponseDto<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
