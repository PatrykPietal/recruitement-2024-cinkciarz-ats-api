using Ats.Core.Interfaces;

namespace Ats.Core.Models
{
	public abstract class SoftDeletable : ISoftDeletable
	{

		public bool IsDeleted { get; private set; } = false;

		public DateTime? DeletedOnUtc { get; private set; }


		public void SoftDelete()
		{
			IsDeleted = true;
			DeletedOnUtc = DateTime.UtcNow;
		}

	}
}
