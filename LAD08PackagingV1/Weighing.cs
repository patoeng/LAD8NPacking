using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using LAD08PackagingV1.Properties;

namespace LAD08PackagingV1
{
    public delegate void WeighingData(double value);

    public delegate void DelegateSetLabelText(string value);
    public partial class Weighing : Form
    {
        private readonly Settings _settings;
        private readonly ReferenceModel _referenceModel;

        public event WeighingData WeighingDataUpdated;
        public event WeighingData WeighingDataInRange;
        public event WeighingData WeighingDataOutRange;
        public event WeighingData WeighingBoxRemoved;

        public void SetNeedToRemoveBox()
        {
            NeedToRemove = true;
        }
        public bool NeedToRemove { get; protected set; }
        public int UpperWeightPerBox { get; protected set; }
        public int LowerWeightPerBox { get; protected set; }
        public bool WeightInRange { get; protected set; }

        private double _value;
        public double Value
        {
            get { return _value; }
            protected set
            {
                if (Math.Abs(_value - value) <0.01) return;
                _value = value;
                WeighingDataUpdated?.Invoke(_value);

                if (_value > LowerWeightPerBox && _value < UpperWeightPerBox)
                {
                    timerStabilization.Start();
                }
                else
                {
                    WeightInRange = false;
                    timerStabilization.Stop();
                    WeighingDataOutRange?.Invoke(_value);
                }
                if (_value < 300.0)
                {
                    NeedToRemove = false;
                    WeighingBoxRemoved?.Invoke(_value);
                }
            }
        }

        public int CalculatedQuantityInBox { get; protected set; }

        public Weighing(Settings settings, ReferenceModel reference)
        {
            InitializeComponent();
            _settings = settings;
            _referenceModel = reference;
            LoadAll();

            try
            {
                WeighingDataUpdated -= OnWeighingDataUpdated;
                WeighingDataInRange -= OnWeighingDataInRange;
                WeighingDataOutRange -= OnWeighingDataOutRange;
            }
            catch
            {
                // ignored
            }
            WeighingDataUpdated += OnWeighingDataUpdated;
            WeighingDataInRange += OnWeighingDataInRange;
            WeighingDataOutRange += OnWeighingDataOutRange;
        
        }

        private void OnWeighingDataOutRange(double value)
        {
            lblValue.ForeColor = Color.Red;
        }

        private void OnWeighingDataInRange(double value)
        {
            lblValue.ForeColor = Color.Green;
        }

        private void OnWeighingDataUpdated(double value)
        {
            lblValue.Text = value.ToString("F1");
        }

        private void LoadAll()
        {
            IterateAllComport(cbbComPort, _settings.WeighingComName);

            serialPortWeighing.PortName = _settings.WeighingComName;
            serialPortWeighing.BaudRate = _settings.WeighingComBaudRate;
            serialPortWeighing.StopBits = _settings.WeighingComStopBit;
            serialPortWeighing.Parity = _settings.WeighingComParity;

            timerStabilization.Interval = _settings.WeighingStabilizationTime * 1000;
            gbLimits.Enabled = false;
            if (_referenceModel != null)
            {
                UpperWeightPerBox = _referenceModel.QuantityGroup * _referenceModel.WeighingMaximal;
                LowerWeightPerBox = _referenceModel.QuantityGroup * _referenceModel.WeighingMinimal;

                lblReference.Text = _referenceModel.Reference;
                lblReference2.Text = _referenceModel.Reference;

                textUpper.Text = _referenceModel.WeighingMaximal.ToString();
                textLower.Text = _referenceModel.WeighingMinimal.ToString();
                textNominal.Text = _referenceModel.WeighingNominal.ToString();
                gbLimits.Enabled = true;
            }

            textStabilization.Text = _settings.WeighingStabilizationTime.ToString();
            lblOffset.Text = _settings.WeighingDefaultLimit.ToString();

            try
            {
                if (!serialPortWeighing.IsOpen)
                    serialPortWeighing.Open();
                btnOpenClose.Text = serialPortWeighing.IsOpen ? "Close" : "Open";
                lbIsOpenClosed.Text = serialPortWeighing.IsOpen ? "Com is Open" : "Com is Closed";
            }
            catch
            {
                // ignored
            }
        }
        private void IterateAllComport(ComboBox cbb, string selected)
        {
            cbb.Items.Clear();
            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                cbb.Items.Add(port);
            }
            cbb.Text = selected;
        }
        private void Weighing_Load(object sender, System.EventArgs e)
        {

        }

   

