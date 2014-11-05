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
	public partial class Manager_configurations
	{

		#region Name incapsultation

		

		

		#endregion

		#region Constructor

        public Manager_configurations()
		{
		}

		
		#endregion

		#region public function


		/// <summary>
		/// Get the class configurations
		/// </summary>
		/// <param name="MeasureId">MeasureId identifies TblMeasures</param>
		/// <returns>
		/// Return the configurations class 
		/// </returns>
        public configurations getSerializetedXML_configurations(FileInfo FileName)
		{
            //Insert: using System.Threading;
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            configurations tmp = null;
            try
            {
                tmp = (configurations)Serialization.LoadXml(FileName, Type.GetType(typeof(configurations).FullName));
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
		/// Get all istances of configurations class.
		/// </summary>
		/// <returns>
		/// List of configurations class 
		/// </returns>
        public List<configurations> getListSerializetedXML_configurations(String Path)
        {
            //Insert: using System.Threading
            //Insert: using System.Globalization;
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            List<configurations> items = new List<configurations>();
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    FileInfo[] rgFiles = di.GetFiles("*.xml");
                    foreach (FileInfo fi in rgFiles)
                    {
                        items.Add((configurations)Serialization.LoadXml(fi, Type.GetType(typeof(configurations).FullName)));
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

		
        public void serializeXML_configurations(configurations varToSerlialize, FileInfo OutPutFile)
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



        public bool deleteXML_configurations(FileInfo OutPutFile)
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
        ///// Delete all row of configurations to database
        ///// </summary>
        ///// <param name="MeasureId">MeasureId identifies TblMeasures</param>
        ///// <returns>
        ///// Return the number of row deleted.
        ///// </returns>
        //public int deleteAll_configurations()
        //{
        //    int retVal = 0;
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
        //    //try
        //    //{
        //    //    String query = "DELETE FROM configurations";

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
