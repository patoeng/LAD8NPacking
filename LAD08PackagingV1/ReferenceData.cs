using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LAD08PackagingV1
{
    public  class ReferenceDataMicrosoftAccess : IReferenceData,IDisposable
    { 
        private readonly string _databaseConnection;
        public ReferenceModel Reference { get; protected set; }
        public ReferenceDataMicrosoftAccess(string database, string provider)
        {
            _databaseConnection = "Provider ="+provider+"; Data Source =" + database + ";";
        }

        public bool IsLoaded { get; protected set; }
        public bool LoadByReferenceName(string reference)
        {
            if (Reference != null)
                throw new Exception("Unable To Load Reference, Current Reference Is not Closed!");
            if (reference == "") return false;
 
            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;
                var queryString = "select * from LAD8N where Reference='" + reference + "'";

                OleDbCommand command = new OleDbCommand(queryString, myConnection);
                try
                {
                    command.Connection.Open();
                }
                catch
                {
                    MessageBox.Show(@"Error Loading Database");
                }
                OleDbDataReader reader = command.ExecuteReader();
                if (reader == null) return false;
                if (reader.Read())
                {
                    Reference = new ReferenceModel
                    {
                        ArticleNumber = reader[0].ToString(),
                        Reference = reader[1].ToString(),
                        Pokayoke = reader[10].ToString(),
                        QuantityGroup =
                            Convert.ToInt32(reader[9].ToString().Trim() == "" ? "0" : reader[9].ToString().Trim()),
                        QuantityIndividual =
                            Convert.ToInt32(reader[8].ToString().Trim() == "" ? "0" : reader[8].ToString().Trim()),
                        QuantityLot =
                            Convert.ToInt32(reader[11].ToString().Trim() == "" ? "0" : reader[11].ToString().Trim()),
                        Bitmap = reader[2].ToString(),
                        English = reader[3].ToString(),
                        France = reader[4].ToString(),
                        German = reader[5].ToString(),
                        Spain = reader[6].ToString(),
                        LabelTempate = reader[7].ToString(),
                        GroupingLabelTempate = reader[15].ToString(),
                        WeighingNominal =
                            Convert.ToInt32(reader[12].ToString().Trim() == "" ? "0" : reader[12].ToString().Trim()),
                        WeighingMinimal =
                            Convert.ToInt32(reader[13].ToString().Trim() == "" ? "0" : reader[13].ToString().Trim()),
                        WeighingMaximal =
                            Convert.ToInt32(reader[14].ToString().Trim() == "" ? "0" : reader[14].ToString().Trim())
                    };
                }
                else
                {
                    return false;
                }
            }
            IsLoaded = true;
            ReferenceDataIsLoaded?.Invoke(Reference);
            return true;
        }

        public void Unload()
        {
            IsLoaded = false;
            Reference = null;
            ReferenceDataIsUnloaded?.Invoke();
        }

        public event ReferenceDataEventDelegate ReferenceDataIsLoaded;
        public event ReferenceDataCloseDelegate ReferenceDataIsUnloaded;

        public bool UpdateLimits(ReferenceModel reference)
        {
            if (reference == null)
                throw new Exception("Unable To Update Reference, Current Reference null");
            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;
                var queryString = "update LAD8N SET Weighing_Nominal= @a,Weighing_Minimum=@b,Weighing_Maximum=@c where Reference=@d";
                try
                {
                    OleDbCommand command = new OleDbCommand(queryString, myConnection);
                    command.Parameters.AddWithValue("@a", reference.WeighingNominal);
                    command.Parameters.AddWithValue("@b", reference.WeighingMinimal);
                    command.Parameters.AddWithValue("@c", reference.WeighingMaximal);
                    command.Parameters.AddWithValue("@d", reference.Reference);

                    command.Connection.Open();
                    var exec = command.ExecuteNonQuery();
                    command.Connection.Close();
                    command.Dispose();
                    return true;

                }
                catch(Exception e)
                {// ignored
                    MessageBox.Show(e.ToString());
                }
            }
            return false;
        }

        public void Dispose()
        {
        }
    }

    public delegate void ReferenceDataEventDelegate(ReferenceModel model);

    public delegate void ReferenceDataCloseDelegate();

    public interface IReferenceData
    {
        bool LoadByReferenceName(string reference);
        void Unload();
        bool IsLoaded { get; }
        bool UpdateLimits(ReferenceModel reference);

        ReferenceModel Reference { get; }

        event ReferenceDataEventDelegate ReferenceDataIsLoaded;
        event ReferenceDataCloseDelegate ReferenceDataIsUnloaded;
    }
}
