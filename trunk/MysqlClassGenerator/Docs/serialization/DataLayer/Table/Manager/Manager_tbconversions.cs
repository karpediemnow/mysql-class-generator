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
	public partial class Manager_tbconversions
	{

		#region Name incapsultation

		

	
		#endregion

		#region Constructor

		public Manager_tbconversions()
		{

        }


		#endregion

		#region public function


		/// <summary>
		/// Get the class tbconversions
		/// </summary>
		/// <param name="SourceMeasure"></param>
		/// <param name="DestinationMeasure"></param>
		/// <returns>
		/// Return the tbconversions class 
		/// </returns>
        public tbconversions getSerializetedXML_tbconversions(FileInfo FileName)
        {
            //Insert: using System.Threading;
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            tbconversions tmp = null;
            try
            {
                tmp = (tbconversions)it.furinfo.dll.Serialization.LoadXml(FileName, Type.GetType(typeof(tbconversions).FullName));
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
		/// Get all istances of tbconversions class.
		/// </summary>
		/// <returns>
		/// List of tbconversions class 
		/// </returns>
        public List<tbconversions> getListSerializedXML_tbconversions(String Path)
		{
            //Insert: using System.Threading
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            List<tbconversions> items = new List<tbconversions>();
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    FileInfo[] rgFiles = di.GetFiles("*.xml");
                    foreach (FileInfo fi in rgFiles)
                    {
                        items.Add((tbconversions)Serialization.LoadXml(fi, Type.GetType(typeof(tbconversions).FullName)));
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
		/// Insert tbconversions value into database
		/// </summary>
		/// <param name="SourceMeasure"></param>
		/// <param name="DestinationMeasure"></param>
		/// <returns>
		/// Return the number of row inserted.
		/// </returns>
		public void serializeXML_tbconversions(tbconversions varToSerlialize, FileInfo OutPutFile)
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

		/// <summary>
		/// Delete tbconversions row to database
		/// </summary>
		/// <param name="SourceMeasure"></param>
		/// <param name="DestinationMeasure"></param>
		/// <returns>
		/// Return the number of row deleted.
		/// </returns>
        public bool deleteXML_tbconversions(FileInfo OutPutFile)
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
        ///// Delete all row of tbconversions to database
        ///// </summary>
        ///// <param name="SourceMeasure"></param>
        ///// <param name="DestinationMeasure"></param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int deleteAll_tbconversions()
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM tbconversions";

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
