using Newtonsoft.Json;

namespace Investor.Core
{
    public static class DeepCloneExtension
    {
        public static T DeepClone<T>(this T obj)
        {
            var str = JsonConvert.SerializeObject (obj);
            return JsonConvert.DeserializeObject<T> (str);
        }
    }
}