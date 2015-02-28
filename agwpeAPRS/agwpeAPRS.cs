using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgwpePort;

namespace agwpeAPRS
{
    public partial class agwpeAPRS : Form
    {
        public agwpeAPRS()
        {
            InitializeComponent();
        }

        private void agwpePort1_FrameReceived(object sender, AgwpeEventArgs e)
        {
            // Determine the kind of data that is associated with this AGWPE frame.
            switch (e.FrameHeader.DataKind)
            {
                case (byte)'X': // Register call sign
                    if ((bool)e.FrameData)
                        rtWrite("Callsign has been registered.\n");
                    break;
                case (byte)'G': // Get port information
                    rtWrite("Configured Ports: " + ((AgwpePortInfo)e.FrameData).ToString().Replace(';', '\n') + '\n');
                    break;
                case (byte)'g': // Get port capability
                    rtWrite(((AgwpePortCapability)e.FrameData).ToString().Replace(';', '\n') + '\n');
                    break;
                case (byte)'R': // Get version
                    rtWrite("AGWPE Version: " + ((AgwpeVersion)e.FrameData).ToString() + '\n');
                    break;
                case (byte)'H': // Get stations heard on a port
                    if (((AgwpeStationsHeard)e.FrameData).Station.Length > 0)
                        rtWrite(((AgwpeStationsHeard)e.FrameData).ToString() + '\n');
                    break;
                case (byte)'I': // Read AX25 Information frames and data
                    rtWrite(((AgwpeMoniConnInfo)e.FrameData).AX25Header + '\n' + Encoding.ASCII.GetString(((AgwpeMoniConnInfo)e.FrameData).AX25Data) + "\n\n");
                    break;
                case (byte)'S': // Read AX25 Supervisory frames
                    rtWrite(((AgwpeAX25Data)e.FrameData).ToString() + "\n\n");
                    break;
                case (byte)'U': // Read AX25 Unproto frames and data
                    //rtWrite(((AgwpeMoniUnproto)e.FrameData).AX25Header + "\n" 
                    //    + Encoding.ASCII.GetString(((AgwpeMoniUnproto)e.FrameData).AX25Data) 
                    //    + "\n\n");
                    aprsWrite(((AgwpeMoniUnproto)e.FrameData).AX25Header, Encoding.ASCII.GetString(((AgwpeMoniUnproto)e.FrameData).AX25Data));
                    break;
            }
        }

        private void rtWrite(string str)
        {
            // Invoke a delegate to handle writing text to our RichTextBox.
            rtbMessages.Invoke(new EventHandler(delegate
            {
                // Unselect any selected text.
                rtbMessages.SelectedText = string.Empty;
                // Write the string to the RichTextBox.
                rtbMessages.AppendText(str);
                // Scroll down, if needed, so we can see the new text.
                rtbMessages.ScrollToCaret();
            }));
        }

        private void aprsWrite(string strHeader, string strData)
        {
            string coordinates = "Unable to determine type";
            byte[] strBytes = ASCIIEncoding.UTF8.GetBytes(strData.Trim());
            //AgwpePort.Aprs.AprsData aprs = new AgwpePort.Aprs.AprsData(strData);
           if (strData.Length > 0)
           {
                coordinates = convertCoordinate(strBytes);
           }
            
            // Invoke a delegate to handle writing text to our RichTextBox.
            rtbMessages.Invoke(new EventHandler(delegate
            {
                // Unselect any selected text.
                rtbMessages.SelectedText = string.Empty;
                // Write the string to the RichTextBox.
                rtbMessages.AppendText("Header: " + strHeader + Environment.NewLine);


                rtbMessages.AppendText("Message: " + Encoding.UTF8.GetString(strBytes) + Environment.NewLine);
                
                rtbMessages.AppendText("Type: " + coordinates + Environment.NewLine + Environment.NewLine);
                //rtbMessages.AppendText("\n\n");
                //rtbMessages.AppendText(aprs.Latitude + "," + aprs.Longitude + "\n\n");
                // Scroll down, if needed, so we can see the new text.
                rtbMessages.ScrollToCaret();
            }));
        }

