using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Contracts
{
    public interface IConfigurationStore
    {
        string GetConfiguration(string configurationName);

        T GetConfiguration<T>(string configurationName);
    }
}
