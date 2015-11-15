using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CVE_ExperimentEngine
{
   class ExperimentQueue
    {
        private SqlConnection _dbConnection;

        public ExperimentQueue(SqlConnection dbConnection)
        {
            this._dbConnection = dbConnection;
            if (this._dbConnection.State == System.Data.ConnectionState.Closed)
                this._dbConnection.Open();
        }

        public ExperimentQueue(String connectionString)
        {
            this._dbConnection = new SqlConnection(connectionString);
            this._dbConnection.Open();
        }

        public void recoverExperiments()
        {
            try
            {
                SqlCommand recoverExperimentCMD = new SqlCommand("EXEC dbo.recoverExperiments", _dbConnection);
                recoverExperimentCMD.ExecuteNonQuery();
                recoverExperimentCMD.Dispose();
            }
            catch (SqlException ex)
            {
                Notification.writeError(ex.StackTrace);
            }
        }

        public bool isExperimentWaiting()
        {
            try
            {
                //check the queue
                SqlCommand checkQueueLengthCMD;
                checkQueueLengthCMD = new SqlCommand("SELECT dbo.getQueueLength()", this._dbConnection);
                SqlDataReader dataReader = checkQueueLengthCMD.ExecuteReader();
                dataReader.Read();
                int queueLength = dataReader.GetInt32(0);
                dataReader.Close();
                return (queueLength > 0);
            }
            catch (SqlException sqlEx)
            {
                Notification.writeError(sqlEx.StackTrace);
                throw sqlEx;
            }
        }

        public Experiment loadNextExperiment()
        {
            try
            {

                //Load experiment spec from database
                SqlCommand command = new SqlCommand("EXEC dbo.retrieveNextExperiment", _dbConnection);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                //ERRATA:!!!Look this up some time: why the hell was a decimal being returnd from a Sql "numeric" type? 
                String strVal = dataReader.GetValue(dataReader.GetOrdinal("Experiment_ID")).ToString();
                int experimentID = Int32.Parse(strVal);
                string experimentSpec = dataReader.GetString(dataReader.GetOrdinal("Experiment_specification"));
                dataReader.Close();
                Experiment experiment = new Experiment(experimentID, experimentSpec);
                return experiment;
            }
            catch (Exception ex)
            {
                Notification.writeError(ex.StackTrace);
            }
            return null;
        }

        public void completeExperiment(string experimentResults, int experimentID)
        {
            try
            {
                SqlCommand command = new SqlCommand("Exec dbo.completeExperiment @experimentID, @results, @warningMessage, @errorOccured, @errorMessage"
                    , this._dbConnection);
                command.Parameters.AddWithValue("@experimentID", experimentID);
                command.Parameters.AddWithValue("@results", experimentResults);
                command.Parameters.AddWithValue("@warningMessage", "");
                command.Parameters.AddWithValue("@errorOccured", false);
                command.Parameters.AddWithValue("@errorMessage", "");
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Notification.writeError(ex.StackTrace);
            }
        }
    }
}
