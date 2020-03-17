using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_Test
{
    //with help from https://stackoverflow.com/questions/43089786/making-a-simple-c-sharp-api-call
    public class c_test
    {
        public void go(string URL, string savepath, string savefilename)
        {
            List<cls_model_row> mrs = new List<cls_model_row>();
            cls_model_row mr;
            string resultstring = GetData(URL).Result;
            //string resultstring = DummyReturn();
            resultstring = resultstring.Replace("[", "");
            resultstring = resultstring.Replace("]", "");
            string[] resultarray = resultstring.Split('}');
            foreach (string result in resultarray)
            {
                if (result != "")
                {
                    mr = cls_model_row.frmAPI(result.Replace("{", ""));
                    mrs.Add(mr);
                }
            }
            

            string csv_Line;
            csv_Line = "";
            foreach (cls_model_row rr in mrs)
            {
                csv_Line = csv_Line + rr.paymentid.ToString() + ",";
                csv_Line = csv_Line + rr.currency.ToString() + ",";
                csv_Line = csv_Line + rr.amount.ToString() + ",";
                csv_Line = csv_Line + rr.paymentDate.ToString() + ",";
                csv_Line = csv_Line + rr.settled.ToString() + "," + Environment.NewLine;                
            }
            //<<need export>>
            Logging.Write(csv_Line, savepath, savefilename);
        }
        private static string DummyReturn()
        {
            string result;
            result = "";            
            result = result + "[";
            result = result + "{0,EUR,100,2020-02-07T15:03:40.515Z,true}";
            result = result + "{0,EUR,120,2020-02-08T15:03:40.515Z,true}";
            result = result + "{0,EUR,150,2020-02-09T15:03:40.515Z,true}";
            result = result + "]";
            return result;
        }
        private static async Task<string> GetData(string url)
        {
            try {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string strResult = await response.Content.ReadAsStringAsync();

                        return strResult;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
            
        }
    }
}