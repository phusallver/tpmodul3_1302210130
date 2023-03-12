
internal class Program
{
    class KodePos
    {
        public enum Kelurahan
        {
            Batununggal, Kujangsari,
            Mengger, Wates, Cijaura,
            Jatisari, Margasari,
            Sekejati, Kebonwaru,
            Maleer, Samoja
        }
        private static int getKodePos(Kelurahan lurah)
        {
            int[] kodePos = {40266,
            40287, 40267, 40256,
            40287, 40286, 40286,
            40286, 40272, 40274,
            40273};
            return kodePos[(int)lurah];
        }
        private static void Main(string[] args)
        {
            System.Console.WriteLine(getKodePos(Kelurahan.Kujangsari));
        }
    }
}


