using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace ClassModellator.MysqlClassModellator.Informations
{
	/// <summary>
	/// 
    /// Classe che descrive la descrizione delle tabelle
	/// Show table status like 't1'
	///
    /// </summary>
	public class TableInformations
	{

		#region Property incapsultation

        private String _schema;

        public String Schema
        {
            get { return _schema; }
            set { _schema = value; }
        }

		private System.String _Name;

		/// <summary>
		/// 
		/// Get or Set the Name property.
		/// </summary>
		public System.String Name
		{
			get { return this._Name; }
			set { this._Name = value; }
		}

		private System.String _Engine;

		/// <summary>
		/// 
		/// Get or Set the Engine property.
		/// </summary>
		public System.String Engine
		{
			get { return this._Engine; }
			set { this._Engine = value; }
		}

		private System.Int64 _Version;

		/// <summary>
		/// 
		/// Get or Set the Version property.
		/// </summary>
		public System.Int64 Version
		{
			get { return this._Version; }
			set { this._Version = value; }
		}

		private System.String _Row_format;

		/// <summary>
		/// 
		/// Get or Set the Row_format property.
		/// </summary>
		public System.String Row_format
		{
			get { return this._Row_format; }
			set { this._Row_format = value; }
		}

		private System.Int64 _Rows;

		/// <summary>
		/// 
		/// Get or Set the Rows property.
		/// </summary>
		public System.Int64 Rows
		{
			get { return this._Rows; }
			set { this._Rows = value; }
		}

		private System.Int64 _Avg_row_length;

		/// <summary>
		/// 
		/// Get or Set the Avg_row_length property.
		/// </summary>
		public System.Int64 Avg_row_length
		{
			get { return this._Avg_row_length; }
			set { this._Avg_row_length = value; }
		}

		private System.Int64 _Data_length;

		/// <summary>
		/// 
		/// Get or Set the Data_length property.
		/// </summary>
		public System.Int64 Data_length
		{
			get { return this._Data_length; }
			set { this._Data_length = value; }
		}

		private System.Int64 _Max_data_length;

		/// <summary>
		/// 
		/// Get or Set the Max_data_length property.
		/// </summary>
		public System.Int64 Max_data_length
		{
			get { return this._Max_data_length; }
			set { this._Max_data_length = value; }
		}

		private System.Int64 _Index_length;

		/// <summary>
		/// 
		/// Get or Set the Index_length property.
		/// </summary>
		public System.Int64 Index_length
		{
			get { return this._Index_length; }
			set { this._Index_length = value; }
		}

		private System.Int64 _Data_free;

		/// <summary>
		/// 
		/// Get or Set the Data_free property.
		/// </summary>
		public System.Int64 Data_free
		{
			get { return this._Data_free; }
			set { this._Data_free = value; }
		}

		private System.Int64 _Auto_increment;

		/// <summary>
		/// 
		/// Get or Set the Auto_increment property.
		/// </summary>
		public System.Int64 Auto_increment
		{
			get { return this._Auto_increment; }
			set { this._Auto_increment = value; }
		}

		private System.DateTime _Create_time;

		/// <summary>
		/// 
		/// Get or Set the Create_time property.
		/// </summary>
		public System.DateTime Create_time
		{
			get { return this._Create_time; }
			set { this._Create_time = value; }
		}

		private System.DateTime _Update_time;

		/// <summary>
		/// 
		/// Get or Set the Update_time property.
		/// </summary>
		public System.DateTime Update_time
		{
			get { return this._Update_time; }
			set { this._Update_time = value; }
		}

		private System.DateTime _Check_time;

		/// <summary>
		/// 
		/// Get or Set the Check_time property.
		/// </summary>
		public System.DateTime Check_time
		{
			get { return this._Check_time; }
			set { this._Check_time = value; }
		}

		private System.String _Collation;

		/// <summary>
		/// 
		/// Get or Set the Collation property.
		/// </summary>
		public System.String Collation
		{
			get { return this._Collation; }
			set { this._Collation = value; }
		}

		private System.Int64 _Checksum;

		/// <summary>
		/// 
		/// Get or Set the Checksum property.
		/// </summary>
		public System.Int64 Checksum
		{
			get { return this._Checksum; }
			set { this._Checksum = value; }
		}

		private System.String _Create_options;

		/// <summary>
		/// 
		/// Get or Set the Create_options property.
		/// </summary>
		public System.String Create_options
		{
			get { return this._Create_options; }
			set { this._Create_options = value; }
		}

		private System.String _Comment;

		/// <summary>
		/// 
		/// Get or Set the Comment property.
		/// </summary>
		public System.String Comment
		{
			get { return this._Comment; }
			set { this._Comment = value; }
		}

        private List<String> _primaryKey;

        public List<String> PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        private List<String> _uniqueConstraints;

        public List<String> UniqueConstraints
        {
            get { return _uniqueConstraints; }
            set { _uniqueConstraints = value; }
        }

        private List<String> _foreignConstraints;

        public List<String> ForeignConstraints
        {
            get { return _foreignConstraints; }
            set { _foreignConstraints = value; }
        }
		#endregion

		#region Costructor

		public TableInformations()
		{
            _primaryKey = new List<string>();
            _uniqueConstraints = new List<string>();
            _foreignConstraints = new List<string>();
            
        }

        public TableInformations(MySqlDataReader reader)
		{
            _primaryKey = new List<string>();
            _uniqueConstraints = new List<string>();
            _foreignConstraints = new List<string>();
            this.setProperty(reader);
		}

		#endregion

        #region public function

        public void setProperty(MySqlDataReader reader)
        {
            this._Name = reader.GetString(reader.GetOrdinal("Name"));
            this._Engine = reader.GetString(reader.GetOrdinal("Engine"));
            this._Version = reader.GetInt64(reader.GetOrdinal("Version"));
            this._Row_format = reader.GetString(reader.GetOrdinal("Row_format"));
            if (!reader.IsDBNull(reader.GetOrdinal("Rows")))
            {
                this._Rows = reader.GetInt64(reader.GetOrdinal("Rows"));
            }
            this._Avg_row_length = reader.GetInt64(reader.GetOrdinal("Avg_row_length"));
            this._Data_length = reader.GetInt64(reader.GetOrdinal("Data_length"));
            this._Max_data_length = reader.GetInt64(reader.GetOrdinal("Max_data_length"));
            this._Index_length = reader.GetInt64(reader.GetOrdinal("Index_length"));
            this._Data_free = reader.GetInt64(reader.GetOrdinal("Data_free"));
            if (!reader.IsDBNull(reader.GetOrdinal("Auto_increment")))
            {
                this._Auto_increment = reader.GetInt64(reader.GetOrdinal("Auto_increment"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("Create_time")))
            {
                this._Create_time = reader.GetDateTime(reader.GetOrdinal("Create_time"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("Update_time")))
            {
                this._Update_time = reader.GetDateTime(reader.GetOrdinal("Update_time"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("Check_time")))
            {
                this._Check_time = reader.GetDateTime(reader.GetOrdinal("Check_time"));
            }
            this._Collation = reader.GetString(reader.GetOrdinal("Collation"));
            if (!reader.IsDBNull(reader.GetOrdinal("Checksum")))
            {
                this._Checksum = reader.GetInt64(reader.GetOrdinal("Checksum"));
            }
            this._Create_options = reader.GetString(reader.GetOrdinal("Create_options"));
            this._Comment = reader.GetString(reader.GetOrdinal("Comment"));
        }

        #endregion
    }
}
