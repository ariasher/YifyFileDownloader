namespace YifyCommon.Models.DataModels.Contracts
{
    public interface IModel
    {
        long Id { get; set; }

        bool? IsActive { get; set; }

        DateTime? DeletedAt { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
