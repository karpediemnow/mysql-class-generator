using System;
using System.Collections.Generic;
using System.Text;



namespace it.furinfo.pompa.DataLayer.Table.Mapping
{

	#region Delegate

	public delegate void tbconversions_SourceMeasureChangeHendler(String SourceMeasureEvent);

	public delegate void tbconversions_DestinationMeasureChangeHendler(String DestinationMeasureEvent);

	public delegate void tbconversions_ConversionValueChangeHendler(Double ConversionValueEvent);

	public delegate void tbconversions_ExponentChangeHendler(Byte ExponentEvent);

	public delegate void tbconversions_NotesChangeHendler(String NotesEvent);

	public delegate void tbconversions_TimestampChangeHendler(Double TimestampEvent);

	#endregion


	/// <summary>
	/// 
	/// Personal Code
	///
	/// 
	///
	/// </summary>

    [Serializable]
	public partial class tbconversions
	{

		#region Events

		public event tbconversions_SourceMeasureChangeHendler SourceMeasureChanged;
		private void onSourceMeasureChanged(String SourceMeasureEvent)
		{
			if (SourceMeasureChanged != null)
			{
				SourceMeasureChanged(SourceMeasureEvent);
			}
		}

		public event tbconversions_DestinationMeasureChangeHendler DestinationMeasureChanged;
		private void onDestinationMeasureChanged(String DestinationMeasureEvent)
		{
			if (DestinationMeasureChanged != null)
			{
				DestinationMeasureChanged(DestinationMeasureEvent);
			}
		}

		public event tbconversions_ConversionValueChangeHendler ConversionValueChanged;
		private void onConversionValueChanged(Double ConversionValueEvent)
		{
			if (ConversionValueChanged != null)
			{
				ConversionValueChanged(ConversionValueEvent);
			}
		}

		public event tbconversions_ExponentChangeHendler ExponentChanged;
		private void onExponentChanged(Byte ExponentEvent)
		{
			if (ExponentChanged != null)
			{
				ExponentChanged(ExponentEvent);
			}
		}

		public event tbconversions_NotesChangeHendler NotesChanged;
		private void onNotesChanged(String NotesEvent)
		{
			if (NotesChanged != null)
			{
				NotesChanged(NotesEvent);
			}
		}

		public event tbconversions_TimestampChangeHendler TimestampChanged;
		private void onTimestampChanged(Double TimestampEvent)
		{
			if (TimestampChanged != null)
			{
				TimestampChanged(TimestampEvent);
			}
		}

		#endregion

		#region Name encapsulation

		private  String _SourceMeasure;

		/// <summary>
		/// Get Set the SourceMeasure property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: SourceMeasure
		///Comment: 
		///Type: varchar(10)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: PRI
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String SourceMeasure
		{
			get
			{
				return _SourceMeasure;
			}
			set
			{
				_SourceMeasure = value;
				this.onSourceMeasureChanged(this._SourceMeasure);
			}
		}

		private  String _DestinationMeasure;

		/// <summary>
		/// Get Set the DestinationMeasure property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: DestinationMeasure
		///Comment: 
		///Type: varchar(10)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: PRI
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String DestinationMeasure
		{
			get
			{
				return _DestinationMeasure;
			}
			set
			{
				_DestinationMeasure = value;
				this.onDestinationMeasureChanged(this._DestinationMeasure);
			}
		}

		private  Double _ConversionValue;

		/// <summary>
		/// Get Set the ConversionValue property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: ConversionValue
		///Comment: SourceMeasure factor
		///Type: double
		///Collation: 
		///Null: NO
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  Double ConversionValue
		{
			get
			{
				return _ConversionValue;
			}
			set
			{
				_ConversionValue = value;
				this.onConversionValueChanged(this._ConversionValue);
			}
		}

		private  Byte _Exponent;

		/// <summary>
		/// Get Set the Exponent property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: Exponent
		///Comment: Exponent in scientific notation
		///Type: tinyint(1) unsigned
		///Collation: 
		///Null: NO
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  Byte Exponent
		{
			get
			{
				return _Exponent;
			}
			set
			{
				_Exponent = value;
				this.onExponentChanged(this._Exponent);
			}
		}

		private  String _Notes;

		/// <summary>
		/// Get Set the Notes property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: Notes
		///Comment: 
		///Type: longtext
		///Collation: utf8_general_ci
		///Null: YES
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String Notes
		{
			get
			{
				return _Notes;
			}
			set
			{
				_Notes = value;
				this.onNotesChanged(this._Notes);
			}
		}

		private  Double _Timestamp;

		/// <summary>
		/// Get Set the Timestamp property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: Timestamp
		///Comment: 
		///Type: double
		///Collation: 
		///Null: YES
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  Double Timestamp
		{
			get
			{
				return _Timestamp;
			}
			set
			{
				_Timestamp = value;
				this.onTimestampChanged(this._Timestamp);
			}
		}

		#endregion

		#region Constructor

		public tbconversions()
		{
			
		}

		public tbconversions(String SourceMeasure_Param, String DestinationMeasure_Param, Double ConversionValue_Param, Byte Exponent_Param, String Notes_Param, Double Timestamp_Param)
		{
			#region constructor tbconversions
			this._SourceMeasure = SourceMeasure_Param;
			this._DestinationMeasure = DestinationMeasure_Param;
			this._ConversionValue = ConversionValue_Param;
			this._Exponent = Exponent_Param;
			this._Notes = Notes_Param;
			this._Timestamp = Timestamp_Param;
			#endregion
		}

		

		#endregion

		#region Public Function


		/// <summary>
		/// Reset All property
		/// </summary>
		public  void reset()
		{
			this._SourceMeasure =  default(String);
			this._DestinationMeasure =  default(String);
			this._ConversionValue =  default(Double);
			this._Exponent =  default(Byte);
			this._Notes =  default(String);
			
		}
		#endregion

		#region Private Function
		// 
		// Please NOT Modify this file use Personal Code Class.
		// 
		#endregion

	}
}
