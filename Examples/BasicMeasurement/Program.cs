using OtiiTcpClient;
using System;
using System.Threading;

namespace BasicMeasurement
{
	internal class Program
	{
		private const int RecordingTime = 1000;

		private static void Main(string[] args)
		{
			// Calling Connect without parameters will connect to a local instance of Otii

			var client = new OtiiClient();
			var status = client.Connect();
			Console.WriteLine(status.ToString());
			// Create a local reference to the Otii property for convenience
			var otii = client.Otii;
			
			// Get a list of all Otii devices available
			var devices = otii.GetDevices();
			if (devices.Length == 0)
			{
				throw new Exception("No available devices");
			}

			// Get a reference to the first device in the list
			var arc = devices[0];
			Console.WriteLine($"Device name: {arc.Name}, Device type: {arc.Type}");
			var project = otii.GetActiveProject();
			if (project == null)
			{
				project = otii.CreateProject();
			}

			// Configuration
			arc.SetMainVoltage(3.3);
			arc.SetMaxCurrent(0.5);
			arc.EnableUart(true);
			arc.SetUartBaudrate(115200);
			arc.EnableChannel(Channel.MainCurrent, true);
			arc.EnableChannel(Channel.MainVoltage, true);
			arc.EnableChannel(Channel.UartLogs, true);
			arc.EnableChannel(Channel.Gpi1, true);


			
			//Further testing new functionality
			var arc4Wire = arc.Get4Wire();
			Console.WriteLine(arc4Wire.ToString());

			var arcMeasurementRange = arc.GetRange();
			Console.WriteLine(arcMeasurementRange.ToString());

			var value = arc.GetValue(Channel.AdcVoltage);
			Console.WriteLine(value.ToString());

			arc.SetPowerRegulation(PowerRegulationMode.Voltage);
			arc.SetRange(MeasurementRange.Auto);

			// Record
			project.StartRecording();
			arc.SetMain(true);
			Thread.Sleep(RecordingTime);
			arc.SetMain(false);
			project.StopRecording();
			project.Save("swag.otii", true, true);

			var recording = project.GetLastRecording();
			//recording.GetDigitalChannelData( Channel.MainCurrent, 0, 100);

			// Close the connection
			client.Close();
		}
	}
}