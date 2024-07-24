using System.Reflection;

namespace Ats.Infrastructure
{
	internal class ApplicationAssemblyReference
	{
		internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
	}
}
