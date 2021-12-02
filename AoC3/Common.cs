using System.IO;

namespace AoC.Common
{
    public static class Common
{
        public static string ReadInput(string fileLocation)
        {
            string output = string.Empty;
            try
            {
                var sr = new StreamReader(fileLocation);
                output = sr.ReadToEnd();
            }
            catch (System.Exception)
            {

                throw;
            }
            return output;
        }
}
}
