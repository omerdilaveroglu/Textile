using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Genel bağımlılıkları yükleyecek.
        void Load(IServiceCollection serviceCollection);
    }
}