using System;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;

namespace VVVV.Pack.Game.Base
{
	/// <summary>
	/// Description of BundleOSCNode.
	/// </summary>
	[Serializable]
	public class SpreadList : ArrayList, ISerializable
	{
        
        public Type SpreadType {
			get {
				if (this.Count == 0) return typeof(object);
					else return this[0].GetType();
			}
		}
		
		public SpreadList() : base()
		{
		}
		
		//		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			for (int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(CultureInfo.InvariantCulture), this[i]);
				
			}
		}
		
		public void AssignFrom(IEnumerable source) {
			
			foreach (object o in source) {
				this.Add(o);
			}
			
		}
		
		public new SpreadList Clone() {
			SpreadList c = new SpreadList();
			c.AssignFrom(this);
			return c;
		}
	}

}
