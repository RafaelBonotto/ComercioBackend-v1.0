namespace Usuario.Infra.Querys
{
    public class UsuarioQuerys
    {
        public const string SELECT_USUARIO_POR_EMAIL = @"SELECT * 
                                                            FROM tb_usuario TBU 
                                                            WHERE TBU.email = @email 
                                                            AND TBU.ativo = 1;";
    }
}
