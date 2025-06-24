namespace RaddarTestApp.Domain.Dtos
{
    public class ObjectResultDto
    {
        public bool Successful { get; set; }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = null!;
    }
}
