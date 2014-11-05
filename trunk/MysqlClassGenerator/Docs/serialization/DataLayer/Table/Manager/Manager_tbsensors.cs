using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.Threading;
using System.Data;

using it.furinfo.pompa.DataLayer;
using it.furinfo.pompa.DataLayer.Table.Mapping;
using System.IO;
using it.furinfo.dll;

namespace it.furinfo.pompa.DataLayer.Table.Manager
{

	/// <summary>
	/// MySQL Data Base Table Modellator 
	/// 
	///  
	/// 
	/// </summary>
	public partial class Manager_tbsensors
	{
		#region Constructor

        public Manager_tbsensors()
		{
		}

		#endregion


		#region public function


		/// <summary>
		/// Get the class tbsensors
		/// </summary>
		/// <param name="SensorId">SensorId</param>
		/// <returns>
		///  return tbsensors parameter
		/// </returns>
        public tbsensors getSerializetedXML_tbsensors(FileInfo FileName)
		{
            //Insert: using System.Threading;
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            tbsensors tmp =null;
            try
            {
                tmp = (tbsensors)Serialization.LoadXml(FileName, Type.GetType(typeof(tbsensors).FullName));
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

        public List<tbsensors> getListSerializetedXML_tbsensors(String Path)
        {
            //Insert: using System.Threading
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            List<tbsensors> items = new List<tbsensors>();
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    FileInfo[] rgFiles = di.GetFiles("*.xml");
                    foreach (FileInfo fi in rgFiles)
                    {
                        items.Add((tbsensors)Serialization.LoadXml(fi, Type.GetType(typeof(tbsensors).FullName)));
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

        public void serializeXML_tbsensors(tbsensors varToSerlialize, FileInfo OutPutFile)
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



        public bool deleteXML_tbsensors(FileInfo OutPutFile)
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
        ///// Delete all row of tbsensors to database
        ///// </summary>
        ///// <param name="MeasureId">MeasureId identifies TblMeasures</param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int deleteAll_tbsensors()
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM tbsensors";

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
