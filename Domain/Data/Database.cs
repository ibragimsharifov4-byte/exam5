using Npgsql;

namespace Domain.Data;

public class Database
{
    private string connection = 
    "Host=localhost;Port=5432;Database=Hospital;Username=postgres;Password=1234";
    
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connection);
    }
}
