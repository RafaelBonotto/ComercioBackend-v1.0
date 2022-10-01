using System.ComponentModel.DataAnnotations;

namespace Pagamentos.Aplicacao.Request
{
    public class GetByDataVencimentoRequest
    {
        [Required(ErrorMessage = "Data de vencimento de obrigatório")]
        public string DataVencimentoDe { get; set; }

        [Required(ErrorMessage = "Data de vencimento até obrigatório")]
        public string DataVencimentoAte { get; set; }
    }
}
