using System;
using System.IO.Ports;
using System.Windows.Forms;
using LAD08PackagingV1.Properties;

namespace LAD08PackagingV1
{
    public delegate void BarcodeRead(string barcode);
    public partial class SerialBarcodeReader : Form
    {
        private readonly int _barcodeLength;
        public SerialBarcodeReader(int barcodeLength)
        {
            InitializeComponent();
            InitiateAll();
            _barcodeLength = barcodeLength;
            BarcodeDataUpdated += OnBarcodeDataUpdated;
        }

        private void OnBarcodeDataUpdated(string barcode)
        {
            txtRead.Text = barcode;
        }

        public event BarcodeRead BarcodeDataUpdated;
        private string _barcodeValue;

        public string BarcodeValue
        {
            get { return _barcodeValue; }
            protected set { _barcodeValue = value; BarcodeDataUpdated?.Invoke(_barcodeValue);}
        }

        private SerialPort _serialPort;
        private readonly Settings _settings = new Settings();
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRead.Clear();
        }

        private void SerialBarcodeReader_Load(object sender, EventArgs e)
        {
            
        }

        private void InitiSerialCom()
        {
            _serialPort = new SerialPort
            {
                PortName = _settings?.SerialBarcodeComName,
                Parity = _settings?.SerialBarcodeComParity ?? Parity.None,
                BaudRate = _settings?.SerialBarcodeComBaudRate ?? 9600,
                StopBits = _settings?.SerialBarcodeComStopBit ?? StopBits.One,
                DataBits = _settings?.SerialBarcodeComData ?? 8
            };

            _serialPort.DataReceived += SerialPortOnDataReceived;
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Serial Barcode : " + ex.Message);
            }
            btnOpenClose.Text = _serialPort.IsOpen ? @"Close" : @"Open";
        }

        private string _tempContainer;
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            _tempContainer += _serialPort.ReadExisting();
            if (_tempContainer.Contains("\r"))
            {
                var data = _tempContainer.Trim('\r', '\n');
                if (data.Length == _barcodeLength)
                {
                    UpdateValueWithInvoke(data);
                }
                _tempContainer = "";
            }
              
        }

        private void InitiateAll()
        {
            IterateAllComport(cbbComPort,_settings.SerialBarcodeComName);
            InitiSerialCom();
        }
        private void IterateAllComport(ComboBox cbb, string selected)
        {
            cbb.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbb.Items.Add(port);
            }
            cbb.Text = selected;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            _settings.SerialBarcodeComName = cbbComPort.Text;
            _settings.Save();
            _settings.Reload();
            _serialPort.PortName = _settings?.SerialBarcodeComName;
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text == "Open")
            {
                if (!_serialPort.IsOpen)
                {
                    try
                    {
                        _serialPort.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Serial Barcode : " + ex.Message);
                    }
                }
            }
            else
            {
                if (_serialPort.IsOpen)
                {
                    try
                    {
                        _serialPort.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Serial Barcode : " + ex.Message);
                    }
                }
            }
            btnOpenClose.Text = _serialPort.IsOpen ? @"Close" : @"Open";
        }
        private void UpdateValueWithInvoke(string text)
        {
            if (txtRead.InvokeRequired)
            {
                DelegateSetLabelText d = UpdateValueWithInvoke;
                Invoke(d, text);
            }
            else
            {
                try
                {
                    BarcodeValue = text;
                }
                catch
                {
                    // ignored
                }
            }

        }

        private void SerialBarcodeReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IterateAllComport(cbbComPort, _settings.SerialBarcodeComName);
        }
    }
}
