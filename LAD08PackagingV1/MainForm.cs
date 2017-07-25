using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using LAD08PackagingV1.Properties;

namespace LAD08PackagingV1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSetting();
            InitMine();
        }
        private delegate void LabelDelagate(Label label, string data);
        private delegate void PackingStateDelegate(PackingStates states);

        private delegate void StringDelegate(string data);

        private event PackingStateDelegate PackingStateChanged;
         
        private IReferenceData _referenceData;
        private string _settingDatabaseConnection;
        private string _settingProvider;
        public Settings Settings;

        private CodeSoftLabel _individualLabel;
        private CodeSoftLabel _groupingLabel;
        private Weighing _weighingStation;
        private Plc _zelioPlc;
        private BarcodeEntry _barcodeEntry;
        private WorkOrder _workOrder;
        private Grouping _groupBox;
        private SerialBarcodeReader _serialBarcodeReader;

        private PackingStates _packingState= PackingStates.Unknown;

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblBuild.Text =@"Build : "+ Assembly.GetExecutingAssembly().GetLinkerTime().ToString("yyMMddhhmmss");
        }

        private void LoadSetting()
        {
             Settings = new Settings();
            _settingDatabaseConnection = Settings.DatabaseReference;
            _settingProvider = Settings.ProviderDataBase;

            if (Settings.UseBarcodeEntrySuffix)
            {
                timerReadInput.Stop();
            }
            else
            {
                timerReadInput.Start();
            }
        }
        private void InitMine()
        {
          _referenceData = new ReferenceDataMicrosoftAccess(_settingDatabaseConnection,_settingProvider);

          _zelioPlc = new Plc(Settings);
          _zelioPlc.PlcDataUpdated += ZelioPlcOnPlcDataUpdated;
          _zelioPlc.SensorLabelChanged += ZelioPlcOnSensorLabelChanged;
          _zelioPlc.SensorProductChanged += ZelioPlcOnSensorProductChanged;
          _zelioPlc.SensorRejectChanged += ZelioPlcOnSensorRejectChanged; 


          _barcodeEntry = new BarcodeEntry();     
          _barcodeEntry.BarcodeDataUpdated += BarcodeEntryOnBarcodeDataUpdated;
          _barcodeEntry.BarcodeStateChanged += BarcodeEntryOnBarcodeStateChanged;
          


            if (Settings.UseSerialBarcode)
            {
                _serialBarcodeReader = new SerialBarcodeReader(Settings.ArticleNumberLength);
                _serialBarcodeReader.BarcodeDataUpdated += SerialBarcodeReaderOnBarcodeDataUpdated;
            }

            try
            {
                PackingStateChanged -= OnPackingStateChanged;
            }
            finally
            {
                PackingStateChanged += OnPackingStateChanged;
            }
            SetPackingState(PackingStates.WakingUp);
        }

        private void ZelioPlcOnSensorRejectChanged(IoSate data)
        {
            switch (_packingState)
            {
                case PackingStates.RejectBin:
                    if (data == IoSate.On)
                    {
                        SetPackingState(PackingStates.WaitingForProduct);
                        IncreaseWorkOrderReject(1);
                    }
                    break;

            }
        }

        private void IncreaseWorkOrderReject(int i)
        {
            _workOrder.IncreaseQuantityReject(i);
            lblReject.Text = _workOrder.QuantityReject.ToString("000");
        }
        private void IncreaseWorkOrderPass(int i)
        {
            _workOrder.IncreaseQuantityPass(i);
            lblPass.Text = _workOrder.QuantityPass.ToString("000");
            _groupBox.Packed += i;
            if (_groupBox.Packed == _workOrder.QuantityTarget)
            {
                MessageBox.Show(@"Target Quantity sudah terpenuhi.\r\nWorkOrder otomatis ditutup.", @"Target",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _barcodeEntry.State = BarcodeState.ReadWorkOrder;
                _referenceData?.Unload();
                SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
            }
        }
        private void ZelioPlcOnSensorProductChanged(IoSate data)
        {
            switch (_packingState)
            {
                case PackingStates.WaitingForProduct:
                    if (data == IoSate.On)
                    {
                        SetPackingState(PackingStates.PrintingLabeL);
                    }
                    break;

            }
        }

        private void ZelioPlcOnSensorLabelChanged(IoSate data)
        {
            switch (_packingState)
            {
                case PackingStates.AskToRemoveLabel:
                    if (data == IoSate.Off)
                    {
                        SetPackingState(PackingStates.WaitingBarcode);
                    }
                    break;
                case PackingStates.PrintingIndividualFail:
                    if (data == IoSate.On)
                    {
                        SetPackingState(PackingStates.AskToRemoveLabel);
                    }
                    break;

            }
        }

        private void ZelioPlcOnPlcDataUpdated()
        {
            chbPlcIndicator.Checked = !chbPlcIndicator.Checked;
            chbPlcIndicator.BackColor = chbPlcIndicator.CheckState == CheckState.Checked
                ? _zelioPlc.OnColor
                : _zelioPlc.OffColor;
        }

        private void BarcodeEntryOnBarcodeStateChanged(BarcodeState state)
        {
            switch (state)
            {
                case BarcodeState.None:
                    lblBarcodeState.Text = @"Idle";
                    break;
                case BarcodeState.ReadReference:
                    lblBarcodeState.Text = @"Read Reference";
                    break;
                case BarcodeState.ReadTarget:
                    lblBarcodeState.Text = @"Read Target";
                    break;
                case BarcodeState.ReadWorkOrder:
                    lblBarcodeState.Text = @"Read Work Order";
                    txtReference.Text = "";
                    txtProdOrderNumber.Text = "";
                    txtTargetQuantity.Text = "";
                    txtArticle.Text = "";
                    txtEan13.Text = "";
                    break;
                case BarcodeState.ReadPastedLabel:
                    _barcodeEntry.Read("");
                    lblBarcodeState.Text = @"Confirm Individual";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void BarcodeEntryOnBarcodeDataUpdated(string data, BarcodeState state)
        {
            data = data.Trim('\r', '\n');
            switch (state)
            {
                case BarcodeState.None:
                    break;
                case BarcodeState.ReadReference:
                    txtReference.Text = data;
                    _barcodeEntry.State = BarcodeState.ReadTarget;
                    SetPackingState(PackingStates.ReadBarcodeTarget);
                    break;
                case BarcodeState.ReadTarget:
                    txtTargetQuantity.Text = data;
                    _barcodeEntry.State = BarcodeState.None;
                    SetPackingState(PackingStates.LoadingReference);
                    break;
                case BarcodeState.ReadWorkOrder:
                    txtProdOrderNumber.Text = data;
                    _barcodeEntry.State = BarcodeState.ReadReference;
                    SetPackingState(PackingStates.ReadBarcodeReferemce);
                    break;
                case BarcodeState.ReadPastedLabel:
                    _barcodeEntry.State= BarcodeState.None;
                    SetPackingState(data == txtEan13.Text
                        ? PackingStates.ProductPassed
                        : PackingStates.ProductFailed);                   
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
           
        }

        private void ShowWorkOrderLabels(WorkOrder wo)
        {
            txtProdOrderNumber.Text = wo.ProdOrderNumber;
            txtReference.Text = wo.Reference;
            txtTargetQuantity.Text = wo.QuantityTarget.ToString("000");
            lblPass.Text = wo.QuantityPass.ToString("000");
            lblReject.Text = wo.QuantityReject.ToString("000");
        }

        private bool LoadReference(string reference)
        {
            _referenceData = new ReferenceDataMicrosoftAccess(Settings.DatabaseReference,Settings.ProviderDataBase);
            try
            {
                _referenceData.ReferenceDataIsLoaded -= ReferenceDataOnReferenceDataIsLoaded;
                _referenceData.ReferenceDataIsUnloaded -= ReferenceDataOnReferenceDataIsUnloaded;
            }
            finally
            {
                _referenceData.ReferenceDataIsLoaded += ReferenceDataOnReferenceDataIsLoaded;
                _referenceData.ReferenceDataIsUnloaded += ReferenceDataOnReferenceDataIsUnloaded;
            }

            var j = _referenceData.LoadByReferenceName(reference);

            return j;
        }

        private void ReferenceDataOnReferenceDataIsUnloaded()
        {
            lblGroupSize.Text = @"000";
            docGroupPrev.Image = new Bitmap(1,1);
            docIndiPrev.Image = new Bitmap(1,1);
            lblHighLimit.Text = @"00000";
            lblLowLimit.Text = @"00000";
            lblPass.Text = @"000";
            lblReject.Text = @"000";
            lblRemaining.Text = @"000";
        }

        private void ReferenceDataOnReferenceDataIsLoaded(ReferenceModel model)
        {
            lblGroupSize.Text = model.QuantityGroup.ToString("000");
            txtArticle.Text = model.ArticleNumber;
            txtEan13.Text = Ean13.CalculateChecksumDigit(model.ArticleNumber);

            _groupingLabel = new CodeSoftLabel(LabelType.Group, Settings, _referenceData.Reference);
            _groupingLabel.InitMine();
            _individualLabel = new CodeSoftLabel(LabelType.Individual, Settings, _referenceData.Reference);
            _individualLabel.InitMine();


            docGroupPrev.Image = _groupingLabel.ResizeIfNeeded(_groupingLabel.RealSizeImage, docGroupPrev.Width,
                docGroupPrev.Height);
            docIndiPrev.Image = _individualLabel.ResizeIfNeeded(_individualLabel.RealSizeImage, docIndiPrev.Width,
             docIndiPrev.Height);
            try
            {
                if (_weighingStation != null)
                {
                    _weighingStation.WeighingDataUpdated -= WeighingStationOnWeighingDataUpdated;
                    _weighingStation.WeighingDataInRange -= WeighingStationOnWeighingDataInRange;
                    _weighingStation.WeighingDataOutRange -= WeighingStationOnWeighingDataOutRange;
                    _weighingStation.WeighingBoxRemoved -= WeighingStationOnWeighingBoxRemoved;
                }
            }
            finally
            {
                _weighingStation = new Weighing(Settings, _referenceData.Reference);
                _weighingStation.WeighingDataUpdated += WeighingStationOnWeighingDataUpdated;
                _weighingStation.WeighingDataInRange += WeighingStationOnWeighingDataInRange;
                _weighingStation.WeighingDataOutRange += WeighingStationOnWeighingDataOutRange;
                _weighingStation.WeighingBoxRemoved += WeighingStationOnWeighingBoxRemoved;
                lblHighLimit.Text = _weighingStation.UpperWeightPerBox.ToString("00000");
                lblLowLimit.Text = _weighingStation.LowerWeightPerBox.ToString("00000");
            }

            
        }

        private void WeighingStationOnWeighingBoxRemoved(double value)
        {
            
        }

        private void GroupBoxOnRemainingValueChanged(int data)
        {
            lblRemaining.Text = data.ToString("000");
        }

        private void GroupBoxOnGroupingIsAchievedTarget()
        {

        }

        private void WeighingStationOnWeighingDataOutRange(double value)
        {
            lblWeighing.ForeColor = Color.Black;

        }

        private void WeighingStationOnWeighingDataInRange(double value)
        {
            lblWeighing.ForeColor = Color.Green;
            // print grouping label
            if (!_weighingStation.NeedToRemove)
            {
                if (_groupBox.PendingDoPrint())
                {
                    _groupingLabel?.Print();
                }
            }
        }

        private void WeighingStationOnWeighingDataUpdated(double value)
        {
            UpdateLabelWithInvoke(lblWeighing, value.ToString("F1"));
        }

        private void OnPackingStateChanged(PackingStates states)
        {
            switch (states)
            {
                case PackingStates.Unknown:
                    ShowInformation("Unknown State.");
                    break;
                case PackingStates.WakingUp:
                    ShowInformation("Memuat Ulang Work Order Terakhir yang running.");
                    _workOrder = new WorkOrder(Settings.DatabaseWorkOrder,Settings.ProviderDataBase);
                    _workOrder = _workOrder.GetByWorkOrderNumber(Settings.LastWorkOrder);
                    if (_workOrder.ProdOrderNumber == null)
                    {
                         SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
                        _barcodeEntry.State = BarcodeState.ReadWorkOrder;
                        break;
                    }
                    ShowWorkOrderLabels(_workOrder);
                    SetPackingState(PackingStates.LoadingReference);
                    break;
                case PackingStates.NoWorkOrder:
                    break;
                case PackingStates.ReadBarcodeProdOrderNumber:
                    ShowInformation("Scan Production Order Ticket.");
                    break;
                case PackingStates.ReadBarcodeReferemce:
                    ShowInformation("Scan Reference on Ticket.");
                    break;
                case PackingStates.ReadBarcodeTarget:
                    ShowInformation("Scan Quantity on Ticket.");
                    break;
                case PackingStates.LoadingReference:
                    ShowInformation("Memuat Product Reference.");
                    var j = LoadReference(txtReference.Text);
                    if (!j)
                    {
                        SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
                        _barcodeEntry.State = BarcodeState.ReadWorkOrder;
                        break;
                    }
                    _barcodeEntry.State = BarcodeState.None;
                    SetPackingState(PackingStates.CreateWorkOrder);
                    break;
                case PackingStates.WaitingForProduct:
                    ShowInformation("Menunggu Produk.");
                    if (_zelioPlc.SensorProduct== IoSate.On)
                    {
                        SetPackingState(PackingStates.PrintingLabeL);
                    }
                    break;
                case PackingStates.PrintingLabeL:
                    ShowInformation("Mencetak Individual Label");
                    if (_zelioPlc.SensorLabel == IoSate.Off)
                    {
                        _individualLabel?.Print();
                        timerPrintDelay.Start();
                    }
                    else
                    {
                        SetPackingState(PackingStates.AskToRemoveLabel);
                    }
                    break;
                case PackingStates.WaitingBarcode:
                    ShowInformation("Pack product, kemudian:\r\n Scan Barcode pada Individual Box");
                    _barcodeEntry.State = BarcodeState.ReadPastedLabel;
                    break;
                case PackingStates.ProductPassed:
                    ShowInformation("Packing Pass. Masukkan Ke Kotak ");
                    IncreaseWorkOrderPass(1);
                    SetPackingState(PackingStates.WaitingForProduct);
                    break;
                case PackingStates.ProductFailed:
                    ShowInformation("Packing Failed");
                    SetPackingState(PackingStates.RejectBin);
                    break;
                case PackingStates.RejectBin:
                    ShowInformation("Masukkan Produk Ke Reject Bin");
                    break;
                case PackingStates.BoxError:
                    break;
                case PackingStates.PrintingGroupingLabel:
                    break;
                case PackingStates.SetWeighing:
                    break;
                case PackingStates.CreateWorkOrder:
                    ShowInformation("Create or Load Work Order.");
                    _workOrder = new WorkOrder(Settings.DatabaseWorkOrder, Settings.ProviderDataBase,txtProdOrderNumber.Text,txtReference.Text,Convert.ToInt32(txtTargetQuantity.Text));
                    if (_workOrder.Reference != _referenceData.Reference.Reference) //Confirm correct reference
                    {
                        _referenceData.Unload();
                        txtReference.Text = _workOrder.Reference;
                        LoadReference(txtReference.Text);
                    }

                    if (_workOrder.ProdOrderNumber == null)
                    {
                        SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
                        _barcodeEntry.State = BarcodeState.ReadWorkOrder;
                        break;
                    }
                    try
                    {
                        if (_groupBox != null)
                        {
                            _groupBox.GroupingIsAchievedTarget -= GroupBoxOnGroupingIsAchievedTarget;
                            _groupBox.RemainingValueChanged -= GroupBoxOnRemainingValueChanged;
                        }
                    }

                    finally
                    {
                        _groupBox = new Grouping(_referenceData.Reference.QuantityGroup, _workOrder.QuantityPass);
                        _groupBox.GroupingIsAchievedTarget += GroupBoxOnGroupingIsAchievedTarget;
                        _groupBox.RemainingValueChanged += GroupBoxOnRemainingValueChanged;

                        lblRemaining.Text = _groupBox.Remaining.ToString("000");
                    }
                   
                    ShowWorkOrderLabels(_workOrder);
                    Settings.LastWorkOrder = _workOrder.ProdOrderNumber;
                    Settings.Save();
                    Settings.Reload();

                    if (_groupBox.Packed == _workOrder.QuantityTarget)
                    {
                        MessageBox.Show(@"Target Quantity sudah terpenuhi.\r\nWorkOrder otomatis ditutup.", @"Target",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _barcodeEntry.State = BarcodeState.ReadWorkOrder;
                        _referenceData?.Unload();
                        SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
                    }
                    SetPackingState(PackingStates.WaitingForProduct);
                    break;
                case PackingStates.AskToRemoveLabel:
                    ShowInformation("Ambil label lalu tempelkan ke Box");
                    break;
                case PackingStates.PrintingIndividualFail:
                    ShowInformation("Printing Individual error. Silahkan Reset. dan Ulangi process");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }

        private void SetPackingState(PackingStates states)
        {
            if (_packingState == states) return;
            _packingState = states;
            PackingStateChanged?.Invoke(states);
        }
     

        private void btnIndividualLabel_Click(object sender, System.EventArgs e)
        {
            if (!_referenceData.IsLoaded) return;
            if (_individualLabel == null)
            {
                _individualLabel = new CodeSoftLabel(LabelType.Individual, Settings, _referenceData.Reference);
                _individualLabel.InitMine();
            }
            
            _individualLabel.Show();
            _individualLabel.BringToFront();
        }

        private void btnGroupingLabel_Click(object sender, System.EventArgs e)
        {
            if (!_referenceData.IsLoaded) return;
            if (_groupingLabel == null)
            {
                _groupingLabel = new CodeSoftLabel(LabelType.Group, Settings, _referenceData.Reference);
                _groupingLabel.InitMine();
            }

            _groupingLabel.Show();
            _groupingLabel.BringToFront();

        }

        private void btnWeighing_Click(object sender, System.EventArgs e)
        {
          if (_weighingStation == null)
            {
                _weighingStation= new Weighing(Settings,_referenceData.Reference);
            }
            _weighingStation.Show();
            _weighingStation.BringToFront();
        }

        private void btnPlc_Click(object sender, System.EventArgs e)
        {
            if (_zelioPlc == null)
            {
                _zelioPlc = new Plc(Settings);
            }
            _zelioPlc?.Show();
        }

        private void groupBox7_Enter(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyValue == 13)
            {
                _barcodeEntry.Read(txtInputEntry.Text.Trim('\r','\n'));
                txtInputEntry.Clear();
                return;
            }
            if (e.KeyValue < 40) return;
            txtInputEntry.Text += ((char)e.KeyValue).ToString();
        }

        private void timerReadInput_Tick(object sender, EventArgs e)
        {
            timerReadInput.Stop();
            _barcodeEntry.Read(txtInputEntry.Text.Trim('\r','\n'));
            txtInputEntry.Clear();
            timerReadInput.Start();
        }
        private void ShowInformation( string text)
        {
            if (txtInformation.InvokeRequired)
            {
                StringDelegate d = ShowInformation;
                Invoke(d,text);
            }
            else
            {
                txtInformation.Text = text;
            }
        }
        private void UpdateLabelWithInvoke(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                LabelDelagate d = UpdateLabelWithInvoke;
                Invoke(d,label, text);
            }
            else
            {
                label.Text = text;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       

        private void txtInputEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtInputEntry_Leave(object sender, EventArgs e)
        {
            txtInputEntry.Focus();
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) txtInputEntry.Focus();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Visible) txtInputEntry.Focus();
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            if (_workOrder.ProdOrderNumber != null)
            {
                var dialog = MessageBox.Show(@"Apakah anda yakin akan menutup workorder ini?", @"Close Work Order",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.Cancel) return;
            }

            _barcodeEntry.State = BarcodeState.ReadWorkOrder;
            _referenceData?.Unload();
             SetPackingState(PackingStates.ReadBarcodeProdOrderNumber);
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnResetCurrentCycle_Click(object sender, EventArgs e)
        {
            _barcodeEntry.State = BarcodeState.None;
            SetPackingState(PackingStates.WaitingForProduct);
        }

        private void timerPrintDelay_Tick(object sender, EventArgs e)
        {
            timerPrintDelay.Stop();
            SetPackingState(_zelioPlc.SensorLabel == IoSate.On
                ? PackingStates.AskToRemoveLabel
                : PackingStates.PrintingIndividualFail);
        }

        private void btnBarcodeReader_Click(object sender, EventArgs e)
        {
            if (_serialBarcodeReader == null)
            {
                if (Settings.UseSerialBarcode)
                {
                    _serialBarcodeReader = new SerialBarcodeReader(Settings.ArticleNumberLength);
                    _serialBarcodeReader.BarcodeDataUpdated += SerialBarcodeReaderOnBarcodeDataUpdated;
                }
                else
                {
                    MessageBox.Show(@"Serial Com Barcode is Not Used!");
                }
            }
            _serialBarcodeReader?.Show();
            _serialBarcodeReader?.BringToFront();
        }

        private void SerialBarcodeReaderOnBarcodeDataUpdated(string barcode)
        {
            if(_barcodeEntry.State == BarcodeState.ReadPastedLabel)
            _barcodeEntry.Read(barcode);
        }

        private void tmrBlink_Tick(object sender, EventArgs e)
        {
            if (_weighingStation != null)
            {
                if (_weighingStation.NeedToRemove)
                {
                    lblRemoveBox.Visible = true;
                    lblRemoveBox.ForeColor = lblRemoveBox.ForeColor == Color.Red ? Color.Yellow : Color.Red;
                }
                else
                {
                    lblRemoveBox.Visible = false;
                }
            }
        }
    }
}
