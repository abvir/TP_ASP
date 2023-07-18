using App.Data.Models;

namespace App.Data;

public interface IRepository
{
    public List<Company> Companies { get; }
}
