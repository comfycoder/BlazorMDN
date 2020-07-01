using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingDataStore.State
{
    public class AppState
    {
        public PersonStore PersonStore { get; set; } = new PersonStore();

        public AppState()
        {

        }
    }
}
