using System;

namespace Claudia.Utility
{
	public class GenericEventArgs<T> : EventArgs
	{
		public T Args { get; private set; }
		public GenericEventArgs(T args) => Args = args;
	}
}
