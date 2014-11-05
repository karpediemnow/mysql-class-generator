using System;
using System.Collections.Generic;
using System.Text;



namespace it.furinfo.pompa.DataLayer.Table.Mapping
{

	#region Delegate

	public delegate void tbmeasures_MeasureIdChangeHendler(String MeasureIdEvent);

	public delegate void tbmeasures_MeasurementIdChangeHendler(String MeasurementIdEvent);

	public delegate void tbmeasures_MeasureDescriptionChangeHendler(String MeasureDescriptionEvent);

	public delegate void tbmeasures_MeasureLabelChangeHendler(String MeasureLabelEvent);

	public delegate void tbmeasures_UsedByFormulaChangeHendler(Byte UsedByFormulaEvent);

	public delegate void tbmeasures_NotesChangeHendler(String NotesEvent);

	public delegate void tbmeasures_TimestampChangeHendler(Double TimestampEvent);

	#endregion


	/// <summary>
	/// 
	/// Personal Code
	///
	/// 
	///
	/// </summary>
    [Serializable]
	public partial class tbmeasures
	{

		#region Events

		public event tbmeasures_MeasureIdChangeHendler MeasureIdChanged;
		private void onMeasureIdChanged(String MeasureIdEvent)
		{
			if (MeasureIdChanged != null)
			{
				MeasureIdChanged(MeasureIdEvent);
			}
		}

		public event tbmeasures_MeasurementIdChangeHendler MeasurementIdChanged;
		private void onMeasurementIdChanged(String MeasurementIdEvent)
		{
			if (MeasurementIdChanged != null)
			{
				MeasurementIdChanged(MeasurementIdEvent);
			}
		}

		public event tbmeasures_MeasureDescriptionChangeHendler MeasureDescriptionChanged;
		private void onMeasureDescriptionChanged(String MeasureDescriptionEvent)
		{
			if (MeasureDescriptionChanged != null)
			{
				MeasureDescriptionChanged(MeasureDescriptionEvent);
			}
		}

		public event tbmeasures_MeasureLabelChangeHendler MeasureLabelChanged;
		private void onMeasureLabelChanged(String MeasureLabelEvent)
		{
			if (MeasureLabelChanged != null)
			{
				MeasureLabelChanged(MeasureLabelEvent);
			}
		}

		public event tbmeasures_UsedByFormulaChangeHendler UsedByFormulaChanged;
		private void onUsedByFormulaChanged(Byte UsedByFormulaEvent)
		{
			if (UsedByFormulaChanged != null)
			{
				UsedByFormulaChanged(UsedByFormulaEvent);
			}
		}

		public event tbmeasures_NotesChangeHendler NotesChanged;
		private void onNotesChanged(String NotesEvent)
		{
			if (NotesChanged != null)
			{
				NotesChanged(NotesEvent);
			}
		}

		public event tbmeasures_TimestampChangeHendler TimestampChanged;
		private void onTimestampChanged(Double TimestampEvent)
		{
			if (TimestampChanged != null)
			{
				TimestampChanged(TimestampEvent);
			}
		}

		#endregion

		#region Name encapsulation

		private  String _MeasureId;

		/// <summary>
		/// Get Set the MeasureId property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasureId
		///Comment: MeasureId identifies TblMeasures
		///Type: varchar(2)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: PRI
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String MeasureId
		{
			get
			{
				return _MeasureId;
			}
			set
			{
				_MeasureId = value;
				this.onMeasureIdChanged(this._MeasureId);
			}
		}

		private  String _MeasurementId;

		/// <summary>
		/// Get Set the MeasurementId property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasurementId
		///Comment: 
		///Type: varchar(2)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: MUL
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String MeasurementId
		{
			get
			{
				return _MeasurementId;
			}
			set
			{
				_MeasurementId = value;
				this.onMeasurementIdChanged(this._MeasurementId);
			}
		}

		private  String _MeasureDescription;

		/// <summary>
		/// Get Set the MeasureDescription property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasureDescription
		///Comment: MeasureDescription is of TblMeasures
		///Type: varchar(30)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String MeasureDescription
		{
			get
			{
				return _MeasureDescription;
			}
			set
			{
				_MeasureDescription = value;
				this.onMeasureDescriptionChanged(this._MeasureDescription);
			}
		}

		private  String _MeasureLabel;

		/// <summary>
		/// Get Set the MeasureLabel property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasureLabel
		///Comment: MeasureLabel: m/s
		///Type: varchar(8)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String MeasureLabel
		{
			get
			{
				return _MeasureLabel;
			}
			set
			{
				_MeasureLabel = value;
				this.onMeasureLabelChanged(this._MeasureLabel);
			}
		}

		private  Byte _UsedByFormula;

		/// <summary>
		/// Get Set the UsedByFormula property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: UsedByFormula
		///Comment: Measure is used in a formula
		///Type: tinyint(1) unsigned
		///Collation: 
		///Null: YES
		///Key: 
		///Default: 0
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  Byte UsedByFormula
		{
			get
			{
				return _UsedByFormula;
			}
			set
			{
				_UsedByFormula = value;
				this.onUsedByFormulaChanged(this._UsedByFormula);
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
		///Type: double unsigned
		///Collation: 
		///Null: YES
		///Key: 
		///Default: 0
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

		public tbmeasures()
		{
			
		}

		public tbmeasures(String MeasureId_Param, String MeasurementId_Param, String MeasureDescription_Param, String MeasureLabel_Param, Byte UsedByFormula_Param, String Notes_Param, Double Timestamp_Param)
		{
			#region constructor tbmeasures
			this._MeasureId = MeasureId_Param;
			this._MeasurementId = MeasurementId_Param;
			this._MeasureDescription = MeasureDescription_Param;
			this._MeasureLabel = MeasureLabel_Param;
			this._UsedByFormula = UsedByFormula_Param;
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
			this._MeasureId =  default(String);
			this._MeasurementId =  default(String);
			this._MeasureDescription =  default(String);
			this._MeasureLabel =  default(String);
			this._UsedByFormula =  default(Byte);
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
