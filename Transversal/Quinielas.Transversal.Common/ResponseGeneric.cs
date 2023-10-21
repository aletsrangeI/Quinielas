using FluentValidation.Results;

namespace Quinielas.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
