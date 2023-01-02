using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicatingway.Client.Services
{
    public interface IApiCallService
    {
        Task SendMessage(string sender, string message);
    }
}
