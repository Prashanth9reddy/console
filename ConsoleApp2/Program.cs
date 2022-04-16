using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;




namespace ConsoleApp2
{    class Global
    {



        public string latestFileName = "";
        public const string host = "122.175.52.53";
        public const string username = "ujjwal";
        public const string host = "ujjwal09*";

    }
    class Program
    {
        static void Main(string[] args)
        {
          //  using (SftpClient client = new SftpClient(new PasswordConnectionInfo("122.175.52.53", "ujjwal", "ujjwal09*")))
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("122.175.52.53", "ujjwal", "ujjwal09*")))
            {
                client.Connect();
                new Program().Showfiles(client, "/home/ujjwal/SUMA_E/TIRUNELVELI/INVERTER");
                new Program().downLoad_file(client);
                new Program().extractCompressedFile();
                new Program().check_for_latest_file(client, "/home/ujjwal/SUMA_E/TIRUNELVELI/INVERTER");
                client.Disconnect();
            
            }
            SftpClient(string host, string username, params PrivateKeyFile[] keyFiles);

            Console.ReadLine();


        }


        private void Showfiles(SftpClient client, string folder)
        {
            var paths = client.ListDirectory(folder);
            foreach (var path in paths)
            {
               // Console.WriteLine(path);
                //Console.WriteLine(path.IsDirectory ? "Directory: " + path.FullName : "File: " + path.FullName);
                


            }
        }


        private void check_for_latest_file(SftpClient client, string folder)
        {
            var paths = client.ListDirectory(folder);
            foreach (var path in paths)
            {
                Console.WriteLine(path.FullName);
                Console.WriteLine("Last Date:",path.LastWriteTime.Date);
                Console.WriteLine(path.LastWriteTime.TimeOfDay);
                Console.WriteLine(path.LastWriteTime.Date);

            }

        }

        private void downLoad_file(SftpClient client)
        {

            string localfile = @"E:\dotNET\txt\Weather.zip";
            string serverfile = @"/home/ujjwal/SUMA_E/WEATHER.zip";

            using (var file = File.OpenWrite(localfile))
            {
                client.DownloadFile(serverfile, file);
            }

        }



        private void extractCompressedFile( )
        {
            string startPath = @".\start";
            string localfile = @"E:\dotNET\txt\Weather.zip";
            string extractTo = @"E:\dotNET\txt\extracted_files";

            //ZipFile.CreateFromDirectory(startPath, localfile);
         //   ZipFile.ExtractToDirectory(localfile, extractTo);
        }

        

    }
}
