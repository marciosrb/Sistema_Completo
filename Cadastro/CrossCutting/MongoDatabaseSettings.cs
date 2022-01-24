namespace CQRS.CrossCutting
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string CollectionProduto { get; set; }
        public string CollectionProdutoGrupo { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}