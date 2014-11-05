using System;
using System.Collections.Generic;
using System.Text;


namespace it.furinfo.pompa.DataLayer.Table.Mapping
{

	/// <summary>
	/// MySQL Data Base Table Modellator 
	/// 
	/// Full Class Information
	/// Table Name : tbsensors
	/// Table Comment : InnoDB free: 12288 kB; (`BrandId`) REFER `job_new/tbsensorbrands`(`BrandId`); (`
	/// Table Collation : utf8_general_ci
	/// Table Create_time : 22/07/2009 13.33.30
	/// Table Engine : InnoDB
	/// Table Version : 10
	/// Table Row_format : Compact
	/// Table Rows : 0
	/// Table Avg_row_length : 0
	/// Table Data_length : 16384
	/// Table Max_data_length : 0
	/// Table Index_length : 49152
	/// Table Data_free : 0
	/// Table Auto_increment : 0
	/// Table Update_time : 01/01/0001 0.00.00
	/// Table Check_time : 01/01/0001 0.00.00
	/// Table Checksum : 0
	/// Table Create_options : 
	/// 
	/// 
	/// Create Table Statment:
	/// CREATE TABLE `tbsensors` (
	///   `SensorId` varchar(10) NOT NULL COMMENT 'SensorId',
	///   `BrandId` varchar(2) NOT NULL COMMENT 'Brand of the Sensor',
	///   `Model` varchar(15) NOT NULL COMMENT 'Model of the Sensor',
	///   `MeasurementId` varchar(2) NOT NULL COMMENT 'Measurement Type (Pressure, Flow, Lenght..)',
	///   `Signal` tinyint(3) unsigned NOT NULL COMMENT 'Signal (0=mA, 1=V, 2=Pulse ... so far)',
	///   `SignalRangeLow` double NOT NULL COMMENT 'Signal Range Low',
	///   `SignalRangeHigh` double NOT NULL COMMENT 'Signal Range High',
	///   `MeasureId` varchar(3) NOT NULL COMMENT 'Measure (Bar, Psi, mm ...)',
	///   `MeasureRangeLow` double NOT NULL COMMENT 'Misure Range Low (DEFAULT = 0)',
	///   `MeasureRangeHigh` double NOT NULL COMMENT 'Measure Range High',
	///   `OverMeasure` double NOT NULL COMMENT 'Max Measure',
	///   `MeasureError` double NOT NULL COMMENT 'Percentage of Maximum Measured Error (DEFAULT = 0)',
	///   `MeasureMeanSample` tinyint(2) unsigned NOT NULL default '1' COMMENT 'Number of samples for Mean Calculation (DEFAULT = 1)',
	///   `SignalType` tinyint(1) unsigned NOT NULL COMMENT '0=Analogic, 1=Digital',
	///   `DefaultChannel` varchar(256) NOT NULL COMMENT 'Default channel',
	///   `ConverterType` tinyint(3) unsigned NOT NULL COMMENT 'A/D Converter Type: 0=NI cFP, 1=Geo Misure Geo-JET... so on',
	///   `AvailableValue` tinyint(1) unsigned NOT NULL COMMENT '0=Raw, 1=Embedded, 2=Both',
	///   `UsingValue` tinyint(1) unsigned NOT NULL COMMENT '0=Raw, 1=Embedded',
	///   `StepValue` double NOT NULL default '0',
	///   `DecimalPlaces` tinyint(1) unsigned NOT NULL default '2' COMMENT 'Decimal places to show. Accepted values: 0, 1, 2',
	///   `GaugeMinReading` double NOT NULL,
	///   `GaugeMaxReading` double NOT NULL,
	///   `GraphMinReading` double NOT NULL,
	///   `GraphMaxReading` double NOT NULL,
	///   `AlarmMinValue` double NOT NULL,
	///   `AlarmMaxValue` double NOT NULL,
	///   `AvailableDate` tinyint(1) unsigned NOT NULL COMMENT '0=Computer, 1=Converter, 2=Both',
	///   `UsingDate` tinyint(1) unsigned NOT NULL COMMENT '0=Computer, 1=Converter',
	///   `Notes` longtext,
	///   `Timestamp` double unsigned default '0',
	///   PRIMARY KEY  (`SensorId`),
	///   KEY `FK_tbsensors_BrandId` (`BrandId`),
	///   KEY `FK_tbsensors_MeasurementId` (`MeasurementId`),
	///   KEY `FK_tbsensors_MeasureId` (`MeasureId`),
	///   CONSTRAINT `FK_tbsensors_BrandId` FOREIGN KEY (`BrandId`) REFERENCES `tbsensorbrands` (`BrandId`),
	///   CONSTRAINT `FK_tbsensors_MeasureId` FOREIGN KEY (`MeasureId`) REFERENCES `tbmeasures` (`MeasureId`),
	///   CONSTRAINT `FK_tbsensors_MeasurementId` FOREIGN KEY (`MeasurementId`) REFERENCES `tbmeasurements` (`MeasurementId`)
	/// ) ENGINE=InnoDB DEFAULT CHARSET=utf8
	///  
	/// 
	/// </summary>
    [Serializable]
	public partial class tbsensors
	{

