﻿using Pagamentos.Aplicacao.Handles.Interfaces;
using Pagamentos.Aplicacao.Request;
using Pagamentos.Aplicacao.Response;
using Pagamentos.Dominio.Entidades;
using Pagamentos.Infra.Repositorios.Interfaces;
using System.Globalization;

namespace Pagamentos.Aplicacao.Handles
{
    public class InserirPagamentoHandle : IInserirPagamentoHandle
    {
        private IPagamentoRepositorio _repositorio;

        public InserirPagamentoHandle(IPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<PagamentoResponse> PostAsync(PagamentoRequest req)
        {
            PagamentoResponse ret = new();
            var pagamento = new Dominio.Entidades.Pagamento
            {
                Ativo = 1,
                Data_criacao = DateTime.Now,
                Data_alteracao = DateTime.Now,
                Dt_vencimento = DateTime.ParseExact(req.DataVencimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Dt_entrega = DateTime.ParseExact(req.DataEntrega, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Valor = req.Valor,
                Num_parcela = req.NumeroParcela,
                Qtd_parcela = req.QtdParcela,
                Fornecedor_id = req.FornecedorId,
                Nota_fiscal = int.Parse(req.NotaFiscal)
            };
            
            ret.PagamentoId = await _repositorio.PostAsync(pagamento);
            return ret;
        }
            
    }
}
