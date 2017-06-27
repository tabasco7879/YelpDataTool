﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeatureBuilder
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="yelp2")]
	public partial class ReviewDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttrain_set(train_set instance);
    partial void Updatetrain_set(train_set instance);
    partial void Deletetrain_set(train_set instance);
    partial void Inserttoken(token instance);
    partial void Updatetoken(token instance);
    partial void Deletetoken(token instance);
    partial void Inserttopic_feature(topic_feature instance);
    partial void Updatetopic_feature(topic_feature instance);
    partial void Deletetopic_feature(topic_feature instance);
    partial void Insertreview(review instance);
    partial void Updatereview(review instance);
    partial void Deletereview(review instance);
    partial void Insertvocab_new(vocab_new instance);
    partial void Updatevocab_new(vocab_new instance);
    partial void Deletevocab_new(vocab_new instance);
    #endregion
		
		public ReviewDBDataContext() : 
				base(global::FeatureBuilder.Properties.Settings.Default.yelp2ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<review_sentence> review_sentences
		{
			get
			{
				return this.GetTable<review_sentence>();
			}
		}
		
		public System.Data.Linq.Table<train_set> train_sets
		{
			get
			{
				return this.GetTable<train_set>();
			}
		}
		
		public System.Data.Linq.Table<token> tokens
		{
			get
			{
				return this.GetTable<token>();
			}
		}
		
		public System.Data.Linq.Table<topic_feature_norm> topic_feature_norms
		{
			get
			{
				return this.GetTable<topic_feature_norm>();
			}
		}
		
		public System.Data.Linq.Table<topic_feature> topic_features
		{
			get
			{
				return this.GetTable<topic_feature>();
			}
		}
		
		public System.Data.Linq.Table<review> reviews
		{
			get
			{
				return this.GetTable<review>();
			}
		}
		
		public System.Data.Linq.Table<vocab_new> vocab_news
		{
			get
			{
				return this.GetTable<vocab_new>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.review_sentence")]
	public partial class review_sentence
	{
		
		private string _review_id;
		
		private int _sentence_id;
		
		private string _sentence_text;
		
		private string _sentence_pos;
		
		private string _sentence_lemma;
		
		public review_sentence()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_review_id", DbType="NVarChar(22) NOT NULL", CanBeNull=false)]
		public string review_id
		{
			get
			{
				return this._review_id;
			}
			set
			{
				if ((this._review_id != value))
				{
					this._review_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sentence_id", DbType="Int NOT NULL")]
		public int sentence_id
		{
			get
			{
				return this._sentence_id;
			}
			set
			{
				if ((this._sentence_id != value))
				{
					this._sentence_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sentence_text", DbType="NVarChar(MAX)")]
		public string sentence_text
		{
			get
			{
				return this._sentence_text;
			}
			set
			{
				if ((this._sentence_text != value))
				{
					this._sentence_text = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sentence_pos", DbType="NVarChar(MAX)")]
		public string sentence_pos
		{
			get
			{
				return this._sentence_pos;
			}
			set
			{
				if ((this._sentence_pos != value))
				{
					this._sentence_pos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sentence_lemma", DbType="NVarChar(MAX)")]
		public string sentence_lemma
		{
			get
			{
				return this._sentence_lemma;
			}
			set
			{
				if ((this._sentence_lemma != value))
				{
					this._sentence_lemma = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.train_set")]
	public partial class train_set : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _review_id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onreview_idChanging(string value);
    partial void Onreview_idChanged();
    #endregion
		
		public train_set()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_review_id", DbType="NVarChar(22) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string review_id
		{
			get
			{
				return this._review_id;
			}
			set
			{
				if ((this._review_id != value))
				{
					this.Onreview_idChanging(value);
					this.SendPropertyChanging();
					this._review_id = value;
					this.SendPropertyChanged("review_id");
					this.Onreview_idChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.token")]
	public partial class token : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _token_str;
		
		private int _token_id;
		
		private string _token_pos;
		
		private int _token_freq;
		
		private int _token_doc_freq;
		
		private System.Nullable<double> _token_score;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontoken_strChanging(string value);
    partial void Ontoken_strChanged();
    partial void Ontoken_idChanging(int value);
    partial void Ontoken_idChanged();
    partial void Ontoken_posChanging(string value);
    partial void Ontoken_posChanged();
    partial void Ontoken_freqChanging(int value);
    partial void Ontoken_freqChanged();
    partial void Ontoken_doc_freqChanging(int value);
    partial void Ontoken_doc_freqChanged();
    partial void Ontoken_scoreChanging(System.Nullable<double> value);
    partial void Ontoken_scoreChanged();
    #endregion
		
		public token()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_str", DbType="NVarChar(500)")]
		public string token_str
		{
			get
			{
				return this._token_str;
			}
			set
			{
				if ((this._token_str != value))
				{
					this.Ontoken_strChanging(value);
					this.SendPropertyChanging();
					this._token_str = value;
					this.SendPropertyChanged("token_str");
					this.Ontoken_strChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int token_id
		{
			get
			{
				return this._token_id;
			}
			set
			{
				if ((this._token_id != value))
				{
					this.Ontoken_idChanging(value);
					this.SendPropertyChanging();
					this._token_id = value;
					this.SendPropertyChanged("token_id");
					this.Ontoken_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_pos", DbType="NVarChar(50)")]
		public string token_pos
		{
			get
			{
				return this._token_pos;
			}
			set
			{
				if ((this._token_pos != value))
				{
					this.Ontoken_posChanging(value);
					this.SendPropertyChanging();
					this._token_pos = value;
					this.SendPropertyChanged("token_pos");
					this.Ontoken_posChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_freq", DbType="Int NOT NULL")]
		public int token_freq
		{
			get
			{
				return this._token_freq;
			}
			set
			{
				if ((this._token_freq != value))
				{
					this.Ontoken_freqChanging(value);
					this.SendPropertyChanging();
					this._token_freq = value;
					this.SendPropertyChanged("token_freq");
					this.Ontoken_freqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_doc_freq", DbType="Int NOT NULL")]
		public int token_doc_freq
		{
			get
			{
				return this._token_doc_freq;
			}
			set
			{
				if ((this._token_doc_freq != value))
				{
					this.Ontoken_doc_freqChanging(value);
					this.SendPropertyChanging();
					this._token_doc_freq = value;
					this.SendPropertyChanged("token_doc_freq");
					this.Ontoken_doc_freqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_score", DbType="Float")]
		public System.Nullable<double> token_score
		{
			get
			{
				return this._token_score;
			}
			set
			{
				if ((this._token_score != value))
				{
					this.Ontoken_scoreChanging(value);
					this.SendPropertyChanging();
					this._token_score = value;
					this.SendPropertyChanged("token_score");
					this.Ontoken_scoreChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.topic_feature_norm")]
	public partial class topic_feature_norm
	{
		
		private int _token_id;
		
		private int _total_feature;
		
		private int _total_token;
		
		public topic_feature_norm()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_id", DbType="Int NOT NULL")]
		public int token_id
		{
			get
			{
				return this._token_id;
			}
			set
			{
				if ((this._token_id != value))
				{
					this._token_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total_feature", DbType="Int NOT NULL")]
		public int total_feature
		{
			get
			{
				return this._total_feature;
			}
			set
			{
				if ((this._total_feature != value))
				{
					this._total_feature = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total_token", DbType="Int NOT NULL")]
		public int total_token
		{
			get
			{
				return this._total_token;
			}
			set
			{
				if ((this._total_token != value))
				{
					this._total_token = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.topic_feature")]
	public partial class topic_feature : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _vocab_id1;
		
		private int _vocab_id2;
		
		private int _feature_id;
		
		private int _feature_freq;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onvocab_id1Changing(int value);
    partial void Onvocab_id1Changed();
    partial void Onvocab_id2Changing(int value);
    partial void Onvocab_id2Changed();
    partial void Onfeature_idChanging(int value);
    partial void Onfeature_idChanged();
    partial void Onfeature_freqChanging(int value);
    partial void Onfeature_freqChanged();
    #endregion
		
		public topic_feature()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vocab_id1", DbType="Int NOT NULL")]
		public int vocab_id1
		{
			get
			{
				return this._vocab_id1;
			}
			set
			{
				if ((this._vocab_id1 != value))
				{
					this.Onvocab_id1Changing(value);
					this.SendPropertyChanging();
					this._vocab_id1 = value;
					this.SendPropertyChanged("vocab_id1");
					this.Onvocab_id1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vocab_id2", DbType="Int NOT NULL")]
		public int vocab_id2
		{
			get
			{
				return this._vocab_id2;
			}
			set
			{
				if ((this._vocab_id2 != value))
				{
					this.Onvocab_id2Changing(value);
					this.SendPropertyChanging();
					this._vocab_id2 = value;
					this.SendPropertyChanged("vocab_id2");
					this.Onvocab_id2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int feature_id
		{
			get
			{
				return this._feature_id;
			}
			set
			{
				if ((this._feature_id != value))
				{
					this.Onfeature_idChanging(value);
					this.SendPropertyChanging();
					this._feature_id = value;
					this.SendPropertyChanged("feature_id");
					this.Onfeature_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_feature_freq", DbType="Int NOT NULL")]
		public int feature_freq
		{
			get
			{
				return this._feature_freq;
			}
			set
			{
				if ((this._feature_freq != value))
				{
					this.Onfeature_freqChanging(value);
					this.SendPropertyChanging();
					this._feature_freq = value;
					this.SendPropertyChanged("feature_freq");
					this.Onfeature_freqChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.review")]
	public partial class review : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _review_id;
		
		private string _user_id;
		
		private string _business_id;
		
		private string _text;
		
		private System.Nullable<decimal> _stars;
		
		private string _type;
		
		private System.Nullable<System.DateTime> _date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onreview_idChanging(string value);
    partial void Onreview_idChanged();
    partial void Onuser_idChanging(string value);
    partial void Onuser_idChanged();
    partial void Onbusiness_idChanging(string value);
    partial void Onbusiness_idChanged();
    partial void OntextChanging(string value);
    partial void OntextChanged();
    partial void OnstarsChanging(System.Nullable<decimal> value);
    partial void OnstarsChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    #endregion
		
		public review()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_review_id", DbType="NChar(22) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string review_id
		{
			get
			{
				return this._review_id;
			}
			set
			{
				if ((this._review_id != value))
				{
					this.Onreview_idChanging(value);
					this.SendPropertyChanging();
					this._review_id = value;
					this.SendPropertyChanged("review_id");
					this.Onreview_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="NChar(22)")]
		public string user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_business_id", DbType="NChar(22)")]
		public string business_id
		{
			get
			{
				return this._business_id;
			}
			set
			{
				if ((this._business_id != value))
				{
					this.Onbusiness_idChanging(value);
					this.SendPropertyChanging();
					this._business_id = value;
					this.SendPropertyChanged("business_id");
					this.Onbusiness_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_text", DbType="NVarChar(MAX)")]
		public string text
		{
			get
			{
				return this._text;
			}
			set
			{
				if ((this._text != value))
				{
					this.OntextChanging(value);
					this.SendPropertyChanging();
					this._text = value;
					this.SendPropertyChanged("text");
					this.OntextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stars", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> stars
		{
			get
			{
				return this._stars;
			}
			set
			{
				if ((this._stars != value))
				{
					this.OnstarsChanging(value);
					this.SendPropertyChanging();
					this._stars = value;
					this.SendPropertyChanged("stars");
					this.OnstarsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="NVarChar(20)")]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="Date")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vocab_new")]
	public partial class vocab_new : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _vocab_id;
		
		private int _token_id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onvocab_idChanging(int value);
    partial void Onvocab_idChanged();
    partial void Ontoken_idChanging(int value);
    partial void Ontoken_idChanged();
    #endregion
		
		public vocab_new()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vocab_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int vocab_id
		{
			get
			{
				return this._vocab_id;
			}
			set
			{
				if ((this._vocab_id != value))
				{
					this.Onvocab_idChanging(value);
					this.SendPropertyChanging();
					this._vocab_id = value;
					this.SendPropertyChanged("vocab_id");
					this.Onvocab_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token_id", DbType="Int NOT NULL")]
		public int token_id
		{
			get
			{
				return this._token_id;
			}
			set
			{
				if ((this._token_id != value))
				{
					this.Ontoken_idChanging(value);
					this.SendPropertyChanging();
					this._token_id = value;
					this.SendPropertyChanged("token_id");
					this.Ontoken_idChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591