		#region Property encapsulation

		private  String _SensorId;

		/// <summary>
		/// Get Set the SensorId property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: SensorId
		/// Comment: SensorId
		/// Type: varchar(10)
		/// Collation: utf8_general_ci
		/// Null: NO
		/// Key: PRI
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String SensorId
		{
			get { return this._SensorId; }
			set { this._SensorId = value; }
		}

		private  String _Model;

		/// <summary>
		/// Get Set the Model property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: Model
		/// Comment: Model of the Sensor
		/// Type: varchar(15)
		/// Collation: utf8_general_ci
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String Model
		{
			get { return this._Model; }
			set { this._Model = value; }
		}

		private  String _MeasurementId;

		/// <summary>
		/// Get Set the MeasurementId property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasurementId
		/// Comment: Measurement Type (Pressure, Flow, Lenght..)
		/// Type: varchar(2)
		/// Collation: utf8_general_ci
		/// Null: NO
		/// Key: MUL
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String MeasurementId
		{
			get { return this._MeasurementId; }
			set { this._MeasurementId = value; }
		}

		private  UInt32 _Signal;

		/// <summary>
		/// Get Set the Signal property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: Signal
		/// Comment: Signal (0=mA, 1=V, 2=Pulse ... so far)
		/// Type: tinyint(3) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  UInt32 Signal
		{
			get { return this._Signal; }
			set { this._Signal = value; }
		}

		private  Double _SignalRangeLow;

		/// <summary>
		/// Get Set the SignalRangeLow property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: SignalRangeLow
		/// Comment: Signal Range Low
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double SignalRangeLow
		{
			get { return this._SignalRangeLow; }
			set { this._SignalRangeLow = value; }
		}

		private  Double _SignalRangeHigh;

		/// <summary>
		/// Get Set the SignalRangeHigh property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: SignalRangeHigh
		/// Comment: Signal Range High
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double SignalRangeHigh
		{
			get { return this._SignalRangeHigh; }
			set { this._SignalRangeHigh = value; }
		}

		private  String _MeasureId;

		/// <summary>
		/// Get Set the MeasureId property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasureId
		/// Comment: Measure (Bar, Psi, mm ...)
		/// Type: varchar(3)
		/// Collation: utf8_general_ci
		/// Null: NO
		/// Key: MUL
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String MeasureId
		{
			get { return this._MeasureId; }
			set { this._MeasureId = value; }
		}

		private  Double _MeasureRangeLow;

		/// <summary>
		/// Get Set the MeasureRangeLow property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasureRangeLow
		/// Comment: Misure Range Low (DEFAULT = 0)
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double MeasureRangeLow
		{
			get { return this._MeasureRangeLow; }
			set { this._MeasureRangeLow = value; }
		}

		private  Double _MeasureRangeHigh;

		/// <summary>
		/// Get Set the MeasureRangeHigh property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasureRangeHigh
		/// Comment: Measure Range High
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double MeasureRangeHigh
		{
			get { return this._MeasureRangeHigh; }
			set { this._MeasureRangeHigh = value; }
		}

		private  Double _OverMeasure;

