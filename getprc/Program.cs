using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace getprc
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpointUrl = "http://intranet.cervello.pl/endpointstate.php?";
            string karolinMS = "ids=KarolinSrvWin&ipaddress=192.168.1.10&state=1";
            Console.WriteLine("Sen EHLO from server");
            MyWebRequest myRequest2 = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?" + karolinMS, "POST", karolinMS);
            //show the response string on the console screen.
            Console.WriteLine(myRequest2.GetResponse());
            Process[] processlist = Process.GetProcesses();
            string camE = @"E:\ufo4\UFO2.exe";
            int cE = 0;
            string camW = @"E:\ufo3\UFO2.exe";
            int cW = 0;
            string camN = @"E:\ufo5\UFO2.exe";
            int cN = 0;
            string camS = @"E:\ufo\UFO2.exe";
            int cS = 0;
            string camZ = @"E:\ufo6\UFO2.exe";
            int cZ = 0;
            string spyi = @"C:\program files\ispy\ispy.exe";
            int cI = 0;

            List<ProgRecord> cams = new List<ProgRecord>();
            List<ProgRecord> progs = new List<ProgRecord>();
            ProgRecord camBramaW = new ProgRecord("CamBramaW", "/", "CamBramaW", 0, "192.168.1.15", ProgRecord.objType.Camera);
            ProgRecord camBramaN = new ProgRecord("CamBramaN", "/", "CamBramaN", 0, "192.168.1.23", ProgRecord.objType.Camera);
            ProgRecord camMN = new ProgRecord("MetcamNorth", "/", "MetcamNorth", 0, "192.168.1.16", ProgRecord.objType.Camera);
            ProgRecord camMS = new ProgRecord("MetcamSouth", "/", "MetcamSouth", 0, "192.168.1.14", ProgRecord.objType.Camera);
            ProgRecord camME = new ProgRecord("MetcamEast", "/", "MetcamEast", 0, "192.168.1.17", ProgRecord.objType.Camera);
            ProgRecord camMW = new ProgRecord("MetcamWest", "/", "MetcamWest", 0, "192.168.1.18", ProgRecord.objType.Camera);
            ProgRecord camMZ = new ProgRecord("MetcamZenith", "/", "MetcamZenith", 0, "192.168.1.19", ProgRecord.objType.Camera);
            cams.Add(camMN);
            cams.Add(camMZ);
            cams.Add(camME);
            cams.Add(camMS);
            cams.Add(camMW);
            camBramaW.pActive = isHostAlive(camBramaW);
            camBramaN.pActive = isHostAlive(camBramaN);
            camMN.pActive = isHostAlive(camMN);
            camMS.pActive = isHostAlive(camMS);
            camME.pActive = isHostAlive(camME);
            camMW.pActive = isHostAlive(camMW);
            camMZ.pActive = isHostAlive(camMZ);
            Console.WriteLine(GetResultRequest(camBramaN));
            Console.WriteLine(GetResultRequest(camBramaW));
            Console.WriteLine(GetResultRequest(camMN));
            Console.WriteLine(GetResultRequest(camMS));
            Console.WriteLine(GetResultRequest(camMW));
            Console.WriteLine(GetResultRequest(camME));
            Console.WriteLine(GetResultRequest(camMZ));


            foreach (Process theprocess in processlist)
            {
                
                //Console.WriteLine("MM:" + theprocess.StartInfo.FileName);
                //Console.WriteLine("MM:" + theprocess.StartInfo.WorkingDirectory);
                string id = GetMainModuleFilepath(theprocess.Id);
                //Console.WriteLine("Process: " + id);
                if (id == camE)
                {
                    Console.WriteLine("UFO2 for cam E runing");
                    //http://intranet.cervello.pl/endpointstate.php?ids=MetcamEast&ipaddress=10&state=1
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoECam&ipaddress=10&state=1", "POST", "ids=UfoECam&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    cE = 1;
                }
                else if(id == camN)
                {
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoNCam&ipaddress=10&state=1", "POST", "ids=UfoNCam&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    Console.WriteLine("UFO2 for cam N runing");
                    cN = 1;
                }
                else if(id == camS)
                {
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoSCam&ipaddress=10&state=1", "POST", "ids=UfoSCam&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    Console.WriteLine("UFO2 for cam S runing");
                    cS = 1;
                }
                else if (id == camW)
                {
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=MetcamWest&ipaddress=10&state=1", "POST", "ids=MetcamWest&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    cW = 1;
                    Console.WriteLine("UFO2 for cam W runing");
                }
                else if (id == camZ)
                {
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=MetcamZenith&ipaddress=10&state=1", "POST", "ids=MetcamZenith&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    cZ = 1;
                    Console.WriteLine("UFO2 for cam Z runing");
                }
                else if (id == spyi)
                {
                    MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=iSpyKarolin&ipaddress=10&state=1", "POST", "ids=iSpyKarolin&ipaddress=10&state=1");
                    //show the response string on the console screen.
                    Console.WriteLine(myRequest.GetResponse());
                    Console.WriteLine("iSpy runing");
                    cI = 1;
                } else
                {
                   // Console.WriteLine("Not ufoprocess");
                }
                //Console.WriteLine("MM:" + id);
                
            }
            if (cI == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=iSpyKarolin&ipaddress=10&state=0", "POST", "ids=iSpyKarolin&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }
            if (cE == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoECam&ipaddress=10&state=0", "POST", "ids=UfoECam&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }
            if (cN == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoNCam&ipaddress=10&state=0", "POST", "ids=UfoNCam&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }
            if (cS == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoSCam&ipaddress=10&state=0", "POST", "ids=UfoSCam&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }
            if (cW == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoWCam&ipaddress=10&state=0", "POST", "ids=UfoWCam&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }
            if (cZ == 0)
            {

                MyWebRequest myRequest = new MyWebRequest("http://intranet.cervello.pl/endpointstate.php?ids=UfoZCam&ipaddress=10&state=0", "POST", "ids=UfoZCam&ipaddress=10&state=0");
                //show the response string on the console screen.
                Console.WriteLine(myRequest.GetResponse());
            }

        }

        public static string GetResultRequest(ProgRecord pr)
        {
            string url = "http://intranet.cervello.pl/endpointstate.php?ids=" + pr.pAlias + "&ipaddress=" + pr.pIP + "&state=" + pr.pActive;
            MyWebRequest myRequest = new MyWebRequest(url, "POST", "ids=" + pr.pAlias + "&ipaddress=" + pr.pIP + "&state=" + pr.pActive);
            return myRequest.GetResponse();
        }

        public static int isHostAlive(ProgRecord pr)
        {
            int rtn = 0;
            bool result = PingHost(pr.pIP);
            if(result)
            {
                rtn = 1;
            }
            return rtn;
        }
        private static string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return null;
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }


    }
    public class MyWebRequest
    {
        public WebRequest request;
        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

        public MyWebRequest(string url, string method)
            : this(url)
        {

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public MyWebRequest(string url, string method, string data)
            : this(url, method)
        {

            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            using (dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            // Close the Stream object.
            dataStream.Close();

        }

        public string GetResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

    }
}

public class ProgRecord
{
    public string pName;
    public string pPath;
    public string pAlias;
    public int pActive;
    public string pIP;
    public objType pType;


    public enum objType
    {
        Camera = 0,
        Software = 1
    }
    public  ProgRecord(string prName, string prPath, string prAlias, int prActive, string prIP, objType prType)
    {
        pName = prName;
        pPath = prPath;
        pAlias = prAlias;
        pActive = prActive;
        pIP = prIP;
        pType = prType;

    }

}
