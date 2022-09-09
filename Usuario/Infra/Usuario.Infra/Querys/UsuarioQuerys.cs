namespace Usuario.Infra.Querys
{
    public class UsuarioQuerys
    {
        public const string SELECT_USUARIO_POR_EMAIL = @"SELECT * 
                                                            FROM tb_usuario TBU 
                                                            WHERE TBU.email = @email 
                                                            AND TBU.ativo = 1;";

        public const string SELECT_PERMISSAO_ID = @"SELECT permissao_id 
                                                        FROM tb_permissao_usuario TBP
                                                        WHERE usuario_id = @usuario_id;";
    }
}