		/// <summary>
		/// Get Set the OverMeasure property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: OverMeasure
		/// Comment: Max Measure
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double OverMeasure
		{
			get { return this._OverMeasure; }
			set { this._OverMeasure = value; }
		}

		private  Double _MeasureError;

		/// <summary>
		/// Get Set the MeasureError property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasureError
		/// Comment: Percentage of Maximum Measured Error (DEFAULT = 0)
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double MeasureError
		{
			get { return this._MeasureError; }
			set { this._MeasureError = value; }
		}

		private  Byte _MeasureMeanSample;

		/// <summary>
		/// Get Set the MeasureMeanSample property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: MeasureMeanSample
		/// Comment: Number of samples for Mean Calculation (DEFAULT = 1)
		/// Type: tinyint(2) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 1
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte MeasureMeanSample
		{
			get { return this._MeasureMeanSample; }
			set { this._MeasureMeanSample = value; }
		}

		private  Byte _SignalType;

		/// <summary>
		/// Get Set the SignalType property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: SignalType
		/// Comment: 0=Analogic, 1=Digital
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte SignalType
		{
			get { return this._SignalType; }
			set { this._SignalType = value; }
		}

		private  String _DefaultChannel;

		/// <summary>
		/// Get Set the DefaultChannel property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: DefaultChannel
		/// Comment: Default channel
		/// Type: varchar(256)
		/// Collation: utf8_general_ci
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String DefaultChannel
		{
			get { return this._DefaultChannel; }
			set { this._DefaultChannel = value; }
		}

		private  UInt32 _ConverterType;

		/// <summary>
		/// Get Set the ConverterType property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: ConverterType
		/// Comment: A/D Converter Type: 0=NI cFP, 1=Geo Misure Geo-JET... so on
		/// Type: tinyint(3) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  UInt32 ConverterType
		{
			get { return this._ConverterType; }
			set { this._ConverterType = value; }
		}

		private  Byte _AvailableValue;

		/// <summary>
		/// Get Set the AvailableValue property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: AvailableValue
		/// Comment: 0=Raw, 1=Embedded, 2=Both
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte AvailableValue
		{
			get { return this._AvailableValue; }
			set { this._AvailableValue = value; }
		}

		private  Byte _UsingValue;

		/// <summary>
		/// Get Set the UsingValue property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: UsingValue
		/// Comment: 0=Raw, 1=Embedded
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte UsingValue
		{
			get { return this._UsingValue; }
			set { this._UsingValue = value; }
		}

		private  Double _StepValue;

		/// <summary>
		/// Get Set the StepValue property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: StepValue
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 0
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double StepValue
		{
			get { return this._StepValue; }
			set { this._StepValue = value; }
		}

		private  Byte _DecimalPlaces;

		/// <summary>
		/// Get Set the DecimalPlaces property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: DecimalPlaces
		/// Comment: Decimal places to show. Accepted values: 0, 1, 2
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 2
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte DecimalPlaces
		{
			get { return this._DecimalPlaces; }
			set { this._DecimalPlaces = value; }
		}

		private  Double _GaugeMinReading;

		/// <summary>
		/// Get Set the GaugeMinReading property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: GaugeMinReading
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double GaugeMinReading
		{
			get { return this._GaugeMinReading; }
			set { this._GaugeMinReading = value; }
		}

		private  Double _GaugeMaxReading;

		/// <summary>
		/// Get Set the GaugeMaxReading property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: GaugeMaxReading
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double GaugeMaxReading
		{
			get { return this._GaugeMaxReading; }
			set { this._GaugeMaxReading = value; }
		}

		private  Double _GraphMinReading;

		/// <summary>
		/// Get Set the GraphMinReading property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: GraphMinReading
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double GraphMinReading
		{
			get { return this._GraphMinReading; }
			set { this._GraphMinReading = value; }
		}

		private  Double _GraphMaxReading;

		/// <summary>
		/// Get Set the GraphMaxReading property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: GraphMaxReading
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double GraphMaxReading
		{
			get { return this._GraphMaxReading; }
			set { this._GraphMaxReading = value; }
		}

		private  Double _AlarmMinValue;

