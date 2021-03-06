// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


namespace UEDS
{
	public interface IPrimitveSerializer
	{

		List<SerializedPrimitive> Serialize(object pValue);
		object Deserialize(List<SerializedPrimitive> pValue);
		System.Type HandledType();
	}

	public class SerializedPrimitive
	{
		//public string mType;
		public string mName;
		public string mValue;

		public SerializedPrimitive(){}

		public SerializedPrimitive(string pName, object pValue)
		{
			mName = pName;
			mValue = pValue.ToString ();
			//mType = pValue.GetType().AssemblyQualifiedName;
		}

	}

	public class SerializedValue
	{
		private static Dictionary<System.Type,IPrimitveSerializer> serializers;


		public string mType;

		[XmlIgnore]
		public System.Type ValueType
		{
			get
			{
				return Type.GetType(mType);
			}
			set
			{
				mType = value.AssemblyQualifiedName;
			}
		}

		public List<SerializedPrimitive> mValues = new List<SerializedPrimitive>();

		public SerializedValue(){}




		public SerializedValue (object pValue, System.Type pType)
		{
			LoadSerializers();
			ValueType = pType;


			Serialize(pType, pValue);

		}

		void Serialize(System.Type pType, object pValue )
		{
			if(IsNumericType(pType))
				mValues = SinglePrimitive(pType, pValue);
			else if(pType == typeof(string))
				mValues = SinglePrimitive(pType, pValue);
			else if(serializers.ContainsKey(pType))
				mValues = serializers[pType].Serialize(pValue);

		}



		List<SerializedPrimitive> SinglePrimitive(System.Type pType, object pValue)
		{
			var outList = new List<SerializedPrimitive>();

			var e = new SerializedPrimitive("",pValue);
			outList.Add(e);

			return outList;
		}

		object Deserialize()
		{
			System.Type t = ValueType;
			if(IsNumericType (t))
				return ToNumericType(t, mValues[0].mValue);
			else if(t == typeof(string))
				return mValues[0].mValue;
			else if(serializers.ContainsKey(t))
				return serializers[t].Deserialize(mValues);

			return null;
		}

		void LoadSerializers()
		{
			
			if(serializers == null)
			{
				serializers = new Dictionary<Type, IPrimitveSerializer>();
				
				foreach ( var assembly in AppDomain.CurrentDomain.GetAssemblies())
				{
					foreach(var t in assembly.GetTypes())
					{
						if(!t.IsClass)
							continue;
						int idx = Array.IndexOf( t.GetInterfaces() , typeof(IPrimitveSerializer));
						if(idx != -1)
						{
							if(t == typeof(IPrimitveSerializer))
								continue;
							var instance = Activator.CreateInstance(t) as IPrimitveSerializer;



							serializers.Add(instance.HandledType() ,instance);

							Debug.Log("Serializer for " + instance.HandledType() + " found");

						}
					}
				}



			}
		}

		public object GetValue()
		{
			LoadSerializers();
			return Deserialize();
		}

		static bool IsNumericType(System.Type o)
		{   
			switch (Type.GetTypeCode(o))
			{
			case TypeCode.Byte:
			case TypeCode.SByte:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.Decimal:
			case TypeCode.Double:
			case TypeCode.Single:
				return true;
			default:
				return false;
			}
		}
		static object ToNumericType(System.Type pType, string pInput)
		{   
			switch (Type.GetTypeCode(pType))
			{
			case TypeCode.Byte:
				return Byte.Parse(pInput);
			case TypeCode.SByte:
				return SByte.Parse(pInput);
			case TypeCode.UInt16:
				return UInt16.Parse(pInput);
			case TypeCode.UInt32:
				return UInt32.Parse(pInput);
			case TypeCode.UInt64:
				return UInt64.Parse(pInput);
			case TypeCode.Int16:
				return Int16.Parse(pInput);
			case TypeCode.Int32:
				return Int32.Parse(pInput);
			case TypeCode.Int64:
				return Int64.Parse(pInput);
			case TypeCode.Decimal:
				return Decimal.Parse(pInput);
			case TypeCode.Double:
				return Double.Parse(pInput);
			case TypeCode.Single:
				return Single.Parse(pInput);
			default:
				return pInput;
			}
		}
	}
}

