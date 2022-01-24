namespace CQRS.CrossCutting
{
    public interface IMongoDatabaseSettings
    {
        string CollectionProduto { get; set; }
        string CollectionProdutoGrupo { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}