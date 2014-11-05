using System;
using System.Collections.Generic;
using System.Text;



namespace it.furinfo.pompa.DataLayer.Table.Mapping
{

	#region Delegate

	public delegate void tbmeasurements_MeasurementIdChangeHendler(String MeasurementIdEvent);

	public delegate void tbmeasurements_MeasurementDescriptionChangeHendler(String MeasurementDescriptionEvent);

	public delegate void tbmeasurements_NotesChangeHendler(String NotesEvent);

	public delegate void tbmeasurements_TimestampChangeHendler(Double TimestampEvent);

	#endregion


	/// <summary>
	/// 
	/// Personal Code
	///
	/// 
	///
	/// </summary>
    [Serializable]
	public partial class tbmeasurements
	{

		#region Events

		public event tbmeasurements_MeasurementIdChangeHendler MeasurementIdChanged;
		private void onMeasurementIdChanged(String MeasurementIdEvent)
		{
			if (MeasurementIdChanged != null)
			{
				MeasurementIdChanged(MeasurementIdEvent);
			}
		}

		public event tbmeasurements_MeasurementDescriptionChangeHendler MeasurementDescriptionChanged;
		private void onMeasurementDescriptionChanged(String MeasurementDescriptionEvent)
		{
			if (MeasurementDescriptionChanged != null)
			{
				MeasurementDescriptionChanged(MeasurementDescriptionEvent);
			}
		}

		public event tbmeasurements_NotesChangeHendler NotesChanged;
		private void onNotesChanged(String NotesEvent)
		{
			if (NotesChanged != null)
			{
				NotesChanged(NotesEvent);
			}
		}

		public event tbmeasurements_TimestampChangeHendler TimestampChanged;
		private void onTimestampChanged(Double TimestampEvent)
		{
			if (TimestampChanged != null)
			{
				TimestampChanged(TimestampEvent);
			}
		}

		#endregion

		#region Name encapsulation

		private  String _MeasurementId;

		/// <summary>
		/// Get Set the MeasurementId property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasurementId
		///Comment: MeasurementTypeId identifies TblMeasurements
		///Type: varchar(2)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: PRI
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

		private  String _MeasurementDescription;

		/// <summary>
		/// Get Set the MeasurementDescription property.
		/// </summary>
		/// <value>
		/// 
		///Complete informations
		///Field: MeasurementDescription
		///Comment: MeasurementDescription is of TblMeasurements
		///Type: varchar(30)
		///Collation: utf8_general_ci
		///Null: NO
		///Key: 
		///Default: 
		///Extra: 
		///Privileges: select,insert,update,references
		/// </value>
		public  String MeasurementDescription
		{
			get
			{
				return _MeasurementDescription;
			}
			set
			{
				_MeasurementDescription = value;
				this.onMeasurementDescriptionChanged(this._MeasurementDescription);
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

		public tbmeasurements()
		{
			
		}

		public tbmeasurements(String MeasurementId_Param, String MeasurementDescription_Param, String Notes_Param, Double Timestamp_Param)
		{
			#region constructor tbmeasurements
			this._MeasurementId = MeasurementId_Param;
			this._MeasurementDescription = MeasurementDescription_Param;
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
			this._MeasurementId =  default(String);
			this._MeasurementDescription =  default(String);
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
