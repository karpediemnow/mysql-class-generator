using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


using System.Globalization;
using System.Threading;
using System.Data;

using it.furinfo.pompa.DataLayer;
using it.furinfo.pompa.DataLayer.Table.Mapping;
using it.furinfo.dll;


namespace it.furinfo.pompa.DataLayer.Table.Manager
{

	/// <summary>
	/// MySQL Data Base Table Modellator 
	///
	/// 
	///
	/// </summary>
	public partial class Manager_tbmeasurements
	{

		#region Name incapsultation

		

		
		#endregion

		#region Constructor

		public Manager_tbmeasurements()
		{

		}

		#endregion

		#region public function


		/// <summary>
		/// Get the class tbmeasurements
		/// </summary>
		/// <param name="MeasurementId">MeasurementTypeId identifies TblMeasurements</param>
		/// <returns>
		/// Return the tbmeasurements class 
		/// </returns>
        public tbmeasurements getSerializetedXML_tbmeasurements(FileInfo FileName)
        {
            //Insert: using System.Threading;
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            tbmeasurements tmp = null;
            try
            {
                tmp = (tbmeasurements)it.furinfo.dll.Serialization.LoadXml(FileName, Type.GetType(typeof(tbmeasurements).FullName));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = info;
            }
            return tmp;
        }

		/// <summary>
		/// Get all istances of tbmeasurements class.
		/// </summary>
		/// <returns>
		/// List of tbmeasurements class 
		/// </returns>
        public List<tbmeasurements> getListSerializetedXML_tbmeasurements(String Path)
        {
            //Insert: using System.Threading
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            List<tbmeasurements> items = new List<tbmeasurements>();
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    FileInfo[] rgFiles = di.GetFiles("*.xml");
                    foreach (FileInfo fi in rgFiles)
                    {
                        items.Add((tbmeasurements)Serialization.LoadXml(fi, Type.GetType(typeof(tbmeasurements).FullName) ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

		/// <summary>
		/// Insert tbmeasurements value into database
		/// </summary>
		/// <param name="MeasurementId">MeasurementTypeId identifies TblMeasurements</param>
		/// <returns>
		/// Return the number of row inserted.
		/// </returns>
        public void serializeXML_tbmeasurements(tbmeasurements varToSerlialize, FileInfo OutPutFile)
        {
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                Serialization.SaveXml(varToSerlialize, OutPutFile);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = info;
            }

        }

        public bool deleteXML_tbmeasurements(FileInfo OutPutFile)
        {
            bool retVal = false;
            //try
            //{

            String fullFilePath = OutPutFile.DirectoryName + "\\" + OutPutFile.Name;
            if (Path.GetExtension(fullFilePath) != ".xml")
            {
                fullFilePath += ".xml";
            }

            if (File.Exists(fullFilePath))
            {

                File.Delete(fullFilePath);

                retVal = true;

            }
            else
            {

                Console.WriteLine("File doesnot exist");

                retVal = false;
            }
            return retVal;
        }

		
		
        ///// <summary>
        ///// Delete tbmeasurements row to database
        ///// </summary>
        ///// <param name="MeasurementId">MeasurementTypeId identifies TblMeasurements</param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int delete_tbmeasurements(tbmeasurements varToDelete)
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM tbmeasurements ";
        //    //          query += "WHERE ";
        //    //          query += "MeasurementId = @MeasurementId_Param";

        //    //    MySqlCommand command = new MySqlCommand(query, this._connection);

        //    //    command.Parameters.AddWithValue("@MeasurementId_Param", varToDelete.MeasurementId);

        //    //    command.Prepare();
        //    //    retVal = command.ExecuteNonQuery();
        //    //}
        //    //catch (MySqlException ex)
        //    //{
        //    //    throw (ex);
        //    //}
        //    //finally
        //    //{
        //    //    Thread.CurrentThread.CurrentCulture = info;
        //    //}
        //    return retVal;
        //}

        ///// <summary>
        ///// Delete all row of tbmeasurements to database
        ///// </summary>
        ///// <param name="MeasurementId">MeasurementTypeId identifies TblMeasurements</param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int deleteAll_tbmeasurements()
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM tbmeasurements";

        //    //    MySqlCommand command = new MySqlCommand(query, this._connection);

        //    //    command.Prepare();
        //    //    retVal = command.ExecuteNonQuery();
        //    //}
        //    //catch (MySqlException ex)
        //    //{
        //    //    throw (ex);
        //    //}
        //    //finally
        //    //{
        //    //    Thread.CurrentThread.CurrentCulture = info;
        //    //}
        //    return retVal;
        //}
		
        #endregion

	}
}
