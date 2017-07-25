namespace LAD08PackagingV1
{
    public class ReferenceModel
    {
        public string ArticleNumber { get; set; }
        private string _reference;
        public string Reference
        {
            get { return _reference; }
            set { _reference = value.ToUpper(); } 
        }

        public string Pokayoke { get; set; }
        public int QuantityIndividual { get; set; }
        public int QuantityGroup { get; set; }
        public int QuantityLot { get; set; }
        public string Bitmap { get; set; }
        public string English { get; set; }
        public string France { get; set; }
        public string German { get; set; }
        public string Spain { get; set; }
        public string LabelTempate { get; set; }
        public string GroupingLabelTempate { get; set; }
        public int WeighingNominal { get; set; }
        public int WeighingMinimal { get; set; }
        public int WeighingMaximal { get; set; }

        
    }
}
