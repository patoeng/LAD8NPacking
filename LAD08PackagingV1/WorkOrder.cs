using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LAD08PackagingV1
{
    public class WorkOrder
    {
        private string _databaseConnection;

        public WorkOrder()
        {
            
        }
        public WorkOrder(string database, string provider)
        {
            _databaseConnection = "Provider =" +provider  + "; Data Source =" + database + ";";
        }

        public WorkOrder(string database, string provider, string prodOrderNumber, string reference, int quantityTarget)
        {
            _databaseConnection = "Provider =" + provider + "; Data Source =" + database + ";";

            var data = GetByWorkOrderNumber(prodOrderNumber);

            if (data.ProdOrderNumber == null)
            {
                data.ProdOrderNumber = prodOrderNumber;
                data.Reference = reference;
                data.QuantityTarget = quantityTarget;

                data = InsertNew(data);               
            }
            ProdOrderNumber = data.ProdOrderNumber;
            Reference = data.Reference;
            QuantityTarget = data.QuantityTarget;
            QuantityPass = data.QuantityPass;
            QuantityReject = data.QuantityReject;
            StartDate = data.StartDate;
        }

        public string ProdOrderNumber { get; protected set; }
        public string Reference { get; protected set; }
        public DateTime StartDate { get; protected set; }

        public int QuantityTarget { get; protected set; }
        public int QuantityPass { get; protected set; }
        public int QuantityReject { get; protected set; }

        public void SetQuantityPass(int value)
        {
            QuantityPass = value;
            UpdatePassQuantity(this);
        }

        public void SetQuantityReject(int value)
        {
            QuantityReject = value;
            UpdateRejectQuantity(this);
        }

        public void IncreaseQuantityPass(int value)
        {
            QuantityPass += value;
            UpdatePassQuantity(this);
        }

        public void IncreaseQuantityReject(int value)
        {
            QuantityReject += value;
            UpdateRejectQuantity(this);
        }

        public void DecreaseQuantityPass(int value)
        {
            QuantityPass -= value;
            UpdatePassQuantity(this);
        }

        public void DecreaseQuantityReject(int value)
        {
            QuantityReject -= value;
            UpdateRejectQuantity(this);
        }

        public void SetDatabaseConnection(string data)
        {
            _databaseConnection = data;
        }
        private WorkOrder InsertNew(WorkOrder work)
        {
            var emptyWorkOrder = new WorkOrder();
            if (work.ProdOrderNumber == "") return emptyWorkOrder;

            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;

                var queryString = "Insert into WorkorderLAD8N (WorkOrder,Reference,StartDateTime,TargetQuantity) Values (@1,@2,@3,@4)";

                OleDbCommand command = new OleDbCommand(queryString, myConnection);
                try
                {
                    command.Connection.Open();
                }
                catch
                {
                    MessageBox.Show(@"Error Loading Database");
                }

                command.Parameters.AddWithValue("@1", work.ProdOrderNumber);
                command.Parameters.AddWithValue("@2", work.Reference);
                command.Parameters.AddWithValue("@3", DateTime.Now.ToString("O"));
                command.Parameters.AddWithValue("@4", work.QuantityTarget);
                try
                {
                    var exec = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch
                {
                    return emptyWorkOrder;
                }              
               
            }
            var data = GetByWorkOrderNumber(work.ProdOrderNumber);
            return data;
        }

        public  void UpdatePassQuantity(WorkOrder work)
        {
            if (work.ProdOrderNumber == "") return ;

            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;

                var queryString = "Update WorkorderLAD8N SET PassQuantity=@1 where WorkOrder=@2";

                OleDbCommand command = new OleDbCommand(queryString, myConnection);
                command.Connection.Open();

                command.Parameters.AddWithValue("@1", work.QuantityPass);
                command.Parameters.AddWithValue("@2", work.ProdOrderNumber);

                try
                {
                    var exec = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch
                {
                    // ignored
                }
            }
        }
        public void UpdateRejectQuantity(WorkOrder work)
        {
            if (work.ProdOrderNumber == "") return;

            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;

                var queryString = "Update WorkorderLAD8N SET RejectQuantity=@1 where WorkOrder=@2";

                OleDbCommand command = new OleDbCommand(queryString, myConnection);
                try
                {
                    command.Connection.Open();
                }
                catch
                {
                    MessageBox.Show(@"Error Loading Database");
                }

                command.Parameters.AddWithValue("@1", work.QuantityReject);
                command.Parameters.AddWithValue("@2", work.ProdOrderNumber);

                try
                {
                    var exec = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch
                {
                    // ignored
                }
            }
        }
        public WorkOrder GetByWorkOrderNumber(string workordernumber)
        {
            var emptyWorkOrder = new WorkOrder();
            if (workordernumber == "") return emptyWorkOrder;

            using (OleDbConnection myConnection = new OleDbConnection())
            {
                myConnection.ConnectionString = _databaseConnection;
                var queryString = "select * from WorkorderLAD8N where workorder='" + workordernumber + "'";

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
                if (reader == null) return emptyWorkOrder;
                if (reader.Read())
                {
                    emptyWorkOrder.ProdOrderNumber = reader[1].ToString();
                    emptyWorkOrder.Reference = reader[2].ToString();
                    emptyWorkOrder.StartDate = Convert.ToDateTime(reader[3].ToString());
                    emptyWorkOrder.QuantityTarget = Convert.ToInt32(reader[4].ToString());
                    emptyWorkOrder.QuantityPass = Convert.ToInt32(reader[5].ToString());
                    emptyWorkOrder.QuantityReject = Convert.ToInt32(reader[6].ToString());

                    emptyWorkOrder.SetDatabaseConnection(_databaseConnection);
                    command.Connection.Close();
                    return emptyWorkOrder;
                }
                command.Connection.Close();
            }
            return emptyWorkOrder;
        }
        public static WorkOrder Load(string database, string provider, string workordernumber)
        {
            var data = new WorkOrder(database,provider);
            data = data.GetByWorkOrderNumber(workordernumber);
            return data;
        }
    }
}
