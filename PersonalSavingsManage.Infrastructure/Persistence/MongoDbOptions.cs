namespace PersonalSavingsManage.Infrastructure.Persistence;

public class MongoDbOptions
{
    //Representa as informações que ficam armazenadas no appsettings.json
    public string ConnectionString { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
}
