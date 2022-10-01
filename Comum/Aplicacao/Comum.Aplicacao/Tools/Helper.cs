using System.Text;

namespace Comum.Aplicacao.Tools
{
    public static class Helper
    {
        public static string MensagemConcatenada(List<string> msgs)
        {
            StringBuilder sb = new();
            foreach (var msg in msgs)
                sb.Append(msg + " | ");
            return sb.ToString();
        }
    }
}
