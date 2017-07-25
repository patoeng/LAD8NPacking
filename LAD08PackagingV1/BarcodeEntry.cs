using System;
using LAD08PackagingV1.Properties;

namespace LAD08PackagingV1
{
    public delegate void StringBarcodeDelegate(string data, BarcodeState state);

    public delegate void BarcodeStateDelegate(BarcodeState state);
    public class BarcodeEntry
    {
        public event BarcodeStateDelegate BarcodeStateChanged;
        public event StringBarcodeDelegate BarcodeDataUpdated;
        private BarcodeState _state;
        private Settings _settings = new Settings();
        public BarcodeState State
        {
            get { return _state; }
            set
            {
                if (_state == value) return;
                _state = value;
                BarcodeStateChanged?.Invoke(_state);
            }
        }

        public string Read(string data)
        {
            data = data.Trim('\r', '\n');
            if (data == "") return "";
            switch (_state)
            {
                case BarcodeState.None:
                    break;
                case BarcodeState.ReadReference:
                    if (data.Length <5) return "";
                    var jj = data.IndexOf(@"LAD8", StringComparison.Ordinal);
                       if (jj!=0) jj= data.IndexOf(@"W", StringComparison.Ordinal);
                    if (jj != 0) return "";
                    break;
                case BarcodeState.ReadTarget:
                    if (data.Length != 6) return "";
                    try
                    {
                        var datas = Convert.ToInt32(data);
                    }
                    catch
                    {
                        return "";
                    }
                    break;
                case BarcodeState.ReadWorkOrder:
                    if (data.Length != 10) return "";
                    break;
                case BarcodeState.ReadPastedLabel:
                    if (data.Length != _settings.ArticleNumberLength) return "";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            BarcodeDataUpdated?.Invoke(data,State);
            return data;
        }
    }
}
