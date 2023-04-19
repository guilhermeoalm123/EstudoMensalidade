namespace Aplicacao.Models
{
    public static class DictionaryExtensions
    {
        public static Dictionary<string, string> ToPropertyDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var propertyInfo in obj.GetType().GetProperties())
                if (propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
                    dictionary[propertyInfo.Name] = (propertyInfo.GetValue(obj, null) ?? "").ToString();
            return dictionary;
        }
    }
}
