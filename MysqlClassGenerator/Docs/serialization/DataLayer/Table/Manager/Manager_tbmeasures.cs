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
	public partial class Manager_tbmeasures
	{

		#region Name incapsultation

		

		

		#endregion

		#region Constructor

		public Manager_tbmeasures()
		{
		}

		
		#endregion

		#region public function


		/// <summary>
		/// Get the class tbmeasures
		/// </summary>
		/// <param name="MeasureId">MeasureId identifies TblMeasures</param>
		/// <returns>
		/// Return the tbmeasures class 
		/// </returns>
        public tbmeasures getSerializetedXML_tbmeasures(FileInfo FileName)
		{
            //Insert: using System.Threading;
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            tbmeasures tmp =null;
            try
            {
                tmp = (tbmeasures)Serialization.LoadXml(FileName, Type.GetType(typeof(tbmeasures).FullName) );
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
		/// Get all istances of tbmeasures class.
		/// </summary>
		/// <returns>
		/// List of tbmeasures class 
		/// </returns>
        public List<tbmeasures> getListSerializedXML_tbmeasures(String Path)
        {
            //Insert: using System.Threading
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            List<tbmeasures> items = new List<tbmeasures>();
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    FileInfo[] rgFiles = di.GetFiles("*.xml");
                    foreach (FileInfo fi in rgFiles)
                    {
                        items.Add((tbmeasures)Serialization.LoadXml(fi, Type.GetType(typeof(tbmeasures).FullName)));
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

		
        public void serializeXML_tbmeasures(tbmeasures varToSerlialize, FileInfo OutPutFile)
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



        public bool deleteXML_tbmeasures(FileInfo OutPutFile)
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
        ///// Delete all row of tbmeasures to database
        ///// </summary>
        ///// <param name="MeasureId">MeasureId identifies TblMeasures</param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int deleteAll_tbmeasures()
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM tbmeasures";

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
