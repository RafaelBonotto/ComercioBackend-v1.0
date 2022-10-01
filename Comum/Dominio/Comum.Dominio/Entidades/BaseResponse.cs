namespace Comum.Dominio.Entidades
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; } = new();
    }
}