		/// <summary>
		/// Get Set the AlarmMinValue property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: AlarmMinValue
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double AlarmMinValue
		{
			get { return this._AlarmMinValue; }
			set { this._AlarmMinValue = value; }
		}

		private  Double _AlarmMaxValue;

		/// <summary>
		/// Get Set the AlarmMaxValue property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: AlarmMaxValue
		/// Comment: 
		/// Type: double
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double AlarmMaxValue
		{
			get { return this._AlarmMaxValue; }
			set { this._AlarmMaxValue = value; }
		}

		private  Byte _AvailableDate;

		/// <summary>
		/// Get Set the AvailableDate property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: AvailableDate
		/// Comment: 0=Computer, 1=Converter, 2=Both
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte AvailableDate
		{
			get { return this._AvailableDate; }
			set { this._AvailableDate = value; }
		}

		private  Byte _UsingDate;

		/// <summary>
		/// Get Set the UsingDate property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: UsingDate
		/// Comment: 0=Computer, 1=Converter
		/// Type: tinyint(1) unsigned
		/// Collation: 
		/// Null: NO
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Byte UsingDate
		{
			get { return this._UsingDate; }
			set { this._UsingDate = value; }
		}

        UInt16 _impulseNumber;

        public UInt16 ImpulseNumber
        {
            get { return _impulseNumber; }
            set { _impulseNumber = value; }
        }

		private  String _Notes;

		/// <summary>
		/// Get Set the Notes property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: Notes
		/// Comment: 
		/// Type: longtext
		/// Collation: utf8_general_ci
		/// Null: YES
		/// Key: 
		/// Default: 
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  String Notes
		{
			get { return this._Notes; }
			set { this._Notes = value; }
		}

		private  Double _Timestamp;

		/// <summary>
		/// Get Set the Timestamp property.
		/// </summary>
		/// <value>
		/// 
		/// Complete informations
		/// Field: Timestamp
		/// Comment: 
		/// Type: double unsigned
		/// Collation: 
		/// Null: YES
		/// Key: 
		/// Default: 0
		/// Extra: 
		/// Privileges: select,insert,update,references
		/// </value>
		public  Double Timestamp
		{
			get { return this._Timestamp; }
			set { this._Timestamp = value; }
		}

		#endregion

		#region Constructor

		public tbsensors()
		{
			
		}

        //public tbsensors(String SensorId_Param, String BrandId_Param, String Model_Param, String MeasurementId_Param, UInt32 Signal_Param, Double SignalRangeLow_Param, Double SignalRangeHigh_Param, String MeasureId_Param, Double MeasureRangeLow_Param, Double MeasureRangeHigh_Param, Double OverMeasure_Param, Double MeasureError_Param, Byte MeasureMeanSample_Param, Byte SignalType_Param, String DefaultChannel_Param, UInt32 ConverterType_Param, Byte AvailableValue_Param, Byte UsingValue_Param, Double StepValue_Param, Byte DecimalPlaces_Param, Double GaugeMinReading_Param, Double GaugeMaxReading_Param, Double GraphMinReading_Param, Double GraphMaxReading_Param, Double AlarmMinValue_Param, Double AlarmMaxValue_Param, Byte AvailableDate_Param, Byte UsingDate_Param, String Notes_Param, Double Timestamp_Param)
        //{
        //    #region constructor tbsensors
        //    this._SensorId = SensorId_Param;
        //    this._BrandId = BrandId_Param;
        //    this._Model = Model_Param;
        //    this._MeasurementId = MeasurementId_Param;
        //    this._Signal = Signal_Param;
        //    this._SignalRangeLow = SignalRangeLow_Param;
        //    this._SignalRangeHigh = SignalRangeHigh_Param;
        //    this._MeasureId = MeasureId_Param;
        //    this._MeasureRangeLow = MeasureRangeLow_Param;
        //    this._MeasureRangeHigh = MeasureRangeHigh_Param;
        //    this._OverMeasure = OverMeasure_Param;
        //    this._MeasureError = MeasureError_Param;
        //    this._MeasureMeanSample = MeasureMeanSample_Param;
        //    this._SignalType = SignalType_Param;
        //    this._DefaultChannel = DefaultChannel_Param;
        //    this._ConverterType = ConverterType_Param;
        //    this._AvailableValue = AvailableValue_Param;
        //    this._UsingValue = UsingValue_Param;
        //    this._StepValue = StepValue_Param;
        //    this._DecimalPlaces = DecimalPlaces_Param;
        //    this._GaugeMinReading = GaugeMinReading_Param;
        //    this._GaugeMaxReading = GaugeMaxReading_Param;
        //    this._GraphMinReading = GraphMinReading_Param;
        //    this._GraphMaxReading = GraphMaxReading_Param;
        //    this._AlarmMinValue = AlarmMinValue_Param;
        //    this._AlarmMaxValue = AlarmMaxValue_Param;
        //    this._AvailableDate = AvailableDate_Param;
        //    this._UsingDate = UsingDate_Param;
        //    this._Notes = Notes_Param;
        //    this._Timestamp = Timestamp_Param;
        //    #endregion
        //}

