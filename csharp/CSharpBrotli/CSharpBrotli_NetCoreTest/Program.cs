using System;
using System.IO;

namespace CSharpBrotliTest
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "../test_data.zip" };
            CheckBundle(args);
            Console.WriteLine("decode test_data.zip successfully.");
        }
        static void CheckBundle(string[] args)
        {
            int argsOffset = 0;
            bool sanityCheck = false;
            if (args.Length != 0)
            {
                if (args[0].Equals("-s"))
                {
                    sanityCheck = true;
                    argsOffset = 1;
                }
            }
            if (args.Length == argsOffset)
            {
                throw new Exception("Usage: BundleChecker [-s] <fileX.zip> ...");
            }
            for (int i = argsOffset; i < args.Length; i++)
            {
                byte[] data = File.ReadAllBytes(args[i]);
                using (MemoryStream input = new MemoryStream(data))
                {
                    new BundleChecker(input, 0, sanityCheck).Check();
                }

            }
        }
    }
}