        private string _temporaryContainer;
        private void serialPortWeighing_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_settings.WeighingComSuffix)
            {
                _temporaryContainer += serialPortWeighing.ReadExisting();
                if (_temporaryContainer.Contains("\r") || e.EventType == SerialData.Eof)
                {
                    UpdateValueWithInvoke(_temporaryContainer.Trim('\r','\n'));
                    _temporaryContainer = "";
                }
            }
            else
            {
                _temporaryContainer = serialPortWeighing.ReadExisting();
                UpdateValueWithInvoke(_temporaryContainer.Trim('\r', '\n'));
                _temporaryContainer = "";
            }           
        }

        private void UpdateValueWithInvoke(string text)
        {
            if (lblValue.InvokeRequired)
            {
                DelegateSetLabelText d = UpdateValueWithInvoke;
                Invoke(d, text);
            }
            else
            {
                try
                {
                    var j = text.Split(' ');
                    if (j.Length<3) return;
                    if (j[1] == "-") j[1] = j[1] + j[2];
                    Value = Convert.ToDouble(j[1]);
                }
                catch
                {
                 //  MessageBox.Show(@"Convert Error");
                }
            }

        }

        private void timerStabilization_Tick(object sender, EventArgs e)
        {
            timerStabilization.Stop();
            WeightInRange = true;
            WeighingDataInRange?.Invoke(Value);
        }

      
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOpenClose.Text == @"Close")
                {
                    if (serialPortWeighing.IsOpen)
                    {
                        serialPortWeighing.Close();
                        btnOpenClose.Text = @"Open";
                        lbIsOpenClosed.Text = @"Com Is Close";
                    }
                }
                else
                {
                    if (!serialPortWeighing.IsOpen)
                    {
                        serialPortWeighing.Open();
                        btnOpenClose.Text = @"Close";
                        lbIsOpenClosed.Text = @"Com Is Open";
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private void btnSavePort_Click(object sender, EventArgs e)
        {
            _settings.WeighingComName = cbbComPort.Text;
            _settings.WeighingStabilizationTime =
                Convert.ToInt32(textStabilization.Text == "" ? "1" : textStabilization.Text);
            _settings.Save();
            _settings.Reload();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var nominal = Value;
            var upper = Value + _settings.WeighingDefaultLimit;
            var lower = Value - _settings.WeighingDefaultLimit;

            textNominal.Text = nominal.ToString("000");
            textUpper.Text = upper.ToString("000");
            textLower.Text = lower.ToString("000");       
        }

        private void btnSaveLimits_Click(object sender, EventArgs e)
        {
            gbLimits.Enabled = false;
            try
            {
               
                _referenceModel.WeighingMinimal = Convert.ToInt32(textLower.Text);
                _referenceModel.WeighingMaximal = Convert.ToInt32(textUpper.Text);
                _referenceModel.WeighingNominal = Convert.ToInt32(textNominal.Text);
                using (var jj = new ReferenceDataMicrosoftAccess(_settings.DatabaseReference, _settings.ProviderDataBase))
                {
                    jj.UpdateLimits(_referenceModel);

                }
            }
            catch
            {
                
                // ignored
            }
            gbLimits.Enabled = true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            textNominal.Text = _referenceModel.WeighingNominal.ToString();
            textUpper.Text = _referenceModel.WeighingMaximal.ToString();
            textLower.Text = _referenceModel.WeighingMinimal.ToString();
        }

        private void Weighing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IterateAllComport(cbbComPort, _settings.WeighingComName);
        }

      
    }
}
