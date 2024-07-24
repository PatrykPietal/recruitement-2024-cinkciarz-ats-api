namespace Ats.Core.Interfaces
{
	public interface ISoftDeletable
	{
		bool IsDeleted { get; }
		DateTime? DeletedOnUtc { get; }
		void SoftDelete();
	}
}
