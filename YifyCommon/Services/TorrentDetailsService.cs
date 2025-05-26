using YifyCommon.Models.DataModels;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services.Contracts;

namespace YifyCommon.Services
{
    public class TorrentDetailsService : Service<TorrentDetails>, ITorrentDetailsService
    {
        public TorrentDetailsService(IRepositoryContainer<TorrentDetails> container) : base(container)
        {
        }
    }
}
