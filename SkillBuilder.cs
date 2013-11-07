using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace ShadowrunCharacterMaker
{
    public static class ObjectFactory
    {
        public static dynamic CreateInstance(Dictionary<string, int> objectFromSQL)
        {

            dynamic instance = new ExpandoObject();

            var instanceDict = (IDictionary<string, object>)instance;

            foreach (var pair in objectFromSQL)
            {
                instanceDict.Add(pair.Key, pair.Value);
            }

            return instance;
        }
    }
}