		#endregion

		#region Public Function


		/// <summary>
		/// Reset All property
		/// </summary>
		public  void reset()
		{
			this._SensorId =  default(String);
			this._Model =  default(String);
			this._MeasurementId =  default(String);
			this._Signal =  default(UInt32);
			this._SignalRangeLow =  default(Double);
			this._SignalRangeHigh =  default(Double);
			this._MeasureId =  default(String);
			this._MeasureRangeLow =  default(Double);
			this._MeasureRangeHigh =  default(Double);
			this._OverMeasure =  default(Double);
			this._MeasureError =  default(Double);
			this._MeasureMeanSample =  default(Byte);
			this._SignalType =  default(Byte);
			this._DefaultChannel =  default(String);
			this._ConverterType =  default(UInt32);
			this._AvailableValue =  default(Byte);
			this._UsingValue =  default(Byte);
			this._StepValue =  default(Double);
			this._DecimalPlaces =  default(Byte);
			this._GaugeMinReading =  default(Double);
			this._GaugeMaxReading =  default(Double);
			this._GraphMinReading =  default(Double);
			this._GraphMaxReading =  default(Double);
			this._AlarmMinValue =  default(Double);
			this._AlarmMaxValue =  default(Double);
			this._AvailableDate =  default(Byte);
			this._UsingDate =  default(Byte);
			this._Notes =  default(String);

            _showAnalogDisplayConversionUnit = default(bool);
            _showAnalogDisplayBaseUnit = default(bool);
            _showGraphConversionUnit = default(bool);
            _showGraphBaseUnit = default(bool);
            _showGaugeConversionUnit = default(bool);
            _showGaugeBaseUnit = default(Boolean);
            _impulseNumber= default(UInt16);
		}
		#endregion


        #region Graphic congigurations
        private Boolean _showGaugeBaseUnit;

        public Boolean ShowGaugeBaseUnit
        {
            get { return _showGaugeBaseUnit; }
            set { _showGaugeBaseUnit = value; }
        }

        
        private bool _showGaugeConversionUnit;

        public bool ShowGaugeConversionUnit
        {
            get { return _showGaugeConversionUnit; }
            set { _showGaugeConversionUnit = value; }
        }
        
        private bool _showGraphBaseUnit;

        public bool ShowGraphBaseUnit
        {
            get { return _showGraphBaseUnit; }
            set { _showGraphBaseUnit = value; }
        }
        
        private bool _showGraphConversionUnit;

        public bool ShowGraphConversionUnit
        {
            get { return _showGraphConversionUnit; }
            set { _showGraphConversionUnit = value; }
        }
        
        private bool _showAnalogDisplayBaseUnit;

        public bool ShowAnalogDisplayBaseUnit
        {
            get { return _showAnalogDisplayBaseUnit; }
            set { _showAnalogDisplayBaseUnit = value; }
        }
        
        private bool _showAnalogDisplayConversionUnit;

        public bool ShowAnalogDisplayConversionUnit
        {
            get { return _showAnalogDisplayConversionUnit; }
            set { _showAnalogDisplayConversionUnit = value; }
        }
        #endregion



        #region Private Function



        #endregion

    }
}
