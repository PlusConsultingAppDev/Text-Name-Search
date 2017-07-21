using System;
using System.Web.Http;
using System.Collections.ObjectModel;
using WebApplication1.Models;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class NamesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("NameExtractor")]
        public NameModelColl Names(string words) //The input is just for show. Can't put that large body of text in an httpget.
        {
            var results = new NameModelColl();
            results.Names = new Collection<NameModel>();
            int ConnorCount = 0;
            int SethCount = 0;
            int DavidCount = 0;
            string TheArticle = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, maximus risus. Morbi in risus id risus feugiat egestas. David Black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. Black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero. Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas finibus magna libero, vehicula David Black luctus lorem varius non. Integer ut tempor massa, eget sollicitudin purus. Mauris efficitur in ipsum eu consectetur. Aliquam vitae nulla vitae sapien laoreet vehicula et et ex. Donec molestie auctor lorem eget rhoncus. Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus. Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu. Nam quis pretium felis. Sed id turpis sed lacus malesuada pulvinar et eget leo. Vestibulum eget dapibus mi. Duis tempor nec tellus vitae aliquet. Nam sapien massa, ornare non posuere sit amet, cursus a velit. Curabitur nec consectetur metus. Donec porttitor at libero a blandit. Proin luctus augue sit amet sem varius ultricies. Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac nisl sed risus tincidunt finibus. Curabitur viverra eget justo non dignissim. Proin varius malesuada enim non vulputate. Integer fermentum interdum felis, luctus commodo nisi pulvinar quis. Donec pharetra faucibus urna a semper. Morbi tempor maximus Connor G Smith lectus sit amet interdum. Integer pretium ut est non vulputate. Aliquam pulvinar turpis laoreet dictum ultrices. Aenean diam metus, semper at quam et, iaculis viverra ante. Sed efficitur lorem quis consectetur mollis. Vivamus ut purus mauris. Quisque at gravida dolor. Fusce congue magna enim, ut placerat est porttitor a. Phasellus rutrum, neque lacinia cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo. Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.";

            #region Regex Army
            Dictionary<string, Regex> TheRegexArmy = new Dictionary<string, Regex>();

            //Now, you're probably asking "what if they write the person's name LiKe tHiS In AlT CaPs?
            //Well, if they're writing names like that go tell them to write them properly.

            //Connor
            TheRegexArmy.Add("ConnorFiLa", new Regex("[C|c]onnor [S|s]mith"));
            TheRegexArmy.Add("ConnorFiShortMiLa", new Regex("[C|c]onnor [G|g] [S|s]mith"));
            TheRegexArmy.Add("ConnorFiShortMidotLa", new Regex("[C|c]onnor [G|g]. [S|s]mith"));
            TheRegexArmy.Add("ConnorFiMiLa", new Regex("[C|c]onnor [G|g]ary [S|s]mith"));

            //Seth
            TheRegexArmy.Add("SethFiLa", new Regex("[S|s]eth [G|g]reenly"));
            TheRegexArmy.Add("SethFiShortMiLa", new Regex("[S|s]eth [D|d] [G|g]reenly"));
            TheRegexArmy.Add("SethFiShortMidotLa", new Regex("[S|s]eth [D|d]. [G|g]reenly"));
            TheRegexArmy.Add("SethFiMiLa", new Regex("[S|s]eth [D|d]avid [G|g]reenly"));

            //David
            TheRegexArmy.Add("DavidFiLa", new Regex("[D|d]avid [B|b]lack"));
            TheRegexArmy.Add("DavidFiShortMiLa", new Regex("[D|d]avid [W|w] [B|b]lack"));
            TheRegexArmy.Add("DavidFiShortMidotLa", new Regex("[D|d]avid [W|w]. [B|b]lack"));
            TheRegexArmy.Add("DavidFiMiLa", new Regex("[D|d]avid [W|w]arren [B|b]lack"));
            #endregion

            #region Matches
            ConnorCount += TheRegexArmy["ConnorFiLa"].Matches(TheArticle).Count;
            ConnorCount += TheRegexArmy["ConnorFiShortMiLa"].Matches(TheArticle).Count;
            ConnorCount += TheRegexArmy["ConnorFiShortMidotLa"].Matches(TheArticle).Count;
            ConnorCount += TheRegexArmy["ConnorFiMiLa"].Matches(TheArticle).Count;

            SethCount += TheRegexArmy["SethFiLa"].Matches(TheArticle).Count;
            SethCount += TheRegexArmy["SethFiShortMiLa"].Matches(TheArticle).Count;
            SethCount += TheRegexArmy["SethFiShortMidotLa"].Matches(TheArticle).Count;
            SethCount += TheRegexArmy["SethFiMiLa"].Matches(TheArticle).Count;

            DavidCount += TheRegexArmy["DavidFiLa"].Matches(TheArticle).Count;
            DavidCount += TheRegexArmy["DavidFiShortMiLa"].Matches(TheArticle).Count;
            DavidCount += TheRegexArmy["DavidFiShortMidotLa"].Matches(TheArticle).Count;
            DavidCount += TheRegexArmy["DavidFiMiLa"].Matches(TheArticle).Count;
            #endregion

            results.Names.Add(new NameModel() { Name = "Connor Gary Smith", Count = ConnorCount.ToString() });
            results.Names.Add(new NameModel() { Name = "Seth David Greenly", Count = SethCount.ToString() });
            results.Names.Add(new NameModel() { Name = "David Warren Black", Count = DavidCount.ToString() });

            return results;
        }
    }
}
