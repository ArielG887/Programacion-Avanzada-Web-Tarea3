using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APW.Service;

public interface IProcess
{
    bool ProcessTask();
}

public class Process(ITransaction transaction) : IProcess
{
    private readonly ITransaction _transaction = transaction;

    public bool ProcessTask()
    {
        return _transaction.Process();
    }
}
