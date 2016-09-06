using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Management;
using System.Data;

namespace SPUpdater
{

    

    class Service
    {
        public class ServiceObject
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string State { get; set; }
            public string StartMode { get; set; }
            public string Status { get; set; }
        }

        private enum ServiceActions
        {
            Start,
            Stop
        }

        /// <summary>
        /// Get information about all the services on the Windows box
        /// </summary>
        /// <returns>Returns a collection of ServiceObjects</returns>
        public ServiceObject[] GetServices()
        {
            
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            ServiceObject[] collection;
            List<ServiceObject> tempCol = new List<ServiceObject>();

            foreach (ServiceController scTemp in scServices)
            {
                ServiceObject so = new ServiceObject();

                ManagementObject wmiService;
                wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                wmiService.Get();

                so.Name = wmiService.Properties["Name"].Value.ToString();
                so.DisplayName = wmiService.Properties["Caption"].Value.ToString();
                if (wmiService.Properties["Description"].Value != null)
                {
                    so.Description = wmiService.Properties["Description"].Value.ToString();
                }
                else
                {
                    so.Description = "No Description Provided";
                }
                
                so.State = wmiService.Properties["State"].Value.ToString();
                so.StartMode = wmiService.Properties["StartMode"].Value.ToString();
                so.Status = wmiService.Properties["Status"].Value.ToString();

                tempCol.Add(so);

            }

            collection = tempCol.ToArray();
            return collection;
        }

        /// <summary>
        /// Get information about a service such as its name, status, start method
        /// </summary>
        /// <param name="serviceName">The name of the service to get details about</param>
        /// <returns>Returns a ServiceObject with details regarding the service</returns>
        public ServiceObject GetServiceInfo(string serviceName)
        {
            ServiceObject so = new ServiceObject();

            ManagementObject wmiService;
            wmiService = new ManagementObject("Win32_Service.Name='" + serviceName + "'");
            wmiService.Get();

            so.Name = wmiService.Properties["Name"].Value.ToString();
            so.DisplayName = wmiService.Properties["Caption"].Value.ToString();
            so.Description = wmiService.Properties["Description"].Value.ToString();
            so.State = wmiService.Properties["State"].Value.ToString();
            so.StartMode = wmiService.Properties["StartMode"].Value.ToString();
            so.Status = wmiService.Properties["Status"].Value.ToString();

            return so;
            
        }

        /// <summary>
        /// Start a Windows Service
        /// </summary>
        /// <param name="serviceName">The name of the service to start</param>
        /// <returns></returns>
        public Message StartService(string serviceName)
        {
            Message message = new Message();
            message = ServiceAction(serviceName, 10000, ServiceActions.Start);
            return message;
        }

        /// <summary>
        /// Start a Windows service
        /// </summary>
        /// <param name="serviceName">The name of the service to start</param>
        /// <param name="timeOut">How long to wait (in milliseconds) before timing out</param>
        /// <returns></returns>
        public Message StartService(string serviceName, int timeOut)
        {
            Message message = new Message();
            message = ServiceAction(serviceName, timeOut, ServiceActions.Start);
            return message;
        }

        public Message StopService(string serviceName)
        {
            Message msg = new Message();
            msg = ServiceAction(serviceName, 10000, ServiceActions.Stop);
            return msg;
        }

        public Message StopService(string serviceName, int timeOut)
        {
            Message msg = new Message();
            msg = ServiceAction(serviceName, timeOut, ServiceActions.Stop);
            return msg;
        }

        /// <summary>
        /// Restart a Windows Service
        /// </summary>
        /// <param name="serviceName">Windows service to restart</param>
        /// <returns></returns>
        public Message RestartService(string serviceName)
        {
            Message msg = ServiceRestart(serviceName, 10000);
            return msg;
        }

        /// <summary>
        /// Restart a Windows Service
        /// </summary>
        /// <param name="serviceName">The name of the service to restart</param>
        /// <param name="timeOut">How long to wait before the operation times out</param>
        /// <returns>Returns a Message object</returns>
        public Message RestartService(string serviceName, int timeOut)
        {
            Message msg = ServiceRestart(serviceName, timeOut);
            return msg;
        }

        private Message ServiceAction(string serviceName, int timeOut, ServiceActions action )
        {
            Message msg = new Message();

            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeOut);

                switch (action)
                {
                    case ServiceActions.Start:
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        break;
                    case ServiceActions.Stop:
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                        break;
                    default:
                        break;
                }
               
            }
            catch (System.ServiceProcess.TimeoutException ex)
            {
                // Service timed out trying to restart
                msg.title = "Service Time Out";
                msg.message = ex.Message;
                msg.messageType = Message.MessageType.Error;
            }
            catch (Exception ex)
            {
                msg.title = "Unknown Error";
                msg.message = "Unknown error attempting to " + action.ToString().ToLower() +" service '" + serviceName + "'." +
                    System.Environment.NewLine + ex.Message;
            }

            return msg;
        }

        private Message ServiceRestart(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);

                Message msg = new Message();
                msg.title = "Service Restarted";
                msg.message = "Service '" + serviceName + "' has been restarted.";
                msg.messageType = Message.MessageType.Information;

                return msg;
            }
            catch(System.ServiceProcess.TimeoutException ex)
            {
                Message msg = new Message();
                msg.title = "Service Error - Time Out";
                msg.message = "Service '" + serviceName + "' could not be restarted." +
                    System.Environment.NewLine + ex.ToString();
                msg.messageType = Message.MessageType.Error;

                return msg;
            }
            catch(Exception ex)
            {
                Message msg = new Message();
                msg.title = "Unknown Service Error";
                msg.message = "Service '" + serviceName + "' could not be restarted." +
                    System.Environment.NewLine + ex.ToString();
                msg.messageType = Message.MessageType.Error;

                return msg;
            }
        }
    }
}
