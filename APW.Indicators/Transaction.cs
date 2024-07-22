using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Service;

public interface ITransaction
{
    int Id { get; set; }
    string Name { get; set; }

    bool Process();
    string Results();

}

public class Transaction : ITransaction
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool Process()
    {
        return true;
    }

    public string Results()
    {
        return "resultados de Transaction";
    }
}