        private string convertCoordinate(byte[] data)
        {
            string dataTypeString = "";
            switch (data[0])
            {
                case (byte)'!':
                    dataTypeString = "Position without timestamp (no APRS messaging), or Ultimeter 2000 WX Station";
                    break;
                case (byte)'/':
                    dataTypeString = "Position with timestamp (no APRS messaging)";
                    break;
                case (byte)'=':
                    dataTypeString = "Position without timestamp (with APRS messaging)";
                    break;
                case (byte)'@':
                    dataTypeString = "Position with timestamp (with APRS messaging)";
                    break;
                case (byte)';':
                    dataTypeString = "Object Message";
                    break;
                case (byte)')':
                    dataTypeString = "Item Message";
                    break;
                case (byte)':':
                    dataTypeString = "Message, Bulletin or Announcement";
                    break;
                case (byte)'}':
                    dataTypeString = "Third-Party Traffic";
                    break;
                case (byte)'?':
                    dataTypeString = "Query Message";
                    break;
                case (byte)'>':
                    dataTypeString = "Status Message";
                    break;
                case (byte)'_':
                    dataTypeString = "Weather Report (without position)";
                    break;
                case (byte)'<':
                    dataTypeString = "Station Capabilities";
                    break;
                case (byte)'\'':
                    dataTypeString = "TM-D700 Data";
                    break;
                case (byte)'$':
                    dataTypeString = "Raw GPS Data or Ultimeter 2000 WX Station";
                    break;
                case (byte)0x1c:
                    dataTypeString = "Current Mic-E Data";
                    break;
                case (byte)0x1d:
                    dataTypeString = "Old Mic-E Data";
                    break;
                case (byte)'`':
                    dataTypeString = "Current Mic-E Data (not used in TM-D700)";
                    break;
                case (byte)'&':
                    dataTypeString = "[Reserved - Map Feature]";
                    break;
                case (byte)'+':
                    dataTypeString = "[Reserved - Shelter data with time]";
                    break;
                case (byte)'.':
                    dataTypeString = "[Reserved - Space Weather]";
                    break;
                case (byte)'#':
                    dataTypeString = "Peet Bros U-II Weather Station";
                    break;
                case (byte)'%':
                    dataTypeString = "Agrelo DF Jr/MicroFinder";
                    break;
                case (byte)'*':
                    dataTypeString = "Peet Bros U-II Weather Station";
                    break;
                case (byte)'T':
                    dataTypeString = "Telemetry Data";
                    break;
                case (byte)'{':
                    dataTypeString = "User-Defined APRS Packet Format";
                    break;
                case (byte)',':
                    dataTypeString = "Invalid or Test Data";
                    break;
                case (byte)'[':
                    dataTypeString = "Maidenhead Grid Locator Beacon (obsolete)";
                    break;
                case (byte)'"':
                case (byte)'(':
                case (byte)'-':
                case (byte)'\\':
                case (byte)']':
                case (byte)'^':
                    dataTypeString = "Unused Message Type Identifier";
                    break;
                default:
                    // Look for the '!' identifier in the first 40 bytes rather than just the first byte. 
                    // This is to support X1J TNC digipeaters.
                    if (ASCIIEncoding.ASCII.GetString(data).Substring(0, Math.Min(data.Length, 40)).Contains("!"))
                    {
                        dataTypeString = "DEFAULT: Position without timestamp (no APRS messaging), or Ultimeter 2000 WX Station";
                    }
                    break;
            }
            return dataTypeString;
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        
        {
            try
            {
                // Open a connection to AGWPE.
                agwpePort1.Open(Convert.ToByte(0), "localhost", 8000);
                // Register a callsign that we can accept incoming ax.25 connection requests for.
                agwpePort1.RegisterCallSign("KN0MAP");
                // Request the AGWPE major and minor version numbers.
                agwpePort1.GetVersion();
                // Request the capability information for the selected radio port.
                agwpePort1.GetPortCapability(Convert.ToByte(0));
                // Request information for all configured radio ports.
                agwpePort1.GetPortInfo();
                // Request the last 20 stations heard on the selected radio port.
                agwpePort1.StationsHeard(Convert.ToByte(0));
                // Start monitoring ax.25 traffic.
                agwpePort1.StartMonitoring();

                btnMonitor.Text = "Listening";
                btnMonitor.BackColor = System.Drawing.Color.Lime;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void agwpeAPRS_FormClosing(object sender, FormClosingEventArgs e)
        {
            agwpePort1.Close();
        }
    }
}
