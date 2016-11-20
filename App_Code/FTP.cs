using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;


namespace Testhoekje.App_Code.FTP
{


    public class FTP
    {

        private string _URL = "";
        private string _user = "";
        private string _psw = "";


        public void ConnectionSetup(string url, string user, string psw)
        {
            _URL = url;
            _user = user;
            _psw = psw;

        }





        public string Download_file(string fileName, out bool hasError)
        {
            //aanroep gaat als volgt
            //  bool test;
            //Download_file("blala", out test);
            //if (test) { }

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + fileName);
            request.Credentials = new NetworkCredential(_user, _psw);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            string r = "";


            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string FileContent = reader.ReadToEnd();

                    r = FileContent;
                    hasError = false;
                }
            }
            catch (Exception e)
            {
                hasError = true;
                r = e.Message;
                
            }

            return r;


        }



        public string Upload_file(string sourcefileName, string destinationFileName)
        {

            String r = "Ok"; 
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + destinationFileName);
            request.Credentials = new NetworkCredential(_user, _psw);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            StreamReader sourceStream = new StreamReader(sourcefileName);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {

                }
            }
            catch (Exception e)
            {
                r = e.Message;
            }

            return r;

        }



        public string Upload_string(string sourceString, string destinationFileName)
        {

            String r = "Ok"; 
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + destinationFileName);
            request.Credentials = new NetworkCredential(_user, _psw);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            //StreamReader sourceStream = new StreamReader(sourcefileName);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceString);
            //sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

          
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {

                }
            }
            catch (Exception e)
            {
                r = e.Message;
            }

            return r;
        }


        public string Delete_file(string fFileName)
        {

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + fFileName);
                request.Credentials = new NetworkCredential(_user, _psw);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                String r = "Ok";

                try
                {
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {

                    }
                }
                catch (Exception e)
                {
                    r = e.Message;
                }
               
               return r;
        }


        public string Delete_folder_Contents(string destinationFolder)
        {

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + destinationFolder);
            request.Credentials = new NetworkCredential(_user, _psw);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());

            string fileName = streamReader.ReadLine();
            string r = "Ok";

            var ftp = new FTP();


            while (fileName != null)
            {
                r = ftp.Delete_file(destinationFolder + fileName);
                fileName = streamReader.ReadLine();
            }

            request = null;
            streamReader = null;

            return r;
        }


        public List<string> GetFolderList(string destinationFolder, out bool hasError)
        {
            var r = new List<string>();
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_URL + destinationFolder);
            request.Credentials = new NetworkCredential(_user, _psw);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            hasError = false;

              try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                         Stream responseStream = response.GetResponseStream();
                         StreamReader reader = new StreamReader(responseStream);

                         var FolderList = reader.ReadToEnd();
                         if (FolderList != "")
                         {
                             string[] lines = null;

                             if (FolderList.Contains("\r\n"))
                             {
                                 lines = FolderList.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                             }
                             else if (FolderList.Contains("\n"))
                             {
                                 lines = FolderList.Split(new string[] { "\n" }, StringSplitOptions.None);
                             }

                             foreach (var line in lines)
                             {
                                 r.Add(line);
                             }

                             
                         }
                }
            }
            catch (Exception e)
            {
                hasError = true;
                r.Add(e.Message);
            }

            return r;
        }

    }
}
