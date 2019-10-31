using System;
using System.Collections.Generic;
using System.Linq;

using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.Helpers;
using CMS.SiteProvider;

namespace DancingGoat.Repositories.Implementation
{
    /// <summary>
    /// Represents a collection of articles.
    /// </summary>
    public class KenticoArticleRepository : IArticleRepository
    {
        private readonly string mCultureName;
        private readonly bool mLatestVersionEnabled;


        /// <summary>
        /// Initializes a new instance of the <see cref="KenticoArticleRepository"/> class that returns articles in the specified language.
        /// If the requested article doesn't exist in specified language then its default culture version is returned.
        /// </summary>
        /// <param name="cultureName">The name of a culture.</param>
        /// <param name="latestVersionEnabled">Indicates whether the repository will provide the most recent version of pages.</param>
        public KenticoArticleRepository(string cultureName, bool latestVersionEnabled)
        {
            mCultureName = cultureName;
            mLatestVersionEnabled = latestVersionEnabled;
        }


        /// <summary>
        /// Returns an enumerable collection of articles ordered by the date of publication. The most recent articles come first.
        /// </summary>
        /// <param name="count">The number of articles to return. Use 0 as value to return all records.</param>
        /// <returns>An enumerable collection that contains the specified number of articles ordered by the date of publication.</returns>
        //public IEnumerable<Article> GetArticles(int count = 0)
        //{
        //    return ArticleProvider.GetArticles()
        //        .LatestVersion(mLatestVersionEnabled)
        //        .Published(!mLatestVersionEnabled)
        //        .OnSite(SiteContext.CurrentSiteName)
        //        .Culture(mCultureName)
        //        .CombineWithDefaultCulture()
        //        .TopN(count)
        //        .OrderByDescending("DocumentPublishFrom")
        //        .ToList();
        //}

        //public IEnumerable<Article> GetArticles(int count = 0)
        //{
        //    string culture = "en-us";
        //    //string siteName = SiteContext.CurrentSiteName;

        //    Func<IEnumerable<Article>> dataLoadMethod = () => ArticleProvider.GetArticles()
        //            .OnSite("DancingGoatMvc")
        //            .Culture(culture)
        //            .TopN(count)
        //            .OrderByDescending("DocumentPublishFrom")
        //            .TypedResult; // Ensures that the result of the query is saved, not the query itself

        //    var cacheSettings = new CacheSettings(10, "myapp|data|articles", "DancingGoatMvc", culture, count)
        //    {
        //        GetCacheDependency = () =>
        //        {
        //            // Creates caches dependencies. This example makes the cache clear data when any article is modified, deleted, or created in Kentico.
        //            string dependencyCacheKey = String.Format("nodes|{0}|{1}|all", "DancingGoatMvc", Article.CLASS_NAME.ToLowerInvariant());
        //            return CacheHelper.GetCacheDependency(dependencyCacheKey);
        //        }
        //    };

        //    return CacheHelper.Cache(dataLoadMethod, cacheSettings);
        //}

        public IEnumerable<Article> GetArticles(int count = 0)
        {
            return CacheHelper.Cache(
                cs =>
                {
                    IEnumerable<Article> articles = ArticleProvider.GetArticles()
                        .OnSite("DancingGoatMvc")
                        .Culture("en-us")
                        .TopN(count)
                        .OrderByDescending("DocumentPublishFrom")
                        .TypedResult; // Ensures that the result of the query is saved, not the query itself;

                    // Setup the cache dependencies only when caching is active.
                    if (cs.Cached)
                        cs.CacheDependency = CacheHelper.GetCacheDependency(String.Format("nodes|{0}|{1}|all", "DancingGoatMvc", Article.CLASS_NAME.ToLowerInvariant()));

                    return articles;
                },
                new CacheSettings(5, "myapp|data|articles", "DancingGoatMvc", "en-us", count)
            );
        }

        /// <summary>
        /// Returns the article with the specified identifier.
        /// </summary>
        /// <param name="nodeGUID">The article node identifier.</param>
        /// <returns>The article with the specified node identifier, if found; otherwise, null.</returns>
        public Article GetArticle(Guid nodeGUID)
        {
            return ArticleProvider.GetArticle(nodeGUID, mCultureName, SiteContext.CurrentSiteName)
                .LatestVersion(mLatestVersionEnabled)
                .Published(!mLatestVersionEnabled)
                .CombineWithDefaultCulture();
        }
    }
}