namespace Dane
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI createAPI()
        {
            return new DataAPI();
        }
        
        internal sealed class DataAPI : DataAbstractAPI
        {

        }
    }
}
