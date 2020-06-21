using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using DotaSentry.Business.DataAccess;
using Microsoft.Extensions.Caching.Memory;

namespace DotaSentry.Business
{
    public class LiveMatchCacheUpdateTask
    {
        private readonly Timer _timer = new Timer(5000);
        private readonly LiveMatchRepository _liveMatchRepository;
        private readonly int[] _parentIds = {0, 1, 2, 3};
        private readonly IMemoryCache _memoryCache;
        public const string MatchCacheKey = "LiveMatches";

        public LiveMatchCacheUpdateTask(
            LiveMatchRepository liveMatchRepository,
            IMemoryCache memoryCache)
        {
            _liveMatchRepository = liveMatchRepository;
            _memoryCache = memoryCache;
        }

        public void Start()
        {
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var tasks = _parentIds.Select(parentId => _liveMatchRepository.GetAsync(parentId)).ToList();
            Task.WhenAll(tasks).GetAwaiter().GetResult();

            // simple distinct
            var matches = tasks
                .SelectMany(t => t.Result)
                .GroupBy(match => match.MatchId)
                .Select(g => g.First())
                .ToList();
            _memoryCache.Set(MatchCacheKey, matches);
        }
    }
}