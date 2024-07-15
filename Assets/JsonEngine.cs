using Newtonsoft.Json;

namespace CsharpAdvance.Assets
{
    public class JsonEngine
    {
        public string MakeJson(List<string> listTM){
            TokenModel tm = new TokenModel();
            tm.Token = listTM.ToArray();
            string json = JsonConvert.SerializeObject(tm);
            return json;
        }
    }
}