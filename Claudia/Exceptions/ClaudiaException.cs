using System;
using System.Runtime.Serialization;

namespace Claudia.Exceptions
{
	/// <summary>
	/// Claudia で起きた例外を管理します。
	/// </summary>
	[Serializable()]
	public class ClaudiaException : Exception
	{
		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		public ClaudiaException() : base("") { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		public ClaudiaException(string msg) : base(msg) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="inner"></param>
		public ClaudiaException(string msg, Exception inner) : base(msg, inner) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ClaudiaException(SerializationInfo info, StreamingContext context) { }

		#endregion Constructors
	}
}
