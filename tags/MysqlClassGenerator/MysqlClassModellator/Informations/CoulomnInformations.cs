using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

using ClassModellator;

namespace ClassModellator.MysqlClassModellator.Informations
{
	/// <summary>
	/// MySQL Data Base Table Modellator 
    /// SHOW FULL COLUMNS FROM
	/// </summary>
	public class CoulomnInformations
	{

		#region Property incapsultation

		private System.String _Field;

		/// <summary>
		/// 
		/// Get or Set the Field property.
		/// </summary>
		public System.String Field
		{
			get { return this._Field; }
			set { this._Field = value; }
		}

		private System.String _Type;

		/// <summary>
		/// 
		/// Get or Set the Type property.
		/// </summary>
		public System.String Type
		{
			get { return this._Type; }
			set { this._Type = value; }
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

		private System.String _Null;

		/// <summary>
		/// 
		/// Get or Set the Null property.
		/// </summary>
		public System.String Null
		{
			get { return this._Null; }
			set { this._Null = value; }
		}

		private System.String _Key;

		/// <summary>
		/// 
		/// Get or Set the Key property.
		/// </summary>
		public System.String Key
		{
			get { return this._Key; }
			set { this._Key = value; }
		}

		private System.String _Default;

		/// <summary>
		/// 
		/// Get or Set the Default property.
		/// </summary>
		public System.String Default
		{
			get { return this._Default; }
			set { this._Default = value; }
		}

		private System.String _Extra;

		/// <summary>
		/// 
		/// Get or Set the Extra property.
		/// </summary>
		public System.String Extra
		{
			get { return this._Extra; }
			set { this._Extra = value; }
		}

		private System.String _Privileges;

		/// <summary>
		/// 
		/// Get or Set the Privileges property.
		/// </summary>
		public System.String Privileges
		{
			get { return this._Privileges; }
			set { this._Privileges = value; }
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

		#endregion

		#region Costructor

		public CoulomnInformations()
		{
			
		}

        public CoulomnInformations(MySqlDataReader reader)
		{
			this._Field = reader.GetString(reader.GetOrdinal("Field"));
			this._Type = reader.GetString(reader.GetOrdinal("Type"));
            if (!reader.IsDBNull(reader.GetOrdinal("Collation")))
            {
                this._Collation = reader.GetString(reader.GetOrdinal("Collation"));
            }

            this._Null = reader.GetString(reader.GetOrdinal("Null"));
			this._Key = reader.GetString(reader.GetOrdinal("Key"));
            if (!reader.IsDBNull(reader.GetOrdinal("Default")))
            {
                this._Default = reader.GetString(reader.GetOrdinal("Default"));
            }
            this._Extra = reader.GetString(reader.GetOrdinal("Extra"));
			this._Privileges = reader.GetString(reader.GetOrdinal("Privileges"));
			this._Comment = reader.GetString(reader.GetOrdinal("Comment"));
		}


       
		#endregion

	}
}
