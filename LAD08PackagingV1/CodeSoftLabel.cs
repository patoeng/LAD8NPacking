using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using LAD08PackagingV1.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace LAD08PackagingV1
{
    public partial class CodeSoftLabel : Form
    {
        public Lppx2Manager MLppx2Manager = null;
        public LabelManager2.Application CsApp = null;

        private Image.GetThumbnailImageAbort _myCallback;
        private int _topOffset;
        private int _leftOffset;
        private string _printer;
        private readonly string _fileLabelTemplatePath;
        private LabelManager2.Document _loadedDocument;
        public bool NoDocOpened;
        private readonly ReferenceModel _referenceModel;
        public Image RealSizeImage;
        private readonly LabelType _labelType;
        private readonly Settings _setting; 

        public CodeSoftLabel(LabelType labelType, Settings settings, ReferenceModel reference)
        {
            InitializeComponent();
            _referenceModel = reference;
            _labelType = labelType;
            _setting = settings;
            switch (labelType)
            {
                case LabelType.Individual:
                    _topOffset = settings.LabelIndividualOffsetTop;
                    _leftOffset = settings.LabelIndividualOffsetLeft;
                    _printer = settings.IndividualPrinter;
                    _fileLabelTemplatePath = settings.LabelLocation + @"\" + reference.LabelTempate + ".lab";
                    break;
                case LabelType.Group:
                    _topOffset = settings.LabelGroupOffsetTop;
                    _leftOffset = settings.LabelGroupOffsetLeft;
                    _printer = settings.IndividualPrinter;
                    _fileLabelTemplatePath = settings.LabelLocation + @"\" + reference.GroupingLabelTempate + ".lab";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(labelType), labelType, null);
            }
           
        }

        public void InitMine()
        {
             Init();
            var loadLabel = LoadLabel();
            if (loadLabel)
            {
                CreateRealSizePreview();
            }
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                var pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbbPrinter.Items.Add(pkInstalledPrinters);
            }
        }
        private void Init()
        {
            try
            {
                MLppx2Manager = new Lppx2Manager();
                CsApp = MLppx2Manager.GetApplication();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            _myCallback = ThumbnailCallback;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
        
        private bool LoadLabel()
        {
            try
            {
                _loadedDocument?.Close();


                _loadedDocument = CsApp.Documents.Open(_fileLabelTemplatePath);
                switch (_labelType)
                {
                    case LabelType.Individual:
                        LoadIndividualVariables();
                        break;
                    case LabelType.Group:
                        LoadGroupLable();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (CsApp.Documents.Count > 0)
                {
                    NoDocOpened = false;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LoadIndividualVariables()
        {
            
            _loadedDocument.Variables.Item("Art_Number").Value = _referenceModel.ArticleNumber;
            _loadedDocument.Variables.Item("Reference").Value = _referenceModel.Reference;
            _loadedDocument.Variables.Item("Description_English").Value = _referenceModel.English;
            _loadedDocument.Variables.Item("Description_France").Value = _referenceModel.France;
            _loadedDocument.Variables.Item("Description_Germany").Value = _referenceModel.German;
            _loadedDocument.Variables.Item("Description_Spanish").Value = _referenceModel.Spain;
            _loadedDocument.Variables.Item("Qty_Group").Value = _referenceModel.QuantityGroup.ToString();
            _loadedDocument.Variables.Item("Qty_Indi").Value = _referenceModel.QuantityIndividual.ToString();
            _loadedDocument.Variables.Item("Qty_Lot").Value = _referenceModel.QuantityLot.ToString();

        }

        private void LoadGroupLable()
        {
            _loadedDocument.Variables.Item("Art_Number").Value = _referenceModel.ArticleNumber;
            _loadedDocument.Variables.Item("Reference").Value = _referenceModel.Reference;
            _loadedDocument.Variables.Item("Qty_Group").Value = _referenceModel.QuantityGroup.ToString();
            _loadedDocument.Variables.Item("Qty_Indi").Value = _referenceModel.QuantityIndividual.ToString();
            _loadedDocument.Variables.Item("Qty_Lot").Value = _referenceModel.QuantityLot.ToString();
        }
        private bool CreateRealSizePreview()
        {
           
            if (_loadedDocument != null)
            {
                DisposeImages();
                try
                {

                    object obj = _loadedDocument.GetPreview(true, true, 300);
                    if (obj is Array)
                    {
                        byte[] data = (byte[])obj;

                        System.IO.MemoryStream pStream = new System.IO.MemoryStream(data);


                        RealSizeImage = new Bitmap(pStream);
                     
                        return true;
                    }

                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
            return false;
        }
        private void DisposeImages()
        {
            RealSizeImage?.Dispose();
        }
        public void Print()
        {
            
            try
            {
                if (NoDocOpened)
                {
                    MessageBox.Show(@"A document must be opened to print !");                   
                    return;
                }

                try
                {
                    _loadedDocument.Printer.SwitchTo(_printer);
                    _loadedDocument.HorzPrintOffset = _topOffset;
                    _loadedDocument.VertPrintOffset = _leftOffset;
                    _loadedDocument.PrintDocument(1);

                }
                catch (Exception error)
                {
                    throw error;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Label " + ex.Message);

            }
        }
        public Image ResizeIfNeeded(Image originalImage, int width, int height)
        {

            if ((originalImage.Width > width) || (originalImage.Height > height))
            {
                if ((originalImage.Width / width) > (originalImage.Height / height))
                {
                    double a = ((double) width) / (((double) originalImage.Width));
                    var resultImage2 = originalImage.GetThumbnailImage((int)((double)originalImage.Width * a),
                        (int) ((double) originalImage.Height * a),
                        _myCallback, IntPtr.Zero);
                    return resultImage2;
                }
                else
                {
                    double a = ((double) height) / (((double) originalImage.Height));
                    var resultImage2 = originalImage.GetThumbnailImage((int) ((double) originalImage.Width * a),
                       (int)((double)originalImage.Height*a), _myCallback, IntPtr.Zero);
                    return resultImage2;
                }
            }
            return originalImage;
            
        }
        public Image ResizeFitBox(Image originalImage, int width, int height)
        {

            if ((originalImage.Width < width) || (originalImage.Height < height))
            {
                if (( width/ originalImage.Width) > ( height/ originalImage.Height))
                {
                    double a = ((double)width) / (((double)originalImage.Width));
                    var resultImage2 = originalImage.GetThumbnailImage((int)((double)originalImage.Width * a),
                        (int)((double)originalImage.Height * a),
                        _myCallback, IntPtr.Zero);
                    return resultImage2;
                }
                else
                {
                    double a = ((double)height) / (((double)originalImage.Height));
                    var resultImage2 = originalImage.GetThumbnailImage((int)((double)originalImage.Width * a),
                       (int)((double)originalImage.Height * a), _myCallback, IntPtr.Zero);
                    return resultImage2;
                }
            }
            return originalImage;

        }
        private void btnLocate_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                InitialDirectory = _setting.LabelLocation,
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textLocation.Text = dialog.FileName;
            }
        }

        private void CodeSoftLabel_Load(object sender, EventArgs e)
        {
            lblReference.Text = _referenceModel.Reference;
            lblArticle.Text = _referenceModel.ArticleNumber;
            lblLabelFile.Text = _labelType == LabelType.Individual
                ? _referenceModel.LabelTempate
                : _referenceModel.GroupingLabelTempate;
            lblTitle.Text = _labelType == LabelType.Individual ? "Individual Label" : "Grouping Label";
            textLeftOffset.Text = _leftOffset.ToString();
            textTopOffset.Text = _topOffset.ToString();
            textLocation.Text = _setting.LabelLocation;

           
            cbbPrinter.Text = _labelType == LabelType.Individual ? _setting.IndividualPrinter : _setting.GroupPrinter;
            if (!NoDocOpened && Visible)
            {
                docPreview.Image = ResizeIfNeeded(RealSizeImage, docPreview.Width, docPreview.Height);
            }

        }

        private void btnSaveOffset_Click(object sender, EventArgs e)
        {
            try
            {
                var left = Convert.ToInt32(textLeftOffset.Text);
                var top = Convert.ToInt32(textTopOffset.Text);

                _leftOffset = left;
                _topOffset = top;

                switch (_labelType)
                {
                    case LabelType.Individual:
                        _setting.LabelIndividualOffsetLeft = _leftOffset;
                        _setting.LabelIndividualOffsetTop = _topOffset;
                        _setting.Save();
                        _setting.Reload();
                        break;
                    case LabelType.Group:
                        _setting.LabelGroupOffsetLeft = _leftOffset;
                        _setting.LabelGroupOffsetTop = _topOffset;
                        _setting.Save();
                        _setting.Reload();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch
            {
                textTopOffset.Text = _topOffset.ToString();
                textLeftOffset.Text = _leftOffset.ToString();
            }

        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            _setting.LabelLocation = textLocation.Text;
            _setting.Save();
            _setting.Reload();
        }

        private void btnSavePrinter_Click(object sender, EventArgs e)
        {
            switch (_labelType)
            {
                case LabelType.Individual:
                    _setting.IndividualPrinter = cbbPrinter.Text;
                    _setting.Save();
                    _setting.Reload();
                    break;
                case LabelType.Group:
                    _setting.GroupPrinter = cbbPrinter.Text;
                    _setting.Save();
                    _setting.Reload();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _printer = cbbPrinter.Text;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!NoDocOpened && Visible)
            {
                docPreview.Image = ResizeIfNeeded(RealSizeImage,docPreview.Width, docPreview.Height);
            }
        }

        private void btnManualPrint_Click(object sender, EventArgs e)
        {
            if (!NoDocOpened)
            {
                Print();
            }
        }

        private void CodeSoftLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
