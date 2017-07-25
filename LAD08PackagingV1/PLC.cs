using System;
using System.Drawing;
using System.Windows.Forms;
using LAD08PackagingV1.Properties;
using ModbusTCP;

namespace LAD08PackagingV1
{
    public delegate void IoStateDelegate(IoSate data);

    public delegate void PlcUpdate();

    public partial class Plc : Form
    {
        private Master _master;
        private readonly Settings _settings;

        public event IoStateDelegate SensorProductChanged;
        public event IoStateDelegate SensorRejectChanged;
        public event IoStateDelegate SensorLabelChanged;
        public event PlcUpdate PlcDataUpdated;

        private IoSate _sensorProduct; 
        private IoSate _sensorLabel ;
        private IoSate _sensorReject;

        public IoSate SensorProduct
        {
            get
            {
                return _sensorProduct;
            } 
            protected set
            {
                if (_sensorProduct == value) return;
                _sensorProduct = value;
                SensorProductChanged?.Invoke(value);
            } 
        }

        public IoSate SensorLabel {
            get
            {
                return _sensorLabel;
            }
            protected set
            {
                if (_sensorLabel == value) return;
                _sensorLabel = value;
                SensorLabelChanged?.Invoke(value);
            }
        }
        public IoSate SensorReject {
            get
            {
                return _sensorReject;
            }
            protected set
            {
                if (_sensorReject == value) return;
                _sensorReject = value;
                SensorRejectChanged?.Invoke(value);
            }
        }

        public Plc(Settings settings)
        {
            InitializeComponent();
            _settings = settings;

            try
            {
                SensorLabelChanged -= OnSensorLabelChanged;
                SensorProductChanged -= OnSensorProductChanged;
                SensorRejectChanged -= OnSensorRejectChanged;
                PlcDataUpdated -= OnPlcDataUpdated;
            }
            catch
            {
                // ignored
            }
            SensorLabelChanged += OnSensorLabelChanged;
            SensorProductChanged += OnSensorProductChanged;
            SensorRejectChanged += OnSensorRejectChanged;
            PlcDataUpdated += OnPlcDataUpdated;

            InitMine();
        }

        private void OnPlcDataUpdated()
        {
            chbPlcIndicator.Checked = !chbPlcIndicator.Checked;           
        }

        private void OnSensorRejectChanged(IoSate data)
        {
            chbSensorReject.Checked = data == IoSate.On;          
        }

        private void OnSensorProductChanged(IoSate data)
        {
            chbSensorProduct.Checked = data == IoSate.On;
        }

        private void OnSensorLabelChanged(IoSate data)
        {
            chbSensorLabel.Checked = data == IoSate.On;
        }

        public void InitMine()
        {
            timerScanner.Stop();
            txtIpAddress.Text = _settings.PLCIpAddress;
            txtPort.Text = _settings.PLCPort.ToString();
            txtScanRate.Text = _settings.PLCScanRate.ToString();

            timerScanner.Interval = _settings.PLCScanRate;
           

            chbPlcIndicator.BackColor = chbPlcIndicator.CheckState==CheckState.Checked? OnColor : OffColor;
            chbSensorLabel.BackColor = chbSensorLabel.CheckState == CheckState.Checked ? OnColor : OffColor;
            chbSensorProduct.BackColor = chbSensorProduct.CheckState == CheckState.Checked ? OnColor : OffColor;
            chbSensorReject.BackColor = chbSensorReject.CheckState == CheckState.Checked ? OnColor : OffColor;
            try
            {
                _master = new Master(_settings.PLCIpAddress, _settings.PLCPort);
               

                timerScanner.Start();
            }
            catch
            {
                // ignored
            }
        }
        public Color OnColor = Color.Yellow;
        public Color OffColor = Color.YellowGreen;
        public void LampToggle(CheckBox chb)
        {
            if (chb.CheckState == CheckState.Checked)
            {
                chb.CheckState = CheckState.Unchecked;
                chb.BackColor = OffColor;
            }
            else
            {
                chb.CheckState = CheckState.Checked;
                chb.BackColor = OnColor;
            }
        }
        private void PLC_Load(object sender, EventArgs e)
        {
          
        }

      
        private void timerScanner_Tick(object sender, EventArgs e)
        {
            if (_master == null) return;
            timerScanner.Stop();

            byte[] data = {};

            var suc =PlcCommand.GetPlcRawData(_master,4,ref data);

            if (suc)
            {
                var dataWord = ModbusTcpHelper.ByteArrayToWordArray(data);
                IoMapping(dataWord);   
            }
            timerScanner.Start();
        }

        private void IoMapping(int[] data)
        {
            SensorProduct = data[1] == 0 ? IoSate.Off : IoSate.On;
            SensorLabel = data[2] == 0 ? IoSate.Off : IoSate.On;
            SensorReject = data[0] == 0 ? IoSate.Off : IoSate.On;

            PlcDataUpdated?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.PLCIpAddress = txtIpAddress.Text;
                _settings.PLCPort = Convert.ToUInt16(txtPort.Text);
                _settings.PLCScanRate = Convert.ToInt32(txtScanRate.Text);
                _settings.Save();
            }
            catch
            {
                // ignored
            }
            _settings.Reload();
        }

        private void chbSensorProduct_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            cb.BackColor = cb.CheckState == CheckState.Checked ? OnColor : OffColor;
        }

        private void Plc